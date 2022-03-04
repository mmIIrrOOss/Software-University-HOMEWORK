namespace INStock
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        private readonly HashSet<string> productsLabels;
        private readonly List<IProduct> productByIndex;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;
        private readonly SortedDictionary<decimal, List<IProduct>> productsByPrice;

        public ProductStock()
        {
            this.productsLabels = new HashSet<string>();
            this.productByIndex = new List<IProduct>();
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
            this.productsByPrice = new SortedDictionary<decimal, List<IProduct>>
                                  (Comparer<decimal>.Create((first, second) => second.CompareTo(first)));
        }

        public int Count => this.productByIndex.Count;

        public void Add(IProduct product)
        {
            this.ValidateNullProduct(product);

            if (this.productsLabels.Contains(product.Label))
            {
                throw new ArgumentException($"A product with {product.Label} label arllready exists.");
            }
            this.InitializeCollections(product);

            this.productsLabels.Add(product.Label);
            this.productByIndex.Add(product);
            this.productsByLabel[product.Label] = product;
            this.productsByQuantity[product.Quantity].Add(product);
            this.productsByPrice[product.Price].Add(product);

        }

        public bool Contains(IProduct product)
        {
            this.ValidateNullProduct(product);

            return this.productsLabels.Contains(product.Label);
        }


        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"Product index does not exists.");
            }
            return this.productByIndex[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var priceAsDecimal = (decimal)price;
            if (!this.productsByPrice.ContainsKey(priceAsDecimal))
            {
                return Enumerable.Empty<IProduct>();
            }
            return this.productsByPrice[priceAsDecimal];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (!this.productsByQuantity.ContainsKey(quantity))
            {
                return Enumerable.Empty<IProduct>();
            }
            return this.productsByQuantity[quantity];
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var result = new List<IProduct>();
            foreach (var (price, products) in productsByPrice)
            {
                var priceAsDouble = (double)price;

                if (lo <= priceAsDouble && priceAsDouble <= hi)
                {
                    result.AddRange(products);
                }

                if (priceAsDouble < lo)
                {
                    break;
                }
            }

            return result;
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException("Product label cannot be null.");
            }
            if (!this.productsLabels.Contains(label))
            {
                throw new ArgumentException($"Product with {label} label could not be found.");
            }

            return this.productsByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productsByPrice.Any())
            {
                throw new InvalidOperationException("Product stock is empty.");
            }
            var mostExpensiveProducts = this.productsByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();

            return firstAddedExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator() => this.productByIndex.GetEnumerator();

        public IProduct this[int index]
        {
            get => this.Find(index);
            set
            {
                this.ValidateNullProduct(value);

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollections(value);

                this.productByIndex[index] = value;
            }
        }

        public bool Remove(IProduct product)
        {
            this.ValidateNullProduct(product);

            if (!this.productsLabels.Contains(product.Label))
            {
                return false;
            }

            this.productByIndex.RemoveAll(pr => pr.Label == product.Label);
            this.RemoveProductFromCollections(product);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();



        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }

        }

        private void InitializeCollections(IProduct product)
        {
            if (!this.productsByQuantity.ContainsKey(product.Quantity))
            {
                this.productsByQuantity[product.Quantity] = new List<IProduct>();
            }
            if (!this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice[product.Price] = new List<IProduct>();
            }
        }

        private void RemoveProductFromCollections(IProduct product)
        {
            this.productsLabels.Remove(product.Label);
            this.productsByLabel.Remove(product.Label);

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == product.Label);

            var allWithProductPrice = this.productsByPrice[product.Price];
            allWithProductPrice.RemoveAll(pr => pr.Label == product.Label);
        }
    }
}
