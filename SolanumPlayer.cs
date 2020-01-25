using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace SolanumMod
{ 
    class SolanumPlayer : ModPlayer
    {
        public bool shadowflameMinion;
        
        public override void ResetEffects()
		{
            this.shadowflameMinion = false;
        }
    }
}
