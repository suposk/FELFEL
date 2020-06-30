namespace Felfel.Inventory.Domain
{
    public class BatchHistoryDto : DtoBase
    {
        public int BatchHistoryId { get; set; }

        public int BatchId { get; set; }

        public int Units { get; set; }

        public string Description { get; set; }
    }
}
