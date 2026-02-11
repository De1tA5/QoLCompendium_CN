using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using QoLCompendium.Content.NPCs;
using QoLCompendium.Core.Configs;

namespace QoLCompendium_CN.LocalizationPatch
{
    /*MonoMod 的 hook 需要 hook 的委托签名严格兼容目标方法。
     *常见情况是目标是实例方法，则原始方法签名（Orig delegate）以及 
     *hook 的参数都必须包含实例（即 self）作为第一个参数 ——后记凡是实例化的最好加上self
    */
    public delegate void Orig_SetChatButtons(EtherealCollectorNPC self , ref string button, ref string button2);
    public class ECNPCSetChatButtons:ModSystem
    {
        public static int shopNum;
        public static string ShopName;
        private static Type _type;
        private static MethodInfo _method;
        public override void Load()
        {
            if (!ModLoader.TryGetMod("QoLCompendium", out Mod qolc)) return;
            _type = qolc.Code.GetType("QoLCompendium.Content.NPCs.EtherealCollectorNPC");

            if (_type is null) return;
            _method = _type.GetMethod("SetChatButtons", BindingFlags.Public | BindingFlags.Instance);

            if (_method is null) return;
            MonoModHooks.Add(_method,On_SetChatButtons);
        }

        private static void On_SetChatButtons(Orig_SetChatButtons orig, EtherealCollectorNPC self , ref string button, ref string button2) 
        {

            if (EtherealCollectorNPC.shopNum == 0)
            {
                button = "模组药水";
                EtherealCollectorNPC.ShopName = "Modded Potions";
            }
            else if (EtherealCollectorNPC.shopNum == 1)
            {
                button = "模组药剂，增益站 & 食物";
                EtherealCollectorNPC.ShopName = "Modded Flasks, Stations & Foods";
            }
            else if (EtherealCollectorNPC.shopNum == 2)
            {
                button = "模组材料 （模组：A-M）";
                EtherealCollectorNPC.ShopName = "Modded Materials";
            }
            else if (EtherealCollectorNPC.shopNum == 3)
            {
                button = "模组材料 （模组：N-Z）";
                EtherealCollectorNPC.ShopName = "Modded Materials 2";
            }
            else if (EtherealCollectorNPC.shopNum == 4)
            {
                button = "模组宝藏袋";
                EtherealCollectorNPC.ShopName = "Modded Treasure Bags";
            }
            else if (EtherealCollectorNPC.shopNum == 5)
            {
                button = "模组宝匣 & 摸彩袋";
                EtherealCollectorNPC.ShopName = "Modded Crates & Grab Bags";
            }
            else if (EtherealCollectorNPC.shopNum == 6)
            {
                button = "模组矿石 & 锭";
                EtherealCollectorNPC.ShopName = "Modded Ores & Bars";
            }
            else if (EtherealCollectorNPC.shopNum == 7)
            {
                button = "模组自然物块";
                EtherealCollectorNPC.ShopName = "Modded Natural Blocks";
            }
            else if (EtherealCollectorNPC.shopNum == 8)
            {
                button = "模组建筑物块";
                EtherealCollectorNPC.ShopName = "Modded Building Blocks";
            }
            else if (EtherealCollectorNPC.shopNum == 9)
            {
                button = "模组草药 & 植物";
                EtherealCollectorNPC.ShopName = "Modded Herbs & Plants";
            }
            else if (EtherealCollectorNPC.shopNum == 10)
            {
                button = "模组鱼类 & 钓鱼装备";
                EtherealCollectorNPC.ShopName = "Modded Fish & Fishing Gear";
            }
            if (Main.LocalPlayer.HasItem(ItemID.SilverShortsword) && QoLCompendium.QoLCompendium.itemConfig.DedicatedItems)
            {
                button2 = "赏你的汉堡";
                return;
            }
            button2 = "改变商店";
        }
    }
}
