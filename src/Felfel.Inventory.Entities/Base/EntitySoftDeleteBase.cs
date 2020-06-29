namespace Felfel.Inventory.Entities
{
    public abstract class EntitySoftDeleteBase : EntityBase, IEntitySoftDeleteBase
    {
        public bool IsDeleted { get; set; }
    }
}
