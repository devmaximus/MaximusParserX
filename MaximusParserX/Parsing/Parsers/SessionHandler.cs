using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    //public static Guid LoginGuid;

    //public static CharacterInfo LoggedInCharacter;

    public class SMSG_AUTH_CHALLENGE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var unk = ReadInt32("unk");

            var seed = ReadInt32("seed");

            for (var i = 0; i < 8; i++)
            {
                var rand = ReadInt32("rand");
            }
            return Validate();
        }
    }

    public class CMSG_AUTH_SESSION_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var build = ReadInt32("build");
            var unk1 = ReadInt32("unk1");
            var account = ReadCString("account");
            var unk2 = ReadInt32("unk2");
            var clientSeed = ReadInt32("clientSeed");
            var unk3 = ReadInt64("unk3");
            var digest = ReadBytes(20);

            //AddonHandler.ReadClientAddonsList(packet);
            return Validate();
        }
    }

    public class SMSG_AUTH_RESPONSE_DEF : SessionDef
    {
        public override bool Parse()
        {
            ResetPosition();
            var code = ReadEnum<ResponseCodes>("ResponseCode", TypeCode.Byte);

            switch (code)
            {
                case ResponseCodes.AUTH_OK:
                    {
                        ReadAuthResponseInfo();
                        break;
                    }
                case ResponseCodes.AUTH_WAIT_QUEUE:
                    {
                        if (BaseStream.Length <= 6)
                        {
                            ReadQueuePositionInfo();
                            break;
                        }

                        ReadAuthResponseInfo();
                        ReadQueuePositionInfo();
                        break;
                    }
            }
            return Validate();
        }
    }

    public class SessionDef : DefinitionBase
    {
        public void ReadAuthResponseInfo()
        {
            var billingRemaining = ReadInt32("billingRemaining");
            var billingFlags = ReadEnum<BillingFlag>("BillingFlag", TypeCode.Byte); 
            var billingRested = ReadInt32("billingRested");
            var expansion = ReadEnum<ClientType>("ClientType", TypeCode.Byte);  
        }

        public void ReadQueuePositionInfo()
        {
            var position = ReadInt32("position");
            var unkByte = ReadByte("unkByte");
        }
    }

    public class CMSG_PLAYER_LOGIN_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid =  ReadPackedWoWGuid("guid");
            Core.SetCurrentPlayerWoWGuid(guid);
            return Validate();
        }
    }

    public class SMSG_CHARACTER_LOGIN_FAILED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var unk = ReadByte("unk");
            return Validate();
        }
    }

    public class SMSG_LOGOUT_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var unk1 = ReadInt32("unk1");

            var unk2 = ReadInt32("unk2");
            return Validate();
        }
    }

    public class SMSG_LOGOUT_COMPLETE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            Core.LogOutCurrentPlayer();
            return Validate();
        }
    }

    public class SMSG_REDIRECT_CLIENT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var ip = ReadIPAddress("ip");
            var port = ReadUInt16("port");
            var unk = ReadInt32("unk");
            var hash = ReadBytes(20);
            return Validate();
        }
    }

    public class CMSG_REDIRECTION_FAILED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var token = ReadInt32("token");
            return Validate();
        }
    }

    public class CMSG_REDIRECTION_AUTH_PROOF_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var name = ReadCString("name");
            var unk = ReadInt64("unk");
            var hash = ReadBytes(20);
            return Validate();
        }
    }

    public class SMSG_KICK_REASON_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var reason = ReadEnum<KickReason>("KickReason", TypeCode.Byte); 

            if (AvailableBytes > 0)
            {
                var str = ReadCString("str");
            }
            return Validate();
        }
    }

    public class SMSG_MOTD_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var lineCount = ReadInt32("lineCount");

            for (var i = 0; i < lineCount; i++)
            {
                var lineStr = ReadCString("lineStr");
            }
            return Validate();
        }

    }
}


