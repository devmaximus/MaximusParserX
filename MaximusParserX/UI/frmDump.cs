using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using MaximusParserX.UI.Controls;
using MaximusParserX.Frame;

namespace MaximusParserX.UI
{
    public partial class frmDump : DockContent
    {
        public frmDump()
        {
            InitializeComponent();
        }

        public UIManager UIManager { get; set; }

        private void btnBeginDump_Click(object sender, EventArgs e)
        {

            DumpData();

            //GenerateOpcodeDeclerations();

            //DumpGossipData();
            //DumpInstanceData();
            //DumpGameObjectSpawnData();
        }

        public void GenerateOpcodeDeclerations()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();
            sb2.AppendLine("var query = GetBaseOpcodeQuery(false);");

            var ignorelist = new List<string>();

            ignorelist.Add("SMSG_COMPRESSED_UPDATE_OBJECT");
            ignorelist.Add("SMSG_UPDATE_OBJECT");
            ignorelist.Add("SMSG_SET_PHASE_SHIFT");
            ignorelist.Add("SMSG_TRANSFER_PENDING");
            ignorelist.Add("SMSG_TRANSFER_ABORTED");
            ignorelist.Add("SMSG_NEW_WORLD");
            ignorelist.Add("SMSG_LOGIN_VERIFY_WORLD");
            ignorelist.Add("SMSG_INIT_WORLD_STATES");
            ignorelist.Add("SMSG_RAID_INSTANCE_MESSAGE");

            using (var sr = new System.IO.StreamReader("opcodes.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Trim();

                    if (!line.IsEmpty() && !ignorelist.Contains(line))
                    {
                        //MaximusParserX.Parsing.Version.v3_2_2_10505.Enums.Opcodes
                        MaximusParserX.Parsing.Version.v3_2_2_10505.Enums.Opcodes o;
                        Enum.TryParse<MaximusParserX.Parsing.Version.v3_2_2_10505.Enums.Opcodes>(line, out o);

                        sb.AppendLine("var {0} = {1};", line, (uint)o);

                        sb2.AppendLine("query.Append(string.Format(\"{0},\", " + line + "));");
                    }
                }

                sb2.Append(")");
            }

