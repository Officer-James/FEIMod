using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class pdShotGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 16;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 50, 50, 6);
            Item.knockBack = 10f;
            Item.crit = 50;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PureDiamond>(), 5);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 plr2msp = Main.MouseWorld - player.Center;
            float r = (float)Math.Atan2(plr2msp.Y, plr2msp.X);
            for (int i = -2; i <= 2; i++)
            {
                float r2 = r + i * MathHelper.Pi / 36f;
                Vector2 shootVel = r2.ToRotationVector2() * 10;
                Projectile.NewProjectile(source, position, shootVel, type, 100, 10, player.whoAmI);
            }

            return true;
        }
    }
}
