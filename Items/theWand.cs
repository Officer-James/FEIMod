using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class theWand : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 40;
            Item.value = Item.sellPrice(0, 11, 45, 14);
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PureDiamond>(), 10);
            recipe.AddIngredient(ModContent.ItemType<stick>(), 5);
            recipe.AddIngredient(ItemID.CopperBar, 20);
            recipe.AddIngredient(ItemID.Amethyst, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            base.AddRecipes();
        }
    }
}