            var text = sb.ToString() + sb2.ToString();
        }
        private void DumpData()
        {
            var CMSG_ALTER_APPEARANCE = 1062;
            var CMSG_AREATRIGGER = 180;
            var CMSG_AUTH_SESSION = 493;
            var CMSG_BANKER_ACTIVATE = 439;
            var CMSG_BATTLEFIELD_STATUS = 723;
            var CMSG_BATTLEMASTER_HELLO = 727;
            var CMSG_BINDER_ACTIVATE = 437;
            var CMSG_CALENDAR_GET_CALENDAR = 1065;
            var CMSG_CALENDAR_GET_NUM_PENDING = 1095;
            var CMSG_CHANNEL_VOICE_ON = 982;
            var CMSG_CHAR_CREATE = 54;
            var CMSG_CHAR_CUSTOMIZE = 1139;
            var CMSG_CHAR_DELETE = 56;
            var CMSG_CHAR_ENUM = 55;
            var CMSG_CHAR_RENAME = 711;
            var CMSG_CREATURE_QUERY = 96;
            var CMSG_DISMISS_CONTROLLED_VEHICLE = 1133;
            var CMSG_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK = 900;
            var CMSG_FORCE_FLIGHT_SPEED_CHANGE_ACK = 898;
            var CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK = 229;
            var CMSG_FORCE_RUN_SPEED_CHANGE_ACK = 227;
            var CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK = 733;
            var CMSG_FORCE_SWIM_SPEED_CHANGE_ACK = 231;
            var CMSG_FORCE_TURN_RATE_CHANGE_ACK = 735;
            var CMSG_FORCE_WALK_SPEED_CHANGE_ACK = 731;
            var CMSG_GMTICKET_GETTICKET = 529;
            var CMSG_GOSSIP_HELLO = 379;
            var CMSG_GOSSIP_SELECT_OPTION = 380;
            var CMSG_HEARTH_AND_RESURRECT = 1180;
            var CMSG_ITEM_QUERY_SINGLE = 86;
            var CMSG_KEEP_ALIVE = 1031;
            var CMSG_LFD_PARTY_LOCK_INFO_REQUEST = 881;
            var CMSG_LFD_PLAYER_LOCK_INFO_REQUEST = 878;
            var CMSG_LIST_INVENTORY = 414;
            var CMSG_LOGOUT_CANCEL = 78;
            var CMSG_LOGOUT_REQUEST = 75;
            var CMSG_MEETINGSTONE_INFO = 662;
            var CMSG_MOUNTSPECIAL_ANIM = 369;
            var CMSG_MOVE_CHNG_TRANSPORT = 909;
            var CMSG_MOVE_FALL_RESET = 714;
            var CMSG_MOVE_HOVER_ACK = 246;
            var CMSG_MOVE_KNOCK_BACK_ACK = 240;
            var CMSG_MOVE_NOT_ACTIVE_MOVER = 721;
            var CMSG_MOVE_SET_FLY = 838;
            var CMSG_MOVE_WATER_WALK_ACK = 720;
            var CMSG_NAME_QUERY = 80;
            var CMSG_NPC_TEXT_QUERY = 383;
            var CMSG_PAGE_TEXT_QUERY = 90;
            var CMSG_PING = 476;
            var CMSG_PLAYER_LOGIN = 61;
            var CMSG_PLAYER_LOGOUT = 74;
            var CMSG_QUERY_INSPECT_ACHIEVEMENTS = 1131;
            var CMSG_QUERY_TIME = 462;
            var CMSG_QUEST_POI_QUERY = 483;
            var CMSG_QUEST_QUERY = 92;
            var CMSG_READY_FOR_ACCOUNT_DATA_TIMES = 1279;
            var CMSG_REALM_SPLIT = 908;
            var CMSG_REDIRECTION_AUTH_PROOF = 1298;
            var CMSG_REDIRECTION_FAILED = 1294;
            var CMSG_REQUEST_ACCOUNT_DATA = 522;
            var CMSG_REQUEST_RAID_INFO = 717;
            var CMSG_SET_ACTIVE_MOVER = 618;
            var CMSG_SPIRIT_HEALER_ACTIVATE = 540;
            var CMSG_SUMMON_RESPONSE = 684;
            var CMSG_TRAINER_LIST = 432;
            var CMSG_TUTORIAL_CLEAR = 255;
            var CMSG_TUTORIAL_FLAG = 254;
            var CMSG_TUTORIAL_RESET = 256;
            var CMSG_UPDATE_ACCOUNT_DATA = 523;
            var CMSG_UPDATE_PROJECTILE_POSITION = 1214;
            var CMSG_WORLD_STATE_UI_TIMER_UPDATE = 1270;
            var MSG_MOVE_FALL_LAND = 201;
            var MSG_MOVE_HEARTBEAT = 238;
            var MSG_MOVE_JUMP = 187;
            var MSG_MOVE_SET_FACING = 218;
            var MSG_MOVE_SET_PITCH = 219;
            var MSG_MOVE_SET_RUN_MODE = 194;
            var MSG_MOVE_SET_WALK_MODE = 195;
            var MSG_MOVE_START_ASCEND = 857;
            var MSG_MOVE_START_BACKWARD = 182;
            var MSG_MOVE_START_DESCEND = 935;
            var MSG_MOVE_START_FORWARD = 181;
            var MSG_MOVE_START_PITCH_DOWN = 192;
            var MSG_MOVE_START_PITCH_UP = 191;
            var MSG_MOVE_START_STRAFE_LEFT = 184;
            var MSG_MOVE_START_STRAFE_RIGHT = 185;
            var MSG_MOVE_START_SWIM = 202;
            var MSG_MOVE_START_TURN_LEFT = 188;
            var MSG_MOVE_START_TURN_RIGHT = 189;
            var MSG_MOVE_STOP = 183;
            var MSG_MOVE_STOP_ASCEND = 858;
            var MSG_MOVE_STOP_PITCH = 193;
            var MSG_MOVE_STOP_STRAFE = 186;
            var MSG_MOVE_STOP_SWIM = 203;
            var MSG_MOVE_STOP_TURN = 190;
            var MSG_MOVE_TELEPORT = 197;
            var MSG_MOVE_TELEPORT_ACK = 199;
            var MSG_MOVE_WORLDPORT_ACK = 220;
            var MSG_SET_DUNGEON_DIFFICULTY = 809;
            var MSG_SET_RAID_DIFFICULTY = 1259;
            var MSG_TABARDVENDOR_ACTIVATE = 498;
            var SMSG_ACCOUNT_DATA_TIMES = 521;
            var SMSG_ACHIEVEMENT_DELETED = 1183;
            var SMSG_ACHIEVEMENT_EARNED = 1128;
            var SMSG_ALL_ACHIEVEMENT_DATA = 1149;
            var SMSG_AURA_UPDATE = 1174;
            var SMSG_AURA_UPDATE_ALL = 1173;
            var SMSG_AUTH_CHALLENGE = 492;
            var SMSG_AUTH_RESPONSE = 494;
            var SMSG_BARBER_SHOP_RESULT = 1064;
            var SMSG_BINDPOINTUPDATE = 341;
            var SMSG_CHAR_CREATE = 58;
            var SMSG_CHAR_CUSTOMIZE = 1140;
            var SMSG_CHAR_DELETE = 60;
            var SMSG_CHAR_ENUM = 59;
            var SMSG_CHAR_RENAME = 712;
            var SMSG_CHARACTER_LOGIN_FAILED = 65;
            var SMSG_CLIENTCACHE_VERSION = 1195;
            var SMSG_COMPRESSED_MOVES = 763;
            var SMSG_COMSAT_CONNECT_FAIL = 994;
            var SMSG_COMSAT_DISCONNECT = 993;
            var SMSG_COMSAT_RECONNECT_TRY = 992;
            var SMSG_CREATURE_QUERY_RESPONSE = 97;
            var SMSG_CRITERIA_DELETED = 1182;
            var SMSG_CRITERIA_UPDATE = 1130;
            var SMSG_DESTROY_OBJECT = 170;
            var SMSG_FEATURE_SYSTEM_STATUS = 969;
            var SMSG_FLIGHT_SPLINE_SYNC = 904;
            var SMSG_FORCE_MOVE_ROOT = 232;
            var SMSG_FORCE_MOVE_UNROOT = 234;
            var SMSG_FORCE_SEND_QUEUED_PACKETS = 1297;
            var SMSG_GAMEOBJECT_QUERY_RESPONSE = 95;
            var SMSG_GOSSIP_COMPLETE = 382;
            var SMSG_GOSSIP_MESSAGE = 381;
            var SMSG_GOSSIP_POI = 548;
            var SMSG_INITIAL_SPELLS = 298;
            var SMSG_INITIALIZE_FACTIONS = 290;
            var SMSG_INSTANCE_DIFFICULTY = 827;
            var SMSG_INSTANCE_RESET = 798;
            var SMSG_ITEM_NAME_QUERY_RESPONSE = 709;
            var SMSG_ITEM_QUERY_MULTIPLE_RESPONSE = 89;
            var SMSG_ITEM_QUERY_SINGLE_RESPONSE = 88;
            var SMSG_ITEM_TEXT_QUERY_RESPONSE = 580;
            var SMSG_KICK_REASON = 965;
            var SMSG_LEARNED_DANCE_MOVES = 1109;
            var SMSG_LEARNED_SPELL = 299;
            var SMSG_LEVELUP_INFO = 468;
            var SMSG_LFG_DISABLED = 920;
            var SMSG_LIST_INVENTORY = 415;
            var SMSG_LOGIN_SETTIMESPEED = 66;
            var SMSG_LOGOUT_CANCEL_ACK = 79;
            var SMSG_LOGOUT_COMPLETE = 77;
            var SMSG_LOGOUT_RESPONSE = 76;
            var SMSG_MONSTER_MOVE = 221;
            var SMSG_MONSTER_MOVE_TRANSPORT = 686;
            var SMSG_MOTD = 829;
            var SMSG_MOUNTSPECIAL_ANIM = 370;
            var SMSG_MOVE_LAND_WALK = 223;
            var SMSG_MOVE_UNKNOWN_1302 = 0;
            var SMSG_MOVE_UNKNOWN_1304 = 0;
            var SMSG_MOVE_WATER_WALK = 222;
            var SMSG_NAME_QUERY_RESPONSE = 81;
            var SMSG_NPC_TEXT_UPDATE = 384;
            var SMSG_PAGE_TEXT_QUERY_RESPONSE = 91;
            var SMSG_PET_NAME_QUERY_RESPONSE = 83;
            var SMSG_PLAY_MUSIC = 631;
            var SMSG_PLAY_OBJECT_SOUND = 632;
            var SMSG_PLAY_SOUND = 722;
            var SMSG_PLAYER_DIFFICULTY_CHANGE = 526;
            var SMSG_PONG = 477;
            var SMSG_POWER_UPDATE = 1152;
            var SMSG_QUERY_TIME_RESPONSE = 463;
            var SMSG_QUEST_FORCE_REMOVE = 542;
            var SMSG_QUEST_POI_QUERY_RESPONSE = 484;
            var SMSG_QUEST_QUERY_RESPONSE = 93;
            var SMSG_QUESTGIVER_OFFER_REWARD = 397;
            var SMSG_QUESTGIVER_QUEST_DETAILS = 392;
            var SMSG_QUESTGIVER_REQUEST_ITEMS = 395;
            var SMSG_QUESTLOG_FULL = 405;
            var SMSG_REALM_SPLIT = 907;
            var SMSG_REDIRECT_CLIENT = 1293;
            var SMSG_RESET_FAILED_NOTIFY = 918;
            var SMSG_RESPOND_INSPECT_ACHIEVEMENTS = 1132;
            var SMSG_SEND_UNLEARN_SPELLS = 1054;
            var SMSG_SERVER_FIRST_ACHIEVEMENT = 1176;
            var SMSG_SET_PROJECTILE_POSITION = 1215;
            var SMSG_SPELL_GO = 306;
            var SMSG_SPELL_START = 305;
            var SMSG_TIME_SYNC_REQ = 912;
            var SMSG_TRAINER_LIST = 433;
            var SMSG_TRIGGER_CINEMATIC = 250;
            var SMSG_TRIGGER_MOVIE = 1124;
            var SMSG_TUTORIAL_FLAGS = 253;
            var SMSG_UNIT_SPELLCAST_START = 333;
            var SMSG_UNKNOWN_1276 = 1276;
            var SMSG_UPDATE_ACCOUNT_DATA = 524;
            var SMSG_UPDATE_ACCOUNT_DATA_COMPLETE = 1123;
            var SMSG_UPDATE_ITEM_ENCHANTMENTS = 1291;
            var SMSG_UPDATE_WORLD_STATE = 707;
            var SMSG_VOICESESSION_FULL = 1020;
            var SMSG_WEATHER = 756;
            var query = GetBaseOpcodeQuery(false);
            query.Append(string.Format("{0},", CMSG_ALTER_APPEARANCE));
            query.Append(string.Format("{0},", CMSG_AREATRIGGER));
            query.Append(string.Format("{0},", CMSG_AUTH_SESSION));
            query.Append(string.Format("{0},", CMSG_BANKER_ACTIVATE));
            query.Append(string.Format("{0},", CMSG_BATTLEFIELD_STATUS));
            query.Append(string.Format("{0},", CMSG_BATTLEMASTER_HELLO));
            query.Append(string.Format("{0},", CMSG_BINDER_ACTIVATE));
            query.Append(string.Format("{0},", CMSG_CALENDAR_GET_CALENDAR));
            query.Append(string.Format("{0},", CMSG_CALENDAR_GET_NUM_PENDING));
            query.Append(string.Format("{0},", CMSG_CHANNEL_VOICE_ON));
            query.Append(string.Format("{0},", CMSG_CHAR_CREATE));
            query.Append(string.Format("{0},", CMSG_CHAR_CUSTOMIZE));
            query.Append(string.Format("{0},", CMSG_CHAR_DELETE));
            query.Append(string.Format("{0},", CMSG_CHAR_ENUM));
            query.Append(string.Format("{0},", CMSG_CHAR_RENAME));
            query.Append(string.Format("{0},", CMSG_CREATURE_QUERY));
            query.Append(string.Format("{0},", CMSG_DISMISS_CONTROLLED_VEHICLE));
            query.Append(string.Format("{0},", CMSG_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_FLIGHT_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_RUN_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_SWIM_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_TURN_RATE_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_FORCE_WALK_SPEED_CHANGE_ACK));
            query.Append(string.Format("{0},", CMSG_GMTICKET_GETTICKET));
            query.Append(string.Format("{0},", CMSG_GOSSIP_HELLO));
            query.Append(string.Format("{0},", CMSG_GOSSIP_SELECT_OPTION));
            query.Append(string.Format("{0},", CMSG_HEARTH_AND_RESURRECT));
            query.Append(string.Format("{0},", CMSG_ITEM_QUERY_SINGLE));
            query.Append(string.Format("{0},", CMSG_KEEP_ALIVE));
            query.Append(string.Format("{0},", CMSG_LFD_PARTY_LOCK_INFO_REQUEST));
            query.Append(string.Format("{0},", CMSG_LFD_PLAYER_LOCK_INFO_REQUEST));
            query.Append(string.Format("{0},", CMSG_LIST_INVENTORY));
            query.Append(string.Format("{0},", CMSG_LOGOUT_CANCEL));
            query.Append(string.Format("{0},", CMSG_LOGOUT_REQUEST));
            query.Append(string.Format("{0},", CMSG_MEETINGSTONE_INFO));
            query.Append(string.Format("{0},", CMSG_MOUNTSPECIAL_ANIM));
            query.Append(string.Format("{0},", CMSG_MOVE_CHNG_TRANSPORT));
            query.Append(string.Format("{0},", CMSG_MOVE_FALL_RESET));
            query.Append(string.Format("{0},", CMSG_MOVE_HOVER_ACK));
            query.Append(string.Format("{0},", CMSG_MOVE_KNOCK_BACK_ACK));
            query.Append(string.Format("{0},", CMSG_MOVE_NOT_ACTIVE_MOVER));
            query.Append(string.Format("{0},", CMSG_MOVE_SET_FLY));
            query.Append(string.Format("{0},", CMSG_MOVE_WATER_WALK_ACK));
            query.Append(string.Format("{0},", CMSG_NAME_QUERY));
            query.Append(string.Format("{0},", CMSG_NPC_TEXT_QUERY));
            query.Append(string.Format("{0},", CMSG_PAGE_TEXT_QUERY));
            query.Append(string.Format("{0},", CMSG_PING));
            query.Append(string.Format("{0},", CMSG_PLAYER_LOGIN));
            query.Append(string.Format("{0},", CMSG_PLAYER_LOGOUT));
            query.Append(string.Format("{0},", CMSG_QUERY_INSPECT_ACHIEVEMENTS));
            query.Append(string.Format("{0},", CMSG_QUERY_TIME));
            query.Append(string.Format("{0},", CMSG_QUEST_POI_QUERY));
            query.Append(string.Format("{0},", CMSG_QUEST_QUERY));
            query.Append(string.Format("{0},", CMSG_READY_FOR_ACCOUNT_DATA_TIMES));
            query.Append(string.Format("{0},", CMSG_REALM_SPLIT));
            query.Append(string.Format("{0},", CMSG_REDIRECTION_AUTH_PROOF));
            query.Append(string.Format("{0},", CMSG_REDIRECTION_FAILED));
            query.Append(string.Format("{0},", CMSG_REQUEST_ACCOUNT_DATA));
            query.Append(string.Format("{0},", CMSG_REQUEST_RAID_INFO));
            query.Append(string.Format("{0},", CMSG_SET_ACTIVE_MOVER));
            query.Append(string.Format("{0},", CMSG_SPIRIT_HEALER_ACTIVATE));
            query.Append(string.Format("{0},", CMSG_SUMMON_RESPONSE));
            query.Append(string.Format("{0},", CMSG_TRAINER_LIST));
            query.Append(string.Format("{0},", CMSG_TUTORIAL_CLEAR));
            query.Append(string.Format("{0},", CMSG_TUTORIAL_FLAG));
            query.Append(string.Format("{0},", CMSG_TUTORIAL_RESET));
            query.Append(string.Format("{0},", CMSG_UPDATE_ACCOUNT_DATA));
            query.Append(string.Format("{0},", CMSG_UPDATE_PROJECTILE_POSITION));
            query.Append(string.Format("{0},", CMSG_WORLD_STATE_UI_TIMER_UPDATE));
            query.Append(string.Format("{0},", MSG_MOVE_FALL_LAND));
            query.Append(string.Format("{0},", MSG_MOVE_HEARTBEAT));
            query.Append(string.Format("{0},", MSG_MOVE_JUMP));
            query.Append(string.Format("{0},", MSG_MOVE_SET_FACING));
            query.Append(string.Format("{0},", MSG_MOVE_SET_PITCH));
            query.Append(string.Format("{0},", MSG_MOVE_SET_RUN_MODE));
            query.Append(string.Format("{0},", MSG_MOVE_SET_WALK_MODE));
            query.Append(string.Format("{0},", MSG_MOVE_START_ASCEND));
            query.Append(string.Format("{0},", MSG_MOVE_START_BACKWARD));
            query.Append(string.Format("{0},", MSG_MOVE_START_DESCEND));
            query.Append(string.Format("{0},", MSG_MOVE_START_FORWARD));
            query.Append(string.Format("{0},", MSG_MOVE_START_PITCH_DOWN));
            query.Append(string.Format("{0},", MSG_MOVE_START_PITCH_UP));
            query.Append(string.Format("{0},", MSG_MOVE_START_STRAFE_LEFT));
            query.Append(string.Format("{0},", MSG_MOVE_START_STRAFE_RIGHT));
            query.Append(string.Format("{0},", MSG_MOVE_START_SWIM));
            query.Append(string.Format("{0},", MSG_MOVE_START_TURN_LEFT));
            query.Append(string.Format("{0},", MSG_MOVE_START_TURN_RIGHT));
            query.Append(string.Format("{0},", MSG_MOVE_STOP));
            query.Append(string.Format("{0},", MSG_MOVE_STOP_ASCEND));
            query.Append(string.Format("{0},", MSG_MOVE_STOP_PITCH));
            query.Append(string.Format("{0},", MSG_MOVE_STOP_STRAFE));
            query.Append(string.Format("{0},", MSG_MOVE_STOP_SWIM));
            query.Append(string.Format("{0},", MSG_MOVE_STOP_TURN));
            query.Append(string.Format("{0},", MSG_MOVE_TELEPORT));
            query.Append(string.Format("{0},", MSG_MOVE_TELEPORT_ACK));
            query.Append(string.Format("{0},", MSG_MOVE_WORLDPORT_ACK));
            query.Append(string.Format("{0},", MSG_SET_DUNGEON_DIFFICULTY));
            query.Append(string.Format("{0},", MSG_SET_RAID_DIFFICULTY));
            query.Append(string.Format("{0},", MSG_TABARDVENDOR_ACTIVATE));
            query.Append(string.Format("{0},", SMSG_ACCOUNT_DATA_TIMES));
            query.Append(string.Format("{0},", SMSG_ACHIEVEMENT_DELETED));
            query.Append(string.Format("{0},", SMSG_ACHIEVEMENT_EARNED));
            query.Append(string.Format("{0},", SMSG_ALL_ACHIEVEMENT_DATA));
            query.Append(string.Format("{0},", SMSG_AURA_UPDATE));
            query.Append(string.Format("{0},", SMSG_AURA_UPDATE_ALL));
            query.Append(string.Format("{0},", SMSG_AUTH_CHALLENGE));
            query.Append(string.Format("{0},", SMSG_AUTH_RESPONSE));
            query.Append(string.Format("{0},", SMSG_BARBER_SHOP_RESULT));
            query.Append(string.Format("{0},", SMSG_BINDPOINTUPDATE));
            query.Append(string.Format("{0},", SMSG_CHAR_CREATE));
            query.Append(string.Format("{0},", SMSG_CHAR_CUSTOMIZE));
            query.Append(string.Format("{0},", SMSG_CHAR_DELETE));
            query.Append(string.Format("{0},", SMSG_CHAR_ENUM));
            query.Append(string.Format("{0},", SMSG_CHAR_RENAME));
            query.Append(string.Format("{0},", SMSG_CHARACTER_LOGIN_FAILED));
            query.Append(string.Format("{0},", SMSG_CLIENTCACHE_VERSION));
            query.Append(string.Format("{0},", SMSG_COMPRESSED_MOVES));
            query.Append(string.Format("{0},", SMSG_COMSAT_CONNECT_FAIL));
            query.Append(string.Format("{0},", SMSG_COMSAT_DISCONNECT));
            query.Append(string.Format("{0},", SMSG_COMSAT_RECONNECT_TRY));
            query.Append(string.Format("{0},", SMSG_CREATURE_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_CRITERIA_DELETED));
            query.Append(string.Format("{0},", SMSG_CRITERIA_UPDATE));
            query.Append(string.Format("{0},", SMSG_DESTROY_OBJECT));
            query.Append(string.Format("{0},", SMSG_FEATURE_SYSTEM_STATUS));
            query.Append(string.Format("{0},", SMSG_FLIGHT_SPLINE_SYNC));
            query.Append(string.Format("{0},", SMSG_FORCE_MOVE_ROOT));
            query.Append(string.Format("{0},", SMSG_FORCE_MOVE_UNROOT));
            query.Append(string.Format("{0},", SMSG_FORCE_SEND_QUEUED_PACKETS));
            query.Append(string.Format("{0},", SMSG_GAMEOBJECT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_GOSSIP_COMPLETE));
            query.Append(string.Format("{0},", SMSG_GOSSIP_MESSAGE));
            query.Append(string.Format("{0},", SMSG_GOSSIP_POI));
            query.Append(string.Format("{0},", SMSG_INITIAL_SPELLS));
            query.Append(string.Format("{0},", SMSG_INITIALIZE_FACTIONS));
            query.Append(string.Format("{0},", SMSG_INSTANCE_DIFFICULTY));
            query.Append(string.Format("{0},", SMSG_INSTANCE_RESET));
            query.Append(string.Format("{0},", SMSG_ITEM_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_QUERY_MULTIPLE_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_QUERY_SINGLE_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_TEXT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_KICK_REASON));
            query.Append(string.Format("{0},", SMSG_LEARNED_DANCE_MOVES));
            query.Append(string.Format("{0},", SMSG_LEARNED_SPELL));
            query.Append(string.Format("{0},", SMSG_LEVELUP_INFO));
            query.Append(string.Format("{0},", SMSG_LFG_DISABLED));
            query.Append(string.Format("{0},", SMSG_LIST_INVENTORY));
            query.Append(string.Format("{0},", SMSG_LOGIN_SETTIMESPEED));
            query.Append(string.Format("{0},", SMSG_LOGOUT_CANCEL_ACK));
            query.Append(string.Format("{0},", SMSG_LOGOUT_COMPLETE));
            query.Append(string.Format("{0},", SMSG_LOGOUT_RESPONSE));
            query.Append(string.Format("{0},", SMSG_MONSTER_MOVE));
            query.Append(string.Format("{0},", SMSG_MONSTER_MOVE_TRANSPORT));
            query.Append(string.Format("{0},", SMSG_MOTD));
            query.Append(string.Format("{0},", SMSG_MOUNTSPECIAL_ANIM));
            query.Append(string.Format("{0},", SMSG_MOVE_LAND_WALK));
            query.Append(string.Format("{0},", SMSG_MOVE_UNKNOWN_1302));
            query.Append(string.Format("{0},", SMSG_MOVE_UNKNOWN_1304));
            query.Append(string.Format("{0},", SMSG_MOVE_WATER_WALK));
            query.Append(string.Format("{0},", SMSG_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_NPC_TEXT_UPDATE));
            query.Append(string.Format("{0},", SMSG_PAGE_TEXT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_PET_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_PLAY_MUSIC));
            query.Append(string.Format("{0},", SMSG_PLAY_OBJECT_SOUND));
            query.Append(string.Format("{0},", SMSG_PLAY_SOUND));
            query.Append(string.Format("{0},", SMSG_PLAYER_DIFFICULTY_CHANGE));
            query.Append(string.Format("{0},", SMSG_PONG));
            query.Append(string.Format("{0},", SMSG_POWER_UPDATE));
            query.Append(string.Format("{0},", SMSG_QUERY_TIME_RESPONSE));
            query.Append(string.Format("{0},", SMSG_QUEST_FORCE_REMOVE));
            query.Append(string.Format("{0},", SMSG_QUEST_POI_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_QUEST_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_QUESTGIVER_OFFER_REWARD));
            query.Append(string.Format("{0},", SMSG_QUESTGIVER_QUEST_DETAILS));
            query.Append(string.Format("{0},", SMSG_QUESTGIVER_REQUEST_ITEMS));
            query.Append(string.Format("{0},", SMSG_QUESTLOG_FULL));
            query.Append(string.Format("{0},", SMSG_REALM_SPLIT));
            query.Append(string.Format("{0},", SMSG_REDIRECT_CLIENT));
            query.Append(string.Format("{0},", SMSG_RESET_FAILED_NOTIFY));
            query.Append(string.Format("{0},", SMSG_RESPOND_INSPECT_ACHIEVEMENTS));
            query.Append(string.Format("{0},", SMSG_SEND_UNLEARN_SPELLS));
            query.Append(string.Format("{0},", SMSG_SERVER_FIRST_ACHIEVEMENT));
            query.Append(string.Format("{0},", SMSG_SET_PROJECTILE_POSITION));
            query.Append(string.Format("{0},", SMSG_SPELL_GO));
            query.Append(string.Format("{0},", SMSG_SPELL_START));
            query.Append(string.Format("{0},", SMSG_TIME_SYNC_REQ));
            query.Append(string.Format("{0},", SMSG_TRAINER_LIST));
            query.Append(string.Format("{0},", SMSG_TRIGGER_CINEMATIC));
            query.Append(string.Format("{0},", SMSG_TRIGGER_MOVIE));
            query.Append(string.Format("{0},", SMSG_TUTORIAL_FLAGS));
            query.Append(string.Format("{0},", SMSG_UNIT_SPELLCAST_START));
            query.Append(string.Format("{0},", SMSG_UNKNOWN_1276));
            query.Append(string.Format("{0},", SMSG_UPDATE_ACCOUNT_DATA));
            query.Append(string.Format("{0},", SMSG_UPDATE_ACCOUNT_DATA_COMPLETE));
            query.Append(string.Format("{0},", SMSG_UPDATE_ITEM_ENCHANTMENTS));
            query.Append(string.Format("{0},", SMSG_UPDATE_WORLD_STATE));
            query.Append(string.Format("{0},", SMSG_VOICESESSION_FULL));
            query.Append(string.Format("{0}", SMSG_WEATHER));
            query.Append(")");

            var directoryinfo = new System.IO.DirectoryInfo(@"E:\HFS\WOWDEV\SNIFFS_CLEAN\");

            var directories = directoryinfo.GetDirectories().OrderByDescending(t => t.Name.IntValueOrZero());

            foreach (var dir in directories)
            {
                var files = dir.GetFiles("*.sqlite").OrderBy(t => t.Name);

                foreach (var file in files)
                {
                    ProcessFile(file, query.ToString());
                }
            }

            MaximusParserX.Dump.SQL.GossipHandler.DumpToSQLFile();
            MaximusParserX.Dump.SQL.QueryResponseHandler.DumpToSQLFile();
        }
        private void DumpGossipData()
        {
            var CMSG_GOSSIP_HELLO = 0x17B;
            var CMSG_GOSSIP_SELECT_OPTION = 0x17C;
            var SMSG_GOSSIP_MESSAGE = 0x17D;
            var SMSG_GOSSIP_COMPLETE = 0x17E;
            var SMSG_GOSSIP_POI = 0x224;
            var SMSG_ITEM_QUERY_SINGLE_RESPONSE = 0x058;
            var SMSG_ITEM_NAME_QUERY_RESPONSE = 0x2C5;
            var SMSG_GAMEOBJECT_QUERY_RESPONSE = 0x05F;
            var SMSG_CREATURE_QUERY_RESPONSE = 0x061;
            var SMSG_ITEM_TEXT_QUERY_RESPONSE = 0x244;
            var SMSG_ITEM_QUERY_MULTIPLE_RESPONSE = 0x059;
            var SMSG_NAME_QUERY_RESPONSE = 0x051;
            var SMSG_NPC_TEXT_UPDATE = 0x180;
            var SMSG_PAGE_TEXT_QUERY_RESPONSE = 0x05B;
            var SMSG_PET_NAME_QUERY_RESPONSE = 0x053;
            var SMSG_QUEST_POI_QUERY_RESPONSE = 0x1E4;

            var query = GetBaseOpcodeQuery(false);

            query.Append(string.Format("{0},", CMSG_GOSSIP_HELLO));
            query.Append(string.Format("{0},", CMSG_GOSSIP_SELECT_OPTION));
            query.Append(string.Format("{0},", SMSG_GOSSIP_MESSAGE));
            query.Append(string.Format("{0},", SMSG_GOSSIP_POI));
            query.Append(string.Format("{0},", SMSG_GOSSIP_COMPLETE));
            query.Append(string.Format("{0},", SMSG_ITEM_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_QUERY_MULTIPLE_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_QUERY_SINGLE_RESPONSE));
            query.Append(string.Format("{0},", SMSG_GAMEOBJECT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_ITEM_TEXT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_PAGE_TEXT_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_PET_NAME_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_QUEST_POI_QUERY_RESPONSE));
            query.Append(string.Format("{0},", SMSG_NPC_TEXT_UPDATE));
            query.Append(string.Format("{0}", SMSG_CREATURE_QUERY_RESPONSE));
            query.Append(")");

            var directoryinfo = new System.IO.DirectoryInfo(@"E:\HFS\WOWDEV\SNIFFS_CLEAN\");

            var directories = directoryinfo.GetDirectories().OrderByDescending(t => t.Name.IntValueOrZero());

            foreach (var dir in directories)
            {
                var files = dir.GetFiles("*.sqlite").OrderBy(t => t.Name);

                foreach (var file in files)
                {
                    ProcessFile(file, query.ToString());
                }
            }

            MaximusParserX.Dump.SQL.GossipHandler.DumpToSQLFile();
            MaximusParserX.Dump.SQL.QueryResponseHandler.DumpToSQLFile();
        }

        private void DumpInstanceData()
        {
            var SMSG_PLAY_SOUND = 0x2D2;

            var query = GetBaseOpcodeQuery(false);
            query.Append(string.Format("{0},", SMSG_PLAY_SOUND));
            query.Append(")");

            ProcessFile(new System.IO.FileInfo(@"E:\HFS\WOWDEV\SNIFFS_CLEAN\9835\2009-05-08-13-37_9835_MIHASYA.sqlite"), query.ToString());
        }

        private void DumpGameObjectSpawnData()
        {
            var query = GetBaseOpcodeQuery();

            var directoryinfo = new System.IO.DirectoryInfo(@"E:\HFS\WOWDEV\SNIFFS_CLEAN\");

            var directories = directoryinfo.GetDirectories().OrderByDescending(t => t.Name.IntValueOrZero());

            foreach (var dir in directories)
            {
                var files = dir.GetFiles("*.sqlite").OrderBy(t => t.Name);

                foreach (var file in files)
                {
                    ProcessFile(file, query.ToString());
                }
            }

            MaximusParserX.Dump.SQL.GameObjectSpawnHandler.DumpToSQLFile();
        }

        private System.Text.StringBuilder GetBaseOpcodeQuery()
        {
            return GetBaseOpcodeQuery(true);
        }

        private System.Text.StringBuilder GetBaseOpcodeQuery(bool baseonly)
        {
            var SMSG_COMPRESSED_UPDATE_OBJECT = 0x1F6;
            var SMSG_UPDATE_OBJECT = 0x0A9;
            var SMSG_SET_PHASE_SHIFT = 0x47C;
            var SMSG_TRANSFER_PENDING = 0x03F;
            var SMSG_TRANSFER_ABORTED = 0x040;
            var SMSG_NEW_WORLD = 0x03E;
            var SMSG_LOGIN_VERIFY_WORLD = 0x236;
            var SMSG_INIT_WORLD_STATES = 0x2C2;
            var SMSG_RAID_INSTANCE_MESSAGE = 0x2FA;

            var query = new StringBuilder();

            query.Append(" AND opcode in(");
            query.Append(string.Format("{0},", SMSG_COMPRESSED_UPDATE_OBJECT));
            query.Append(string.Format("{0},", SMSG_UPDATE_OBJECT));
            query.Append(string.Format("{0},", SMSG_SET_PHASE_SHIFT));
            query.Append(string.Format("{0},", SMSG_TRANSFER_PENDING));
            query.Append(string.Format("{0},", SMSG_TRANSFER_ABORTED));
            query.Append(string.Format("{0},", SMSG_NEW_WORLD));
            query.Append(string.Format("{0},", SMSG_LOGIN_VERIFY_WORLD));
            query.Append(string.Format("{0},", SMSG_INIT_WORLD_STATES));
            query.Append(string.Format("{0}", SMSG_RAID_INSTANCE_MESSAGE));
            if (baseonly) query.Append(")"); else query.Append(",");
            return query;
        }

        private void ProcessFile(System.IO.FileInfo file, string query)
        {
            using (var reader = new Reading.Readers.TiawpsReader(UIManager.DelegateManager, file.FullName))
            {
                var core = new WoW.Core(UIManager.DelegateManager, reader.ClientBuildAmount);

                reader.Load(query);

                while (true)
                {
                    var packet = reader.GetNextPacket();

                    if (packet == null) break;

                    var context = new Reading.DefinitionContext(packet, reader, core);

                    var definition = context.GetDefinition();

                    //((Reading.ReadingBase)definition).LogToFieldLog = true;

                    definition.Parse();
                }

                reader.Close();
            }
        }

        private void btnRunMangosTableCodeGenerator_Click(object sender, EventArgs e)
        {
            CodeGenerator.MangosTableCodeGenerator.GenerateCode(true);
        }

    }
}
