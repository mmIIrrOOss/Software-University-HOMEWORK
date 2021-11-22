namespace P05_GreedyTimes.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private List<Item> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.bag = new List<Item>();
        }

        public long GoldItemsValue
        {
            get
            {
                return this.bag.Where(i => i is GoldItem).Sum(i => i.Value);
            }
        }

        public long CashItemsValue
        {
            get
            {
                return this.bag.Where(i => i is CashItem).Sum(i => i.Value);
            }
        }

        public long GemItemsValue
        {
            get
            {
                return this.bag.Where(i => i is GemItem).Sum(i => i.Value);
            }
        }

        public void AddGoldItem(GoldItem item)
        {
            if (this.capacity >= this.current + item.Value)
            {
                var goldItems = GetGoldItems();
                if (goldItems.Any(gi => gi.Key == item.Key))
                {
                    goldItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }

                this.current += item.Value;
            }
        }

        public void AddGemItem(GemItem item)
        {
            if (this.capacity >= this.current + item.Value && this.GoldItemsValue >= this.GemItemsValue + item.Value)
            {
                var gemItems = GetGemItems();
                if (gemItems.Any(gi => gi.Key == item.Key))
                {
                    gemItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }
                this.current += item.Value;
            }
        }

        public void AddCashItem(CashItem item)
        {
            if (this.capacity >= this.current + item.Value && this.GemItemsValue >= this.CashItemsValue + item.Value)
            {
                var cashItems = GetCashItems();
                if (cashItems.Any(gi => gi.Key == item.Key))
                {
                    cashItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }
                this.current += item.Value;
            }
        }

        public List<Item> GetCashItems()
        {
            return this.bag.Where(i => i is CashItem).ToList();
        }

        public List<Item> GetGoldItems()
        {
            return this.bag.Where(i => i is GoldItem).ToList();
        }

        public List<Item> GetGemItems()
        {
            return this.bag.Where(i => i is GemItem).ToList();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            var dictionary = this.bag.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in dictionary.OrderByDescending(kv => kv.Value.Sum(i => i.Value)))
            {
                if (kvp.Key == "CashItem")
                {
                    builder.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "GemItem")
                {
                    builder.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "GoldItem")
                {
                    builder.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    builder.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
