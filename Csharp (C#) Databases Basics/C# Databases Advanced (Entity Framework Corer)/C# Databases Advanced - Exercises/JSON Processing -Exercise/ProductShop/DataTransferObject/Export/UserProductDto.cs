namespace ProductShop.DataTransferObject.Export
{
    public class UserProductDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ProductSoldDto SoldProducts { get; set; }
    }
}