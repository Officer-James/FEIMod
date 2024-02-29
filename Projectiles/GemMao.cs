using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Projectiles
{
    public class GemMao : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.damage = 15;
            Projectile.timeLeft = 150;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.5f;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 1;
        }
        public int Timer
        {
            get
            {
                return (int)Projectile.ai[0];
            }
            set
            {
                Projectile.ai[0] = value;
            }
        }
        Vector2 coord = Vector2.Zero;
        float startVel = 0;
        public override void AI()
        {
            Timer++;
            float factor = MathHelper.Min(1.0f, Timer / 300f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.Pi / 2;
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
            dust.noGravity = true;
            dust.velocity *= 0;
            dust.position = Projectile.Center;
            if (Projectile.timeLeft <= 290)
            {
                Projectile.velocity *= 0.9f;
            }
            NPC target = null;
            float distanceMax = 500f;
            foreach (NPC npc in Main.npc)
            {
                if (!npc.active || npc.friendly) continue;
                float currentDistance = Vector2.Distance(npc.Center, Projectile.Center);
                if (currentDistance < distanceMax)
                {
                    distanceMax = currentDistance;
                    target = npc;
                }
            }
            //float maxSpeed = 20f;
            float accSpeed = 0.5f;
            if (target != null)//SAO
            {
                if (Projectile.Center.X - target.Center.X < 0f)
                {
                    Projectile.velocity.X += Projectile.velocity.X < 0 ? 2 * accSpeed : accSpeed;
                }
                else
                {
                    Projectile.velocity.X -= Projectile.velocity.X < 0 ? 2 * accSpeed : accSpeed;
                }
                if (Projectile.Center.Y - target.Center.Y < 0f)
                {
                    Projectile.velocity.Y += Projectile.velocity.Y < 0 ? 2 * accSpeed : accSpeed;
                }
                else
                {
                    Projectile.velocity.Y -= Projectile.velocity.Y < 0 ? 2 * accSpeed : accSpeed;
                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 600);
        }
    }
}
