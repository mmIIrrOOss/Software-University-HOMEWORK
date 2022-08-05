namespace ProductShop.DataTransferObject.Export
{
    public class ProductSoldDto
    {
        public int Count { get; set; }

        public ProductAllDto[] Products { get; set; }
    }
}
