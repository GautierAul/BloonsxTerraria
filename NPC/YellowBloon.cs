using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ModLoader.IO;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;

namespace BloonsxTerraria.NPC
{
	//The ExampleZombieThief is essentially the same as a regular Zombie, but it steals ExampleItems and keep them until it is killed, being saved with the world if it has enough of them.
	public class YellowBloon : ModNPC
	{
		private bool isSpawned = false;
		public override string Texture => "BloonsxTerraria/NPC/Bloons";

        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Yellow Bloon");

			Main.npcFrameCount[Type] = 12;

            //NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
            //	// Influences how the NPC looks in the Bestiary
            //	Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            //};
            //NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults() {
			float NpcCenterX = NPC.Center.X;
            NPC.width = 20;
            NPC.height = 20;
            NPC.damage = 12;
			NPC.defense = 6;
			NPC.lifeMax = 40;
			NPC.noGravity = true;
			NPC.aiStyle = 14;
		}

		public override void AI()
        {
            

		}

		public override bool PreKill()
        {
			Terraria.NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<GreenBloon>());
			return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.Player.ZoneForest)
			{
				return SpawnCondition.OverworldDay.Chance * 0.02f;
			}
			return 0f;
		}

		public override void FindFrame(int frameHeight)
		{
			//NPC.frameCounter++;
			//if (NPC.frameCounter >= 30)
			//{
			//    NPC.frameCounter = 0;
			//}
			//NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
			NPC.frame.Y = 120;
        }


		//public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
		//	// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
		//	bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
		//		// Sets the spawning conditions of this NPC that is listed in the bestiary.
		//		BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

		//		// Sets the description of this NPC that is listed in the bestiary.
		//		new FlavorTextBestiaryInfoElement("This type of zombie really like Example Items. They steal them as soon as they find some."),
		//	});
		//}




	}
}