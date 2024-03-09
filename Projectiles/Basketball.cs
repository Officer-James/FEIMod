using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
namespace FEI.Projectiles
{
    public class Basketball : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.damage = 30;
            Projectile.timeLeft = 150;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;
            Projectile.alpha = 0;
            Projectile.friendly = false;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Default;
            Projectile.scale = 1.5f;
            Projectile.knockBack = 6f;
            base.SetDefaults();
        }
        public override void AI()
        {
            Player player = null;
            float maxDis = 1000;
            foreach(Player p in Main.player)
            {
                if (p == null) continue;
                float currentDis = Vector2.Distance(p.Center, Projectile.Center);
                if (currentDis > maxDis)
                {
                    maxDis = currentDis;
                    player = p;
                }
            }
            float MaxSpeed = 5f;
            if (player != null)
            {
                Projectile.rotation += MathHelper.Pi / 180;
                Random ran = new Random();
                Vector2 plr2pro = player.Center - Projectile.Center;
                plr2pro /= plr2pro.Length();
                Projectile.velocity += plr2pro * 1f;
                Projectile.velocity *= 1.2f;
                if (Math.Abs(Projectile.velocity.X) > MaxSpeed)//如果横向速度超越最大值，则回到最大值
                    Projectile.velocity.X = MaxSpeed * Math.Sign(Projectile.velocity.X);
                if (Math.Abs(Projectile.velocity.Y) > MaxSpeed)//如果纵向速度超越最大值，则回到最大值
                    Projectile.velocity.Y = MaxSpeed * Math.Sign(Projectile.velocity.Y);
            }
            base.AI();
        }
    }
}
