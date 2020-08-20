using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static NotSonicGame.GameUtility;
using System;
using Microsoft.Xna.Framework.Media;

namespace NotSonicGame
{
    public static class InputActions
    {

        public static void QuitGame(Game game)
        {
            game.Exit();
        }

        public static void RestartGame(Game1 game1)
        {
            game1.Restart();
        }
        
        public static void Respawn(Sonic sonic)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - milliseconds < ResetTime) { }

            sonic.Position = new Vector2(400, 250);
            sonic.Velocity = new Vector2(0, 0);
            sonic.IsTinted = false;
            sonic.Initialize();
            sonic.IsDead = false;
            sonic.OnGround = false;
            MediaPlayer.Play(AssetStorage.BackgroundMusic);
        }

        public static void RestartLevel(Game1 game1)
        {
            int tempLives = HUD.Lives;
            int tempScore = HUD.Score;
            float tempTime = HUD.Time;
            RestartGame(game1);
            HUD.Lives = tempLives;
            HUD.Score = tempScore;
            HUD.Time = tempTime;
        }

        public static void ColorSonic(Sonic sonic)
        {
            sonic.IsTinted = true;
        }

        public static void RightInput(Sonic sonic)
        {
            sonic.MoveRight();
        }

        public static void LeftInput(Sonic sonic)
        {
            sonic.MoveLeft();
        }

        public static void DownInput(Sonic sonic)
        {
            sonic.Crouch();
        }

        public static void UpInput(Sonic sonic)
        {
            sonic.Position = sonic.Position + new Vector2(0, -15f);
            sonic.Velocity = sonic.Velocity + new Vector2(0, -5f);
            sonic.Jump();
        }

    }
}


