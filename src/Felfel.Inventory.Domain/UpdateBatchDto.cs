using System.ComponentModel.DataAnnotations;

namespace Felfel.Inventory.Domain

{
    public class UpdateBatchDto
    {
        [Range(1, int.MaxValue)]
        public int BatchId { get; set; }

        [Range(1, int.MaxValue)]
        public int Units { get; set; }
        
        public bool DecrementUnits { get; set; }

        public string Description { get; set; }
    }
}
