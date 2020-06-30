using System;
using System.ComponentModel.DataAnnotations;

namespace Felfel.Inventory.Domain
{
    public class CreateBatchDto : DtoEntityBaseSoftDelete
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        [Range(1, int.MaxValue)]
        public int DeliveredUnits { get; set; }                

        public DateTime ExpirationDate { get; set; }
    }
}
