using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using SolanumMod.NPCs.Boss.Nepturian;
using SolanumMod.Utilities;
using Microsoft.Xna.Framework.Graphics;

namespace SolanumMod
{
	public class SolanumMod : Mod
	{
        public static float shakeAmount = 0;
        public static int ShakeTimer;

        public static bool NepturianCinematics = false;
        private int NepturianTimer;
        Vector2 oldScreenPos;
        LightningBolt bolt;
        LightningBolt bolt2;
        LightningBolt bolt3;
        LightningBolt bolt4;

        // ????????????????
        public SolanumMod()
		{
			ModProperties properties = default(ModProperties);
			properties.Autoload = true;
			properties.AutoloadGores = true;
			properties.AutoloadSounds = true;
			properties.AutoloadBackgrounds = true;
			base.Properties = properties;
		}
		
		public override void AddRecipeGroups()
		{
			RecipeGroup recipeGroup = new RecipeGroup(() => "Gold or Platinum Bar", new int[]
			{
				19,
				706
			});
			RecipeGroup.RegisterGroup("GoldPlatinumBar", recipeGroup);
		}
        public override void Load()
        {
            Main.OnPostDraw += DrawLightning;
        }

        // Daim's shitty screen shaking method :tm:
        public static void ShakeScreen(float AmountOfShake, int Time)
        {
            ShakeTimer = Time;
            shakeAmount = AmountOfShake;
        }
        public override void ModifyTransformMatrix(ref SpriteViewMatrix Transform)
        {
            Player player = Main.LocalPlayer;

            if (!Main.gameMenu)
            {
                if (shakeAmount != 0 && ShakeTimer != 0)
                {
                    ShakeTimer--;
                    Vector2 Shakey = new Vector2(player.Center.X + Main.rand.NextFloat(shakeAmount), player.Center.Y + Main.rand.NextFloat(shakeAmount)) - new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
                    Main.screenPosition = Shakey;
                }
                // Im p sure I shouldn't be doing this here but fuck it.
                if (NepturianCinematics)
                {
                    int npc = NPC.FindFirstNPC(ModContent.NPCType<Nepturian>());
                    NPC boss = Main.npc[npc];
                    PlayerLayer.MiscEffectsFront.visible = false;
                    player.frozen = true;
                    Main.screenPosition = boss.Center - new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
                    bolt = new LightningBolt(new Vector2(boss.Center.X, boss.Center.Y - 600) - Main.screenPosition, boss.Center - Main.screenPosition);
                    bolt.Update();
                    bolt3 = new LightningBolt(new Vector2(boss.Center.X, boss.Center.Y + 600) - Main.screenPosition, boss.Center - Main.screenPosition);
                    bolt3.Update();
                    bolt2 = new LightningBolt(new Vector2(boss.Center.X + 1200, boss.Center.Y) - Main.screenPosition, boss.Center - Main.screenPosition);
                    bolt2.Update();
                    bolt4 = new LightningBolt(new Vector2(boss.Center.X - 1200, boss.Center.Y) - Main.screenPosition, boss.Center - Main.screenPosition);
                    bolt4.Update();
                    Main.PlaySound(SoundID.DD2_LightningAuraZap, player.Center);

                    NepturianTimer++;
                    ShakeScreen(15f, 10);
                }
                else if(NepturianTimer != 0) { NepturianTimer = 0; }
            }
        }
        public void DrawLightning(GameTime gameTime)
        {
            if(NepturianCinematics)
            {
                Main.spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
                if (NepturianTimer >= 300 / 4)
                    bolt2?.Draw(Main.spriteBatch);
                if (NepturianTimer >= 300 / 2)
                    bolt3?.Draw(Main.spriteBatch);
                if (NepturianTimer >= 300)
                    bolt4?.Draw(Main.spriteBatch);
                bolt?.Draw(Main.spriteBatch);
                Main.spriteBatch.End();
            }
        }
    }
}
