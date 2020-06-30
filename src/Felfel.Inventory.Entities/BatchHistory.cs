namespace Felfel.Inventory.Entities
{
    public class BatchHistory : EntityBase
    {
        public int BatchHistoryId { get; set; }

        public int BatchId { get; set; }        

        public int Units { get; set; }

        public string Description { get; set; }
    }
}
