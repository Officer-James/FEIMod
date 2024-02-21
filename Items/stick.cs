using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class stick : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.buyPrice(0, 0, 40, 10);
            Item.value = Item.sellPrice(0, 0, 40, 10);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(16);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
