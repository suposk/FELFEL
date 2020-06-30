namespace Felfel.Inventory.Domain
{
    public class ProductDto : DtoEntityBaseSoftDelete
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }
    }
}
