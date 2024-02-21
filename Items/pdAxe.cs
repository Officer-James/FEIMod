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
    public class pdAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.damage = 15;
            Item.DamageType = DamageClass.Default;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.crit = 0;
            Item.value = Item.sellPrice(0, 1, 14, 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.axe = 12;
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
