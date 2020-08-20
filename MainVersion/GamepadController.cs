using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NotSonicGame
{
    class GamepadController : IController
    {
        private Game1 game1;
        private Sonic sonic;
        GamePadState currentGamePadState;


        public GamepadController(Game1 game1, Sonic sonic)
        {
            this.game1 = game1;
            this.sonic = sonic;
        }

        public void Update()
        {
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (currentGamePadState.IsButtonDown(Buttons.Start))
            {
                game1.Exit();
            }
            else if(currentGamePadState.IsButtonDown(Buttons.Back))
            {
                sonic.Position = new Vector2(400, 250);
                sonic.IsTinted = false;
                sonic.Initialize();
                sonic.IsDead = false;
            }

            if (!sonic.IsDead)
            {
                if (currentGamePadState.IsButtonDown(Buttons.DPadUp) || currentGamePadState.IsButtonDown(Buttons.LeftThumbstickUp))
                {
                    sonic.Jump();
                    sonic.Position = new Vector2(sonic.Position.X, sonic.Position.Y - 5);
                }
                else if (currentGamePadState.IsButtonDown(Buttons.DPadDown) || currentGamePadState.IsButtonDown(Buttons.LeftThumbstickDown))
                {
                    sonic.Crouch();
                    sonic.Position = new Vector2(sonic.Position.X, sonic.Position.Y + 5);
                }
                else if (currentGamePadState.IsButtonDown(Buttons.DPadRight) || currentGamePadState.IsButtonDown(Buttons.LeftThumbstickRight))
                {
                    sonic.Position = new Vector2(sonic.Position.X + 5, sonic.Position.Y);
                    sonic.MoveRight();
                }
                else if (currentGamePadState.IsButtonDown(Buttons.DPadLeft) || currentGamePadState.IsButtonDown(Buttons.LeftThumbstickLeft))
                {
                    sonic.Position = new Vector2(sonic.Position.X - 5, sonic.Position.Y);
                    sonic.MoveLeft();
                }
            }
        }
    }
}