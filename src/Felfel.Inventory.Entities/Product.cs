namespace Felfel.Inventory.Entities
{
    public class Product : EntityBaseSoftDelete
    {        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
