using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Entities
{
    public interface IEntityBase
    {
        DateTime CreatedAt { get; set; }

        DateTime? ModifiedAt { get; set; }
    }

}
