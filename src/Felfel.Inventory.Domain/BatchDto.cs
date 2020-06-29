using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public class BatchDto : EntitySoftDeleteBaseDto
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public int DeliveredQuantity { get; set; }

        public int CurrentQuantity { get; set; }

        public string SupplierName { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
