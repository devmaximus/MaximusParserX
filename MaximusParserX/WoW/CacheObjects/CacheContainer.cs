using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class CacheContainer
    {
        public IDictionary<uint, CacheObjects.ItemName> ItemNameCache = new Dictionary<uint, CacheObjects.ItemName>();
        public void AddItemName(CacheObjects.ItemName itemname)
        {
            if (!ItemNameCache.ContainsKey(itemname.entry)) ItemNameCache.Add(itemname.entry, itemname);
        }

        public IDictionary<uint, CacheObjects.ItemText> ItemTextCache = new Dictionary<uint, CacheObjects.ItemText>();
        public void AddItemText(CacheObjects.ItemText itemtext)
        {
            if (!ItemTextCache.ContainsKey(itemtext.TextId)) ItemTextCache.Add(itemtext.TextId, itemtext);
        }

        public IDictionary<ulong, CacheObjects.PlayerName> PlayerNameCache = new Dictionary<ulong, CacheObjects.PlayerName>();
        public void AddPlayerName(CacheObjects.PlayerName playername)
        {
            if (!PlayerNameCache.ContainsKey(playername.guid.Full)) PlayerNameCache.Add(playername.guid.Full, playername);
        }

        public IDictionary<ulong, CacheObjects.PetName> PetNameCache = new Dictionary<ulong, CacheObjects.PetName>();
        public void AddPetName(CacheObjects.PetName PetName)
        {
            if (!PetNameCache.ContainsKey(PetName.petnumber)) PetNameCache.Add(PetName.petnumber, PetName);
        }

        public IDictionary<ulong, CharacterInfo> CharacterInfoCache = new Dictionary<ulong, CharacterInfo>();
        public void AddCharacterInfo(CharacterInfo CharacterInfo)
        {
            if (!CharacterInfoCache.ContainsKey(CharacterInfo.Guid.Full)) CharacterInfoCache.Add(CharacterInfo.Guid.Full, CharacterInfo);
        }

        public IDictionary<string, StartInfo> StartInfoCache = new Dictionary<string, StartInfo>();
        public void AddStartInfoCache(StartInfo StartInfo)
        {
            var key = string.Format("{0}_{1}", StartInfo.Race, StartInfo.Class);
            if (!StartInfoCache.ContainsKey(key)) StartInfoCache.Add(key, StartInfo);
        }
    }
}
