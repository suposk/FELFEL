using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public class Batch : EntitySoftDeleteBase
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public string SupplierName { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
