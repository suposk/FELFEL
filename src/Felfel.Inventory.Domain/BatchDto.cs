using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public class BatchDto : DtoEntityBaseSoftDelete
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int DeliveredUnits { get; set; }

        public int AvailableUnits { get; set; }        

        public DateTime ExpirationDate { get; set; }
    }
}
