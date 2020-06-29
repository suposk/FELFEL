using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public abstract class DtoBase
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
