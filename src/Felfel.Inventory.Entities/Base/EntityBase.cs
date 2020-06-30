using System;

namespace Felfel.Inventory.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public DateTime CreatedAtUtc { get; set; }

        public DateTime? ModifiedAtUtc { get; set; }
    }

}
