using FEI.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Items
{
    public class pdMao : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.value = Item.sellPrice(0, 5, 50, 60);
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.UseSound = SoundID.Item1;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.knockBack = 6f;
            Item.crit = 30;
            Item.shoot = ModContent.ProjectileType<GemMao>();
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<pdShotGun>());
            recipe.AddIngredient(ModContent.ItemType<pdSword>());
            recipe.AddIngredient(ModContent.ItemType<PureDiamond>(), 5);
            recipe.AddIngredient(ModContent.ItemType<stick>(), 66);
            recipe.AddIngredient(ItemID.LargeAmethyst);
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.LargeEmerald);
            //recipe.AddIngredient(ItemID.PlatinumCoin, 10);
            //recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.AddTile(TileID.Anvils);
            recipe.AddCondition(Condition.NearWater);
            recipe.AddCondition(Condition.NearLava);
            recipe.AddCondition(Condition.NearHoney);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 plr2ms = Main.MouseWorld - player.Center;
            float r = (float)Math.Atan2(plr2ms.Y, plr2ms.X);
            float r2 = r + MathHelper.Pi / 36f;
            Vector2 shootVel = r2.ToRotationVector2() * 10;
            Projectile.NewProjectile(source, position, shootVel, type, damage, knockback, player.whoAmI);
            r2 = r - MathHelper.Pi / 36f;
            shootVel = r2.ToRotationVector2() * 10;
            Projectile.NewProjectile(source, position, shootVel, type, damage, knockback, player.whoAmI);
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Burning, 600);
            player.AddBuff(BuffID.Honey, 600);
            player.AddBuff(BuffID.Ironskin, 600);
            if (hit.Crit) 
            {
                player.statLife += 10;
                player.HealEffect(10);
                player.AddBuff(BuffID.Shine, 300);
            }
        }
    }
}
