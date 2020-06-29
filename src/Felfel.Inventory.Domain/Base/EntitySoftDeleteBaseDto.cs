namespace Felfel.Inventory.Domain
{
    public abstract class EntitySoftDeleteBaseDto : DtoBase
    {
        public bool IsDeleted { get; set; }
    }
}
