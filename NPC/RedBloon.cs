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

namespace BloonsxTerraria.NPC
{
	//The ExampleZombieThief is essentially the same as a regular Zombie, but it steals ExampleItems and keep them until it is killed, being saved with the world if it has enough of them.
	public class RedBloon : ModNPC
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Red Bloon");

			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

			//NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
			//	// Influences how the NPC looks in the Bestiary
			//	Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			//};
			//NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

        public override void HitEffect(int hitDirection, double damage)
        {
			int random = Main.rand.Next(1, 2);
			// Creating a SoundStyle from a sound file in this Mod, then playing it
			SoundEngine.PlaySound(new SoundStyle("BloonsxTerraria/Sounds/pop" + random.ToString()));
        }

        public override void SetDefaults() {
			NPC.width = 20;
			NPC.height = 20;
			NPC.damage = 14;
			NPC.defense = 6;
			NPC.lifeMax = 200;
			NPC.value = 60f;
            //NPC.aiStyle = NPCID.Bee;
            AnimationType = NPCID.Zombie;

        }

        public override void AI()
        {
			Player player = Main.player[NPC.target];
			NPC.velocity = NPC.DirectionTo(new Vector2(player.Center.X, player.Center.Y));
			if
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
        }

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter >= 20)
			{
				NPC.frameCounter = 0;
			}
			NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
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