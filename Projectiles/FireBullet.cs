using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Projectiles
{
    public  class FireBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.damage = 10;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
        }
        public override void AI()
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
            dust.noGravity = true;
            dust.velocity *= 0;
            dust.position = Projectile.Center;
        }
    }
}
