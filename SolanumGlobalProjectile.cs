using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SolanumMod
{
	public class SolanumGlobalProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{			
				if (projectile.minion)
				{
					if (Main.player[projectile.owner].GetModPlayer<SolanumPlayer>().shadowflameMinion)
					{
						target.AddBuff(153, 180, false);
					}
				}
			}
		}
		float OGValue;
		public override bool InstancePerEntity => true;
		bool setOGLightValue = false;
		public override void AI(Projectile projectile)
		{
			if(!setOGLightValue)
			{
				OGValue = projectile.light;
				setOGLightValue = true;
			}
			if(projectile.owner == Main.myPlayer && projectile.minion)
			{
				if(Main.player[projectile.owner].GetModPlayer<SolanumPlayer>().GoldenPendant && projectile.light < 0.5f)
				{
						projectile.light = 0.55f;
				}  else projectile.light = OGValue;
			} 
		}
	}
}
