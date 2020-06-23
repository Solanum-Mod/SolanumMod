using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SolanumMod.Dusts
{
    public class GoblinToad_Dust : ModDust
    {
       public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-6, 6) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 0.8f;
		}
        public override bool MidUpdate(Dust dust)
        {
            dust.velocity.Y -= 0.08f;
            dust.scale -= 0.05f;
            return false;
        }
    }
}