using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.CodeGenerator
{
    public class MangosTableCodeGenerator : Data.MySQLDBBase
    {
        public MangosTableCodeGenerator(string connstr)
            : base(connstr)
        {
        }

        public static string GetMangosConnectionString
        {
            get
            {
                return GetConnectionString("mangosDBServer", 3306, "mangos", "root", "root");
            }
        }

        public static void GenerateCode(bool all)
        {
            var dest = @".\CodeGenerator\Mangos\";

            if (!System.IO.Directory.Exists(dest)) System.IO.Directory.CreateDirectory(dest);

            string template = System.IO.File.ReadAllText(@".\CodeGenerator\MangosTableCodeGeneratorTemplate.txt");

            if (all)
            {
                var t = new MangosTableCodeGenerator(GetMangosConnectionString);

                var tables = t.GetTables();

                foreach (string table in tables)
                {
                    GenerateCodeForTable(table, template, dest);
                }
            }
            else
            {
                GenerateCodeForTable("creature_template", template, dest);
                GenerateCodeForTable("creature_equip_template", template, dest);
                GenerateCodeForTable("creature_template_addon", template, dest);
                GenerateCodeForTable("quest_template", template, dest);
                GenerateCodeForTable("item_template", template, dest);
                GenerateCodeForTable("gameobject_template", template, dest);
                GenerateCodeForTable("npc_text", template, dest);
                GenerateCodeForTable("npc_trainer", template, dest);
                GenerateCodeForTable("npc_vendor", template, dest);
                GenerateCodeForTable("npc_spellclick_spells", template, dest);
                GenerateCodeForTable("creature", template, dest);
                GenerateCodeForTable("creature_addon", template, dest);
                GenerateCodeForTable("creature_model_info", template, dest);
                GenerateCodeForTable("creature_movement", template, dest);
                GenerateCodeForTable("creature_questrelation", template, dest);
                GenerateCodeForTable("creature_involvedrelation", template, dest);
                GenerateCodeForTable("gameobject", template, dest);
                GenerateCodeForTable("gossip_menu", template, dest);
                GenerateCodeForTable("gossip_menu_option", template, dest);
                GenerateCodeForTable("quest_poi", template, dest);
                GenerateCodeForTable("quest_poi_points", template, dest);
            }
        }

        public static void GenerateCodeForTable(string tablename, string templatetext, string destination)
        {
            var template = templatetext.Replace("[TABLE]", tablename.ToLower());

            using (var sw = new System.IO.StreamWriter(destination + tablename + ".cs"))
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(GetMangosConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format("select * from {0} limit 1", tablename);

                    try
                    {
                        var sb_object = new StringBuilder();
                        var sb_Insert_part1 = new StringBuilder();
                        var sb_Insert_part2 = new StringBuilder();
                        var sb_Insert_part3 = new StringBuilder();
                        var sb_Update = new StringBuilder();
                        var sb_Delete = new StringBuilder();

                        sb_Insert_part1.Append("INSERT IGNORE INTO `\" + TableName + \"` (");
                        sb_Insert_part2.Append(" VALUES (");
                        sb_Insert_part3.Append("\", ");

                        sb_Update.AppendLine("\t\t\tsb.Append(\"UPDATE `\" + TableName + \"` SET \");");

                        using (var dr = command.ExecuteReader())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                string fieldname = dr.GetName(i).ToLower();
                                string valuename = fieldname;

                                if (valuename == "class") { valuename = "class_"; }
                                if (valuename == "event") { valuename = "event_"; }

                                if (i != 0)
                                {
                                    sb_Update.AppendLine("\t\t\tif(" + valuename + " != null)");
                                    sb_Update.AppendLine("\t\t\t{");
                                    if (dr.GetFieldType(i) == typeof(System.String))
                                    {
                                        sb_Update.AppendLine("\t\t\t\tsb.AppendLine(\"`" + fieldname + "`='\" + " + valuename + ".ToSQL() + \"'\");");
                                    }
                                    else if (dr.GetFieldType(i) == typeof(System.Single))
                                    {
                                        sb_Update.AppendLine("\t\t\t\tsb.AppendLine(\"`" + fieldname + "`='\" + ((Decimal)" + valuename + ".Value).ToString() + \"'\");");
                                    }
                                    else
                                    {
                                        sb_Update.AppendLine("\t\t\t\tsb.AppendLine(\"`" + fieldname + "`='\" + " + valuename + ".Value.ToString() + \"'\");");
                                    }
                                    sb_Update.AppendLine("\t\t\t}");
                                }

                                if (i == dr.FieldCount - 1)
                                {
                                    sb_Insert_part1.Append("`" + fieldname + "`{" + (i + 1).ToString() + "})");
                                    sb_Insert_part2.Append("'{" + i.ToString() + "}'{" + (i + 2).ToString() + "});");
                                    if (dr.GetFieldType(i) == typeof(System.String))
                                    {
                                        sb_Insert_part3.Append(valuename + ".ToSQL(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());");
                                    }
                                    else if (dr.GetFieldType(i) == typeof(System.Single))
                                    {
                                        sb_Insert_part3.Append("((Decimal)" + valuename + ".GetValueOrDefault()), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());");
                                    }
                                    else
                                    {
                                        sb_Insert_part3.Append(valuename + ".GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());");
                                    }
                                }
                                else
                                {
                                    sb_Insert_part1.Append(string.Format("`{0}`, ", fieldname));
                                    sb_Insert_part2.Append("'{" + i.ToString() + "}', ");

                                    if (dr.GetFieldType(i) == typeof(System.String))
                                    {
                                        sb_Insert_part3.Append(valuename + ".ToSQL(), ");
                                    }
                                    else if (dr.GetFieldType(i) == typeof(System.Single))
                                    {
                                        sb_Insert_part3.Append("((Decimal)" + valuename + ".GetValueOrDefault()), ");
                                    }
                                    else
                                    {
                                        sb_Insert_part3.Append(valuename + ".GetValueOrDefault(), ");
                                    }
                                }

                                if (dr.GetFieldType(i) == typeof(System.String))
                                {
                                    sb_object.AppendLine(string.Format("\t\tpublic {0} {1};", dr.GetFieldType(i), valuename));
                                }
                                else
                                {
                                    sb_object.AppendLine(string.Format("\t\tpublic {0}? {1};", dr.GetFieldType(i), valuename));
                                }
                            }
                            string idvaluename = dr.GetName(0).ToLower();

                            if (idvaluename == "class") { idvaluename = "class_"; }
                            if (idvaluename == "event") { idvaluename = "event_"; }
                            sb_Update.AppendLine("\t\t\t\tsb = sb.Replace(\"\\r\\n\", \", \");");
                            sb_Update.AppendLine("\t\t\t\tsb.Append(\" WHERE `" + dr.GetName(0).ToLower() + "`='\" + " + idvaluename + ".Value.ToString() + \"';\");");
                            sb_Update.AppendLine("\t\t\t\tsb = sb.Replace(\",  WHERE\", \" WHERE\");");
                            sb_Delete.Append(" `" + dr.GetName(0).ToLower() + "`='\" + " + idvaluename + ".Value.ToString() + \"';\"");
                        }

                        template = template.Replace("[FIELDS]", sb_object.ToString());
                        template = template.Replace("[INSERT]", sb_Insert_part1.ToString() + sb_Insert_part2.ToString() + sb_Insert_part3.ToString());
                        template = template.Replace("[UPDATE]", sb_Update.ToString());
                        template = template.Replace("[DELETE]", sb_Delete.ToString());

                        sw.Write(template);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Error: {0}, {1}", exc.Message, command.CommandText);
                    }
                }
            }
        }
    }
}


