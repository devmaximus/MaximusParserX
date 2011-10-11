using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL
{
    public static class QueryResponseHandler
    {
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.creature_template> CreatureTemplateList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.creature_template>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.quest_template> QuestTemplateList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.quest_template>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.creature_equip_template> CreatureEquipTemplateList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.creature_equip_template>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.gameobject_template> GameObjectTemplateList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.gameobject_template>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.item_template> ItemTemplateList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.item_template>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.npc_text> NPCTextList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.npc_text>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.page_text> PageTextList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.page_text>();
        public static readonly IDictionary<string, MaximusParserX.Dump.SQL.Custom.quest_poi> QuestPOIList = new Dictionary<string, MaximusParserX.Dump.SQL.Custom.quest_poi>();

        public static List<string> DumpToSQLFile()
        {
            var result = new List<string>();

            result.Add(DumpCreatureTemplateInsert());
            result.Add(DumpQuestTemplateInsert());
            result.Add(DumpCreatureEquipTemplateInsert());
            result.Add(DumpGameObjectTemplateInsert());
            result.Add(DumpItemTemplateInsert());
            result.Add(DumpNPCTextInsert());
            result.Add(DumpPageTextInsert());
            result.Add(DumpQuestPOIInsert());

            CreatureTemplateList.Clear();
            QuestTemplateList.Clear();
            CreatureEquipTemplateList.Clear();
            GameObjectTemplateList.Clear();
            ItemTemplateList.Clear();
            NPCTextList.Clear();
            PageTextList.Clear();
            QuestPOIList.Clear();

            return result;
        }

        public static void AddQuestTemplate(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.quest_template quest_template)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, quest_template.entry);
            if (!Dump.SQL.QueryResponseHandler.QuestTemplateList.ContainsKey(key))
            {
                quest_template.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.QuestTemplateList.Add(key, quest_template);
            }
        }

        public static void AddCreatureTemplate(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.creature_template creature_template)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, creature_template.entry);
            if (!Dump.SQL.QueryResponseHandler.CreatureTemplateList.ContainsKey(key))
            {
                creature_template.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.CreatureTemplateList.Add(key, creature_template);
            }
        }

        public static void AddItemTemplate(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.item_template item_template)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, item_template.entry);
        
            if (!Dump.SQL.QueryResponseHandler.ItemTemplateList.ContainsKey(key))
            {
                item_template.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.ItemTemplateList.Add(key, item_template);
            }
        }

        public static void AddNPCText(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.npc_text npc_text)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, npc_text.id);
            if (!Dump.SQL.QueryResponseHandler.NPCTextList.ContainsKey(key))
            {
                npc_text.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.NPCTextList.Add(key, npc_text);
            }
        }

        public static void AddPageText(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.page_text page_text)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, page_text.entry);
            if (!Dump.SQL.QueryResponseHandler.NPCTextList.ContainsKey(key))
            {
                page_text.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.PageTextList.Add(key, page_text);
            }
        }

        public static void AddGameObjectTemplate(int clientbuildamount, MaximusParserX.Dump.SQL.Custom.gameobject_template gameobject_template)
        {

            var key = string.Format("{0}_{1}", clientbuildamount, gameobject_template.entry);
            if (!Dump.SQL.QueryResponseHandler.GameObjectTemplateList.ContainsKey(key))
            {
                gameobject_template.clientbuild = clientbuildamount;
                Dump.SQL.QueryResponseHandler.GameObjectTemplateList.Add(key, gameobject_template);
            }
        }

        public static string DumpQuestPOIInsert()
        {
            if (QuestPOIList.Count == 0) return string.Empty;
            var file = "QuestPOILog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            var quest_pois = QuestPOIList.OrderByDescending(t => t.Key);
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var quest_poi in quest_pois)
                {
                    sw.WriteLine(quest_poi.Value.GetDeleteCommand());
                    sw.WriteLine(quest_poi.Value.GetInsertCommand());


                    if (quest_poi.Value.quest_poi_points != null && quest_poi.Value.quest_poi_points.Any())
                    {
                        sw.WriteLine();

                        sw.WriteLine(quest_poi.Value.quest_poi_points.First().Value.GetDeleteCommand());

                        foreach (var quest_poi_point in quest_poi.Value.quest_poi_points)
                        {
                            sw.WriteLine(quest_poi_point.Value.GetInsertCommand());
                        }
                    }
                    sw.WriteLine();
                }
            }

            return file;
        }
        public static string DumpPageTextInsert()
        {
            if (PageTextList.Count == 0) return string.Empty;
            var file = "PageTextInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in PageTextList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t => t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpNPCTextInsert()
        {
            if (NPCTextList.Count == 0) return string.Empty;
            var file = "NPCTextInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in NPCTextList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t => t.Value.id))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpItemTemplateInsert()
        {
            if (ItemTemplateList.Count == 0) return string.Empty;
            var file = "ItemTemplateInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in ItemTemplateList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t=> t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpCreatureTemplateInsert()
        {
            if (CreatureTemplateList.Count == 0) return string.Empty;
            var file = "CreatureTemplateInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in CreatureTemplateList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t => t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpQuestTemplateInsert()
        {
            if (QuestTemplateList.Count == 0) return string.Empty;
            var file = "QuestTemplateInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in QuestTemplateList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t => t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpCreatureEquipTemplateInsert()
        {
            if (CreatureEquipTemplateList.Count == 0) return string.Empty;
            var file = "CreatureEquipTemplateInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in CreatureEquipTemplateList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t=> t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }

        public static string DumpGameObjectTemplateInsert()
        {
            if (GameObjectTemplateList.Count == 0) return string.Empty;
            var file = "GameObjectTemplateInsertLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in GameObjectTemplateList.OrderByDescending(t => t.Value.clientbuild).ThenBy(t => t.Value.entry))
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }
    }
}
