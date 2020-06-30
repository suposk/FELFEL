namespace Felfel.Inventory.Domain
{
    public class UpdateBatchDto
    {
        public int BatchId { get; set; }                    

        public int Units { get; set; }
        
        public bool DecrementUnits { get; set; }

        public string Description { get; set; }
    }
}
