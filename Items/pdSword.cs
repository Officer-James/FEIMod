using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class pdSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.crit = 20;
            Item.value = Item.sellPrice(0, 1, 14, 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            //Item.shoot = ModContent.ProjectileType<FireBullet>();
            //Item.shootSpeed = 5f;
            Item.useTurn = true;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PureDiamond>(), 3);
            recipe.AddIngredient(ModContent.ItemType<stick>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        /*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (float r = 0f; r < MathHelper.TwoPi; r += MathHelper.TwoPi / 8f)
            {
                Vector2 vector = new Vector2((float)Math.Cos(r), (float)Math.Sin(r)) * 10f;
                Projectile.NewProjectile(source, position, vector, type, 100, 10f, player.whoAmI);
            }
            return true;
        }*/
    }
}
