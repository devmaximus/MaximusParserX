using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.UI;
using MaximusParserX.Frame;
 
namespace MaximusParserX.Local
{
    public class Settings
    {
        private const string SettingsXmlFile = "Settings.xml";
        private const string SettingsXmlFileBackup = "SettingsBackUp_{0}.xml";

        public Settings()
        {
        }

        public Settings(bool isnew)
        {
            if (isnew)
            {
                //initialize defaults
                this.SniffDirectoryList = new List<SniffDirectory>();
                this.SniffCacheList = new List<SniffCache>();
               // this.SniffDirectoryList.Add(new SniffDirectory() { Directory = @"E:\HFS\WOWDEV\SNIFFS_CLEAN\", Include = true, SearchPattern = "*.sqlite" , Recursive = true});
            }
        }

        public List<SniffDirectory> SniffDirectoryList { get; set; }
        public List<SniffCache> SniffCacheList { get; set; }

        public static Settings Load(DelegateManager delegateManager)
        {
            delegateManager.AddResult(Result.NewInfo("Loading Settings...."));

            Settings settings = null;

            if (System.IO.File.Exists(SettingsXmlFile))
            {
                try
                {
                    settings = System.IO.File.ReadAllText(SettingsXmlFile).FromXML<Settings>();
                }
                catch (Exception exc)
                {
                    var backUpFileName = string.Format(SettingsXmlFileBackup, Guid.NewGuid());

                    System.IO.File.Move(SettingsXmlFileBackup, backUpFileName);

                    delegateManager.AddResult(Result.NewCritical(string.Format("Error Loading Settings: {0}. Settings file was backed up to {0}.", exc.Message, backUpFileName)));
                }
            }

            if (settings == null)
            {
                delegateManager.AddResult(Result.NewInfo("Initializing new Settings."));

                settings = new Settings(true);
            }

            delegateManager.AddResult(Result.NewInfo("Loading Settings Completed!"));

            return settings;
        }

        public void Save(DelegateManager delegateManager)
        {
            var xml = this.ToXml();

            try
            {
                delegateManager.AddResult(Result.NewInfo("Saving Settings...."));
                System.IO.File.WriteAllText(SettingsXmlFile, xml);
                delegateManager.AddResult(Result.NewInfo("Saved Settings!"));
            }
            catch (Exception exc)
            {
                var backUpFileName = string.Format(SettingsXmlFileBackup, Guid.NewGuid());

                System.IO.File.WriteAllText(backUpFileName, xml);

                delegateManager.AddResult(Result.NewCritical(string.Format("Error Saving Settings: {0}. Settings file was backed up to {0}.", exc.Message, backUpFileName)));
            }
        }
    }
}
