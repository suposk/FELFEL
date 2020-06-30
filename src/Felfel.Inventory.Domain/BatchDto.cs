using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{

    public enum ModifyType 
    {        
        Add,
        Remove,
    }

    public class BatchDto : DtoEntityBaseSoftDelete
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }

        public int DeliveredUnits { get; set; }

        public int AvailableUnits { get; set; }

        public string SupplierName { get; set; }

        public DateTime ExpirationDate { get; set; }
    }

    public class UpdateBatchDto : DtoEntityBaseSoftDelete
    {
        public int BatchId { get; set; }

        public int ProductId { get; set; }               

        public int Units { get; set; }

        public ModifyType OperationType { get; set; }
    }
}
