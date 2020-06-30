using System;
using System.Collections.Generic;
using System.Text;

namespace Felfel.Inventory.Domain
{
    public abstract class DtoBase
    {
        public DateTime CreatedAtUtc { get; set; }

        public DateTime? ModifiedAtUtc { get; set; }
    }
}
