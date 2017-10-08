using System.ComponentModel;

namespace BookCollection.Core.Enums
{
    public enum Status
    {
        [Description("In Collection")]
        InCollection = 1,

        [Description("For Sale")]
        ForSale = 2,

        [Description("Wish List")]
        WishList = 3,

        [Description("Not in Collection")]
        NotInCollection = 4,
    }
}
