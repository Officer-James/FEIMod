using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using System;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.NPCs.Bosses.Kun
{
    [AutoloadBossHead]
    public class Kun : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 150;
            NPC.height = 240;
            NPC.boss = true;
            Music = MusicLoader.GetMusicSlot("FEI/Sounds/Music/bosskun");
            NPC.lifeMax = 2500;
            NPC.defense = 10;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.Roar;
            NPC.damage = 20;
            NPC.npcSlots = 50;
            NPC.knockBackResist = 0f;
            NPC.noGravity = false;
            AIType = -1;
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                BuffID.Poisoned,
                BuffID.OnFire,
                BuffID.Burning
                }
            };
        }
        public override void OnKill()
        {
            for (int i = 0; i < 21; i++)
            {
                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<Kun>())) return 0f;
            if (Main.dayTime)
            {
                return 0.1f;
            }
            return 0.05f;
        }
        public override void FindFrame(int frameHeight)
        {

            NPC.frame.Y = ((Timer / 15) % 5) * frameHeight;
        }
        public int Timer
        {
            get
            {
                return (int)NPC.ai[0];
            }
            set
            {
                NPC.ai[0] = value;
            }
        }
        public int spawnRandomTime(int startVar, int endVar)
        {
            Random rand = new Random();
            return rand.Next(startVar, endVar);
        }
        enum phaseID {Chasing, Jumping};
        public override void AI()
        {
            //Refresh
            Timer++;
            NPC.TargetClosest(true);

            //Consts
            //bool isJumping = false;
            float chaseSpeed = 5f;
            //float maxJumpSpeed = -15;
            Player player = Main.player[NPC.target];
            Vector2 targetPosition = player.Center;
            float distance = Vector2.Distance(NPC.Center, targetPosition);
            var BossPhase = phaseID.Chasing;
            
            //Chasing
            if (BossPhase == phaseID.Chasing)
            {
                if (distance < 1000f)
                {
                    Vector2 direction2Player = targetPosition - NPC.Center;
                    direction2Player.Normalize();
                    NPC.velocity = direction2Player * chaseSpeed;
                    if (!NPC.collideY)
                    {
                        NPC.velocity.Y += 4f;
                    }
                }
                else
                {
                    NPC.velocity = Vector2.Zero;
                }
            }
            
            // Jump 
            if (BossPhase == phaseID.Jumping)
            {
                NPC.velocity.Y = -1f;
                while (NPC.velocity.Y > -15f)
                {
                    NPC.velocity *= 1.3f;
                }
            }

            //Updating
            //isJumping = false;
            if (Timer % (5 * 60) == 0)
            {
                BossPhase = phaseID.Jumping;
            }
            else
            {
                BossPhase = phaseID.Chasing;
            }
        }
    }
}
