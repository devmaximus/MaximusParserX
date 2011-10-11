using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL
{
    public static class GossipHandler
    {
        public static IDictionary<string, Custom.gossip_menu> GossipMenuList = new Dictionary<string, Custom.gossip_menu>();
        public static IDictionary<string, Custom.gossip_poi> GossipPOIList = new Dictionary<string, Custom.gossip_poi>();
 
        public static List<string> DumpToSQLFile()
        {
            var result = new List<string>();

            result.Add(DumpGossipMenu());
            result.Add(DumpGossipPOI());

            GossipMenuList.Clear();
            GossipPOIList.Clear();

            return result;
        }

        public static string DumpGossipMenu()
        {
            var file = "GossipMenuLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            var gossip_menus = GossipMenuList.OrderByDescending(t => t.Key);
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var gossip_menu in gossip_menus)
                {
                    sw.WriteLine(gossip_menu.Value.GetDeleteCommand());
                    sw.WriteLine(gossip_menu.Value.GetInsertCommand());
                    if (gossip_menu.Value.creature_template != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine(gossip_menu.Value.creature_template.GetUpdateCommand());
                    }
                    
                    if (gossip_menu.Value.gossip_menu_options != null && gossip_menu.Value.gossip_menu_options.Any())
                    {
                        sw.WriteLine();

                        sw.WriteLine(gossip_menu.Value.gossip_menu_options.First().Value.GetDeleteCommand());

                        foreach (var gossip_menu_option in gossip_menu.Value.gossip_menu_options)
                        {
                            sw.WriteLine(gossip_menu_option.Value.GetInsertCommand());
                        }
                    }
                    sw.WriteLine();
                }
            }

            return file;
        }

        public static string DumpGossipPOI()
        {
            var file = "GossipPOILog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            var items = GossipPOIList.OrderByDescending(t => t.Key);
            using (var sw = new System.IO.StreamWriter(file))
            {
                foreach (var item in items)
                {
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }
            return file;
        }
    }
}
