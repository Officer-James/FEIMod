using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class wandGold : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 40;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 11, 45, 14);
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 15f;
            Item.crit = 50;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<theWand>(), 1);
            recipe.AddRecipeGroup("GoldOrPlatinum", 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            base.AddRecipes();
        }
    }
}
