using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    [Flags]
    public enum FactionFlags : byte
    {
        VISIBLE = 0x01,                 // makes visible in client (set or can be set at interaction with target of this faction)
        AT_WAR = 0x02,                 // enable AtWar-button in client. player controlled (except opposition team always war state), Flag only set on initial creation
        HIDDEN = 0x04,                 // hidden faction from reputation pane in client (player can gain reputation, but this update not sent to client)
        INVISIBLE_FORCED = 0x08,                 // always overwrite VISIBLE and hide faction in rep.list, used for hide opposite team factions
        PEACE_FORCED = 0x10,                 // always overwrite AT_WAR, used for prevent war with own team factions
        INACTIVE = 0x20,                 // player controlled, state stored in characters.data ( CMSG_SET_FACTION_INACTIVE )
        RIVAL = 0x40,                 // flag for the two competing outland factions
        TEAM_REPUTATION = 0x80                  // faction has own reputation standing despite teaming up sub-factions; spillover from subfactions will go this instead of other subfactions
    };

}
