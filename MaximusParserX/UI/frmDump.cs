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

            DumpGossipData();
            //DumpInstanceData();
            //DumpGameObjectSpawnData();
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
