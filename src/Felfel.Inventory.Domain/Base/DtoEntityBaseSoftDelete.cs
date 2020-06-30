namespace Felfel.Inventory.Domain
{
    public abstract class DtoEntityBaseSoftDelete : DtoBase
    {
        public bool IsDeleted { get; set; }
    }
}
