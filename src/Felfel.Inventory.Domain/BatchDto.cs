using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public class BatchDto : DtoEntityBaseSoftDelete
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public int DeliveredUnits { get; set; }

        public int AvailableUnits { get; set; }

        public string SupplierName { get; set; }

        public DateTime ExpirationDate { get; set; }
    }

    public class UpdateBatchDto
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }               

        public int Units { get; set; }
        
        public bool DecrementUnits { get; set; }

        public string Description { get; set; }
    }
}
