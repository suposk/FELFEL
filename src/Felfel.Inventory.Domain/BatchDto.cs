using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public class BatchDto : CreateBatchDto
    {
        public int BatchId { get; set; }

        public int AvailableUnits { get; set; }
    }
}
