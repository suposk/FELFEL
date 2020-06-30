namespace Felfel.Inventory.Entities
{
    public abstract class EntityBaseSoftDelete : EntityBase, IEntitySoftDeleteBase
    {
        public bool IsDeleted { get; set; }
    }
}
