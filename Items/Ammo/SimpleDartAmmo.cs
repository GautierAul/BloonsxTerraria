using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using BloonsxTerraria.Items.Drop;
using BloonsxTerraria.Items.Projectiles;

namespace BloonsxTerraria.Items.Ammo
{
	public class SimpleDartAmmo : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Just a dart"); // The item's description, can be set to whatever you want.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 8; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<SimpleDartProjectile>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 16f; // The speed of the projectile.
			Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient<Rubber>(10)
				.AddIngredient(ItemID.IronBar, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}