using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public interface IEntitySoftDeleteBase : IEntityBase
    {
        bool IsDeleted { get; set; }
    }
}
