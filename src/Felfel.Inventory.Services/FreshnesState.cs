using System.ComponentModel;

namespace Felfel.Inventory.Services
{
    public enum FreshnesState 
    { 
        [Description("Fresh Food")]
        Fresh,

        [Description("Will Expire Today")]
        ExpiresToday,

        [Description("Expired")]
        Expired 
    }
}
