using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.AssetStorage;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using NotSonicGame.SonicSpritesAndStates;
using Microsoft.Xna.Framework.Media;
using static NotSonicGame.SonicUtility;

namespace NotSonicGame
{
    public class Sonic : ISonic
    {
        private ISprite shieldSprite, invincibleSprite;
        private SonicPhysics sonicPhysics;

        private bool ringBombFlag;

        public bool HasJumped { get; set; }
        public bool IsTinted { get; set; }
        public bool IsStunned { get; set; }
        public bool IsDead { get; set; }
        public bool HasShield { get; set; }
        public bool IsInvincible { get; set; }
        public bool HasPowerSneaker { get; set; }
        public bool OnGround { get; set; }
        public int JumpCount { get; set; }
        public Directions.Direction AccelDirectionX { get; set; }
        public float AccelX { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public ISonicState SonicState { get; set; }
        public ISprite SonicSprite { get; set; }

        private int invincibleTimer = InvincibilityTimer, powerSneakerTimer = PowerSneakerTimer, blinkDuration = 0, animationTicker = 0, stunTimer = 0;
      

        public Sonic(Vector2 location)
        {
            Position = location;
            SonicState = new RightIdleSonicState(this);
            sonicPhysics = new SonicPhysics(this);
        }

        public Rectangle BoundingBox()
        {
            return SonicSprite.BoundingBox();
        }

        public void MoveRight()
        {
            if (stunTimer < 20)
                SonicState.MoveRight();
        }

        public void MoveLeft()
        {
            if (stunTimer < 20)
                SonicState.MoveLeft();
        }
        public void SpringJump()
        {
            HasJumped = true;
            if (JumpCount < 3)
                JumpCount++;
            SonicState.Jump();
            SpringJumpSoundEffect.Play();
        }

        public void Jump()
        {
            HasJumped = true;
            if (JumpCount < JumpCounterLimit)
                JumpCount++;
            SonicState.Jump();
            JumpingSoundEffect.Play();
        }

        public void Crouch()
        {
            SonicState.Crouch();
        }

        public void Update()
        {
            UpdateTimers();

            //Shield Update
            if (HasShield)
            {
                shieldSprite.Update();
            }

            //Invincible Update
            if (IsInvincible)
            {
                invincibleTimer--;
                if (invincibleTimer == 0)               
                    BlinkBuff();
             
                invincibleSprite.Update();
            }

            //Power Sneaker Update
            if (HasPowerSneaker)
            {
                powerSneakerTimer--;
                if (powerSneakerTimer == 0)
                    RemovePowerSneaker();

                if (Velocity.X > 0)
                {
                    Velocity = new Vector2(Velocity.X * PowerSneakerAcceleration, Velocity.Y);
                }
            }

            if (ringBombFlag)
                BlowRings();

            sonicPhysics.Update();

            SonicState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SonicState.Draw(spriteBatch);

            if (IsInvincible == true && !(animationTicker % 6 > 1))
            {
                invincibleSprite.Draw(spriteBatch);
            } else if (HasShield == true && !(animationTicker % 6 > 2))
            {
                shieldSprite.Draw(spriteBatch);
            } 

        }

        public void DefaultState()
        {
            SonicState.DefaultState();
        }

        public void BlowRings()
        {
            Random fly = new Random();
            int temp = HUD.Rings;
            DroppedRing ring;
            while (temp > 0)
            {
                ring = new DroppedRing(Position, new Vector2(fly.Next(-7, 7), fly.Next(0, 10)));
                Game1.PlayState.AddToGameList(ring);
                temp--;
            }
            HUD.Rings = 0;
            //Stun();
            BlinkBuff();
            Position = Position + new Vector2(0, -15f);
            Velocity = new Vector2(Velocity.X, -4.5f - JumpCount / 2f);
            Jump();
            ringBombFlag = false;
            AssetStorage.DropRingsSoundEffect.Play();
        }

        public void TakeDamage()
        {
            if (IsInvincible || blinkDuration > 0)
            {
                //DoNothing
            }
            else if(HasShield)
            {
                BlinkBuff();
            }
            else
            {
                //if rings Stun(); RemoveRings();
                if (HUD.Rings > 0)
                {
                    ringBombFlag = true;
                    Stun();
                }
                else
                    Dead();
            }
        }

        public void GetShield()
        {
            HasShield = true;
            shieldSprite = new ShieldSprite(this);
        }

        public void RemoveShield()
        {
            HasShield = false;
        }

        public void GetInvincible()
        {
            IsInvincible = true;
            invincibleSprite = new InvincibleSprite(this);
            MediaPlayer.Stop();
            MediaPlayer.Play(AssetStorage.InvincibleMusic);
        }

        private void RemoveInvinciblility()
        {
            IsInvincible = false;
            invincibleTimer = InvincibilityTimer;
            MediaPlayer.Stop();
            MediaPlayer.Play(AssetStorage.BackgroundMusic);
        }

        private void BlinkBuff()
        {
            blinkDuration = 80;
        }
        private void UpdateTimers()
        {
            if (blinkDuration > 0)
            {
                blinkDuration--;
                if (blinkDuration == 0 && IsInvincible)
                    RemoveInvinciblility();
                else if (blinkDuration == 0 && HasShield)
                    RemoveShield();

                animationTicker++;
                if (animationTicker == AnimationTickerLimit || blinkDuration == 0)
                    animationTicker = 0;
            }

            if (stunTimer > 0)
            {
                stunTimer--;
                if (stunTimer == 0)
                {
                    IsStunned = false;
                }
            }
        }

        public void GetPowerSneaker()
        {
            HasPowerSneaker = true;
        }

        public void RemovePowerSneaker()
        {
            HasPowerSneaker = false;
            powerSneakerTimer = PowerSneakerTimer;
        }

        public void Stun()
        {
            stunTimer = 40;
            if (SonicState.Orientation == Directions.Direction.Left)
            {
                SonicState = new RightStunnedSonicState(this);
                Position = Position + new Vector2(0, -15f);
                Velocity = new Vector2(-Velocity.X / 2 + 1, -4f - JumpCount / 2f);
            } else
            {
                SonicState = new LeftStunnedSonicState(this);
                Position = Position + new Vector2(0, -15f);
                Velocity = new Vector2(-Velocity.X / 2 - 1, -4f - JumpCount / 2f);
                
            }
            HasJumped = true;
            IsStunned = true;
        }

        public void Dead()
        {
            SonicState = new DeadSonicState(this);
            IsDead = true;
            HUD.Lives--;
        }

        public void Initialize()
        {
            SonicState = new RightIdleSonicState(this);
        }

    }
}
