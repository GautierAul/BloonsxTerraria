using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BloonsxTerraria.Items.Projectiles
{
    public class Fireball : ModProjectile
    {
        private const int BufferSize = 50; // This is now 15 instead of 10, to account for the lagging (see below).
        private const int DustLag = 5; // The amount of frames we're not drawing, as to create the trail 'delay'.
        private Vector2[] positionBuffer = new Vector2[BufferSize];
        private int bufferTail = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
            Main.projFrames[Projectile.type] = 4; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 30;
            Projectile.timeLeft = 300;
            Projectile.light = 0.75f;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = false;
            //Projectile.spriteDirection = 50;
        }

        public override void AI()
        {
            //base.AI();


            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);

            float velX = 0.99f;
            Projectile.velocity.X *= velX;

            float velY = 0.99f;
            Projectile.velocity.Y *= velY;


            Projectile.frameCounter++;
            if(Projectile.frameCounter >= 1)
            {
                Projectile.frame = 3;
                Dust dust = Dust.NewDustPerfect(new Vector2(Projectile.Center.X + Main.rand.Next(-5, 5), Projectile.Center.Y + Main.rand.Next(-5, 5)), 6, Vector2.Zero, Projectile.alpha, default(Color), 1f);
                dust.noGravity = true;
                dust.fadeIn = 0.1f;
                dust.scale = 1f;

                //int dust = Dust.NewDust(Projectile.position, 10, 10, 6); // Create the dust, "6" is the dust type (fire, in that case).

                //Main.dust[dust].noGravity = true; // Is the dust affected by gravity ?
                //Main.dust[dust].velocity *= 1f;    // Change the dust velocity.
                //Main.dust[dust].scale = 1.5f;    // Change the dust size.
            }

            





            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 20; //How fast you want it to animate
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}