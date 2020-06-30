using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public interface IEntityBase
    {
        DateTime CreatedAtUtc { get; set; }

        DateTime? ModifiedAtUtc { get; set; }
    }

}
