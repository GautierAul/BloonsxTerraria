
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BloonsxTerraria.NPC
{
	public class GlobalBloon : GlobalNPC
	{
		private bool isSpawned;
		public override bool InstancePerEntity => true;
		public override void AI(Terraria.NPC npc)
        {
			if(npc.type == ModContent.NPCType<RedBloon>() ||
				npc.type == ModContent.NPCType<BlueBloon>() ||
				npc.type == ModContent.NPCType<GreenBloon>() ||
				npc.type == ModContent.NPCType<YellowBloon>() ||
				npc.type == ModContent.NPCType<PinkBloon>()
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
                npc.type == ModContent.NPCType<PinkBloon>()
                )
            {
                isSpawned = true;
                npc.dontTakeDamage = true;
            }
            
        }
    }
}