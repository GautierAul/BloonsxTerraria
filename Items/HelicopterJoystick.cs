using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using BloonsxTerraria.Items.Drop;
using BloonsxTerraria.Items.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace BloonsxTerraria.Items
{
	public class HelicopterJoystick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Helicopter joystick");
			Tooltip.SetDefault("Summons a helicopter shooting 2 darts");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.knockBack = 3f;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item44;

			// These below are needed for a minion weapon
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<Content.Buffs.Helicopter000>();
			Item.DamageType = DamageClass.Summon; // Makes the damage register as summon. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type
			
			Item.shoot = ModContent.ProjectileType<Projectiles.Helicopter000>(); // TODO
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return true;
		}


		public override void AddRecipes()
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.SoulofFright, 25);
			//recipe.AddTile(TileID.MythrilAnvil);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
	}

}