using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using TigerForceLocalizationLib;
using TigerForceLocalizationLib.Filters;

namespace QoLCompendium_CN
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class QoLCompendium_CN : Mod
	{
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("QoLCompendium")) 
            {
                TigerForceLocalizationHelper.LocalizeAll("QoLCompendium_CN", "QoLCompendium", false, filters: new()
                {
                    MethodFilter = MethodFilter.MatchNames("GetChat", "SetBestiary", "SetChatButtons")
                });
            }
        }
	}
}
