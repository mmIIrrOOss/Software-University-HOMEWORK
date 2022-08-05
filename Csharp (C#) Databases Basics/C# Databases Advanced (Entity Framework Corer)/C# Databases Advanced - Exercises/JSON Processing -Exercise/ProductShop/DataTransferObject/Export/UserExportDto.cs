namespace ProductShop.DataTransferObject.Export
{
    public class UserExportDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SoldProductDto[] SoldProducts { get; set; }
    }
}
