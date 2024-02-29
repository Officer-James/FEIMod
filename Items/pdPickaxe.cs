using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class pdPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.damage = 15;
            Item.DamageType = DamageClass.Default;
            Item.useTime = 5;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 1, 14, 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.pick = 59;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PureDiamond>(), 2);
            recipe.AddIngredient(ModContent.ItemType<stick>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
