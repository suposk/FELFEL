using System;

namespace Felfel.Inventory.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }

}
