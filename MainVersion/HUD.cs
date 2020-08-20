using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public class HUD
    {
        private Camera focus;
        private int minutes;
        private double rest;
        private IGameState gameState;

        public static int Score { get; set; }
        public static int Lives { get; set; }
        public static int Rings { get; set; }
        public static float Time { get; set; }

        public SpriteFont MainFont { get; set; }
        
        public HUD(Camera camera, IGameState gameState1)
        {
            MainFont = AssetStorage.Noodle14;
            focus = camera;
            Score = 0;
            Rings = 0;
            Lives = 3;
            gameState = gameState1;
            if (gameState is RandomPlayState)
                Time = 0.9f;
        }

        public void Update()
        {
            if (gameState is RandomPlayState && Time > 0)
                Time -= .000166f;
            else if (gameState is RandomPlayState)
                Lives = 0;
            else
                Time += .000166f;
            minutes = (int)(Time * 100) / 60;
            rest = (Math.Round((double)Time, 4) * 100) % 60;
            //store high scores as time float
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MainFont, "Score |" + Score, focus.Position + new Vector2(27, 16), Color.Black);
            spriteBatch.DrawString(MainFont, "Score |" + Score, focus.Position + new Vector2(25, 15), Color.White);

            spriteBatch.DrawString(MainFont, "Time |" + minutes + ":" + String.Format("{0:00.00}", rest), focus.Position + new Vector2(22, 36), Color.Black);
            if (gameState is RandomPlayState && Time < 0.15f)
                spriteBatch.DrawString(MainFont, "Time |" + minutes + ":" + String.Format("{0:00.00}", rest), focus.Position + new Vector2(20, 35), Color.Red);
            else if (gameState is RandomPlayState && Time < 0.3f)
                spriteBatch.DrawString(MainFont, "Time |" + minutes + ":" + String.Format("{0:00.00}", rest), focus.Position + new Vector2(20, 35), Color.Yellow);
            else
                spriteBatch.DrawString(MainFont, "Time |" + minutes + ":" + String.Format("{0:00.00}", rest), focus.Position + new Vector2(20, 35), Color.White);

            spriteBatch.DrawString(MainFont, "Rings |" + Rings, focus.Position + new Vector2(17, 56), Color.Black);
            spriteBatch.DrawString(MainFont, "Rings |" + Rings, focus.Position + new Vector2(15, 55), Color.White);
            spriteBatch.DrawString(MainFont, "Lives |" + Lives, focus.Position + new Vector2(15, 315), Color.Black);
            spriteBatch.DrawString(MainFont, "Lives |" + Lives, focus.Position + new Vector2(17, 316), Color.White);
        }

    }
}
