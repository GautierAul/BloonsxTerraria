
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace BloonsxTerraria.NPC
{
	public class GlobalBloon : GlobalNPC
	{
		private bool isSpawned;
		public override bool InstancePerEntity => true;
		public override void AI(Terraria.NPC npc)
        {
            if (npc.type == ModContent.NPCType<RedBloon>() ||
                npc.type == ModContent.NPCType<BlueBloon>() ||
                npc.type == ModContent.NPCType<GreenBloon>() ||
                npc.type == ModContent.NPCType<YellowBloon>() ||
                npc.type == ModContent.NPCType<PinkBloon>() ||
                npc.type == ModContent.NPCType<BlackBloon>() ||
                npc.type == ModContent.NPCType<WhiteBloon>() ||
                npc.type == ModContent.NPCType<PurpleBloon>() ||
                npc.type == ModContent.NPCType<LeadBloon>() ||
                npc.type == ModContent.NPCType<ZebraBloon>() ||
                npc.type == ModContent.NPCType<RainbowBloon>()
                )
            {
                if (isSpawned)
                {
                    npc.frameCounter++;
                    if (npc.frameCounter > 10)
                    {
                        npc.dontTakeDamage = false;
                        isSpawned = false;
                    }
                }
            }
            
        }

        public override void OnSpawn(Terraria.NPC npc, IEntitySource source)
        {
            if (npc.type == ModContent.NPCType<RedBloon>() ||
                npc.type == ModContent.NPCType<BlueBloon>() ||
                npc.type == ModContent.NPCType<GreenBloon>() ||
                npc.type == ModContent.NPCType<YellowBloon>() ||
                npc.type == ModContent.NPCType<PinkBloon>() ||
                npc.type == ModContent.NPCType<BlackBloon>() ||
                npc.type == ModContent.NPCType<WhiteBloon>() ||
                npc.type == ModContent.NPCType<PurpleBloon>() ||
                npc.type == ModContent.NPCType<LeadBloon>() ||
                npc.type == ModContent.NPCType<ZebraBloon>() ||
                npc.type == ModContent.NPCType<RainbowBloon>()
                )
            {
                isSpawned = true;
                npc.dontTakeDamage = true;
            }
            
        }

        public override void HitEffect(Terraria.NPC npc, int hitDirection, double damage)
        {
            if (npc.type == ModContent.NPCType<RedBloon>() ||
                npc.type == ModContent.NPCType<BlueBloon>() ||
                npc.type == ModContent.NPCType<GreenBloon>() ||
                npc.type == ModContent.NPCType<YellowBloon>() ||
                npc.type == ModContent.NPCType<PinkBloon>() ||
                npc.type == ModContent.NPCType<BlackBloon>() ||
                npc.type == ModContent.NPCType<WhiteBloon>() ||
                npc.type == ModContent.NPCType<PurpleBloon>() ||
                npc.type == ModContent.NPCType<LeadBloon>() ||
                npc.type == ModContent.NPCType<ZebraBloon>() ||
                npc.type == ModContent.NPCType<RainbowBloon>()
                )
            {
                int random = Main.rand.Next(1, 3);
                Console.WriteLine(random);
                // Creating a SoundStyle from a sound file in this Mod, then playing it
                SoundEngine.PlaySound(new SoundStyle("BloonsxTerraria/Sounds/pop" + random.ToString()));
            }

            if(npc.type == ModContent.NPCType<CeramicBloon>())
            {
                int random = Main.rand.Next(1, 3);
                Console.WriteLine(random);
                // Creating a SoundStyle from a sound file in this Mod, then playing it
                SoundEngine.PlaySound(new SoundStyle("BloonsxTerraria/Sounds/ceramic_pop" + random.ToString()));
            }
        }


    }
}