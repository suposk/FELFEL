using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public class Batch : EntityBaseSoftDelete
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public int DeliveredUnits { get; set; }

        //public int CurrentUnits { get; set; }

        public string SupplierName { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
