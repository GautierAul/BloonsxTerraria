using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BloonsxTerraria.Items.Drop
{
    public class Rubber : ModItem
    {

		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("That's how bloon are maid of");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.White;
		}


	}
}