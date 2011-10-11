using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class MSG_SET_DUNGEON_DIFFICULTY_DEF : MSG_SET_RAID_DIFFICULTY_DEF { }
    public class MSG_SET_RAID_DIFFICULTY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var difficulty = ReadEnum<Difficulty>("Difficulty");

            if (Direction == Direction.ServerToClient)
            {
                var unkByte = ReadInt32("unkByte");
                var inGroup = ReadInt32("inGroup");
            }
            return Validate();
        }
    }

    public class SMSG_INSTANCE_DIFFICULTY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var difficulty = ReadEnum<Difficulty>("Difficulty");
            var playerdifficulty = ReadInt32("playerdifficulty");

            return Validate();
        }
    }

    public class SMSG_PLAYER_DIFFICULTY_CHANGE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var type = Read<DifficultyChangeType>("DifficultyChangeType");

            switch (type)
            {
                case DifficultyChangeType.PlayerDifficulty1:
                    {
                        var PlayerDifficulty = ReadByte("PlayerDifficulty");
                        break;
                    }
                case DifficultyChangeType.SpellDuration:
                    {
                        var SpellDuration = ReadInt32("SpellDuration"); 
                        break;
                    }
                case DifficultyChangeType.Time:
                    {
                        var time = ReadInt32("Time");
                        break;
                    }
                case DifficultyChangeType.MapDifficulty:
                    {
                        var difficulty = ReadEnum<Difficulty>("Difficulty");
                        break;
                    }
            }
            return Validate();
        }
    }
}
