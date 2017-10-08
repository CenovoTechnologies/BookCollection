using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Core.Enums
{
    public enum BookFormat
    {
        [Description("Audiobook")]
        Audiobook = 1,

        [Description("E-book")]
        EBook = 2,

        [Description("Folio")]
        Folio = 3,

        [Description("Hardcover")]
        Hardcover = 4,

        [Description("Paperback")]
        Paperback = 5,

        [Description("Mass-Market Paperback")]
        MassMarketPaperback = 6
    }
}
