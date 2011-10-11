using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public enum KickReason : byte
    {
        NoGenericReason = 0,
        DuplicateSession = 1,
        NoGameTime = 2,
        AccountBanned = 3,
        ParentalControl = 4
    }
}
