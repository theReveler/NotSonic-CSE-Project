using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    internal class KeyboardController : IController
    {
        private Game1 game1;
        private Sonic sonic;
        private KeyboardState oldState;

        public KeyboardController(Game1 game1, Sonic sonic)
        {
            this.game1 = game1;
            this.sonic = sonic;
            oldState = Keyboard.GetState();

        }

        public KeyboardController(Game1 game1)
        {
            this.game1 = game1;
            oldState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            switch (game1.State.GameState)
            {
                case Game1.gameState.titleScreen:
                    UpdateTitleScreen(newState);
                    break;
                case Game1.gameState.play:
                    UpdatePlayState(newState);
                    break;
                case Game1.gameState.pause:
                    UpdatePauseState(newState);
                    break;
                case Game1.gameState.end:
                    UpdateEndState(newState);
                    break;
                case Game1.gameState.bossTransition:
                    UpdateBossTransitionState(newState);
                    break;
                case Game1.gameState.menu:
                    UpdateMenuState(newState);
                    break;
                case Game1.gameState.subMenu:
                    UpdateSubMenuState(newState);
                    break;
            }
            oldState = newState;
        }

        private void UpdateSubMenuState(KeyboardState newState)
        {
            if (newState.IsKeyDown(Keys.Escape))
            {
                game1.SetToMenuState();
            }
        }

        private void PlayerInput(KeyboardState newState)
        {
            //sonic = (Sonic)Play.FindSonic();
            sonic.OnGround = false;

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                InputActions.DownInput(sonic);
                if (newState.IsKeyUp(Keys.A) && newState.IsKeyUp(Keys.Left) && newState.IsKeyUp(Keys.D) && newState.IsKeyUp(Keys.Right))
                    sonic.AccelDirectionX = Directions.Direction.None;
            }
            else if (newState.IsKeyDown(Keys.D) || newState.IsKeyDown(Keys.Right))
            {
                sonic.AccelDirectionX = Directions.Direction.Right;
                InputActions.RightInput(sonic);
            }
            else if (newState.IsKeyDown(Keys.A) || newState.IsKeyDown(Keys.Left))
            {
                sonic.AccelDirectionX = Directions.Direction.Left;
                InputActions.LeftInput(sonic);
            }
            else
            {
                sonic.AccelDirectionX = Directions.Direction.None;
                sonic.DefaultState();

            }
            if ((newState.IsKeyDown(Keys.W) || newState.IsKeyDown(Keys.Up)) && sonic.HasJumped == false && newState.IsKeyUp(Keys.S))
            {
                InputActions.UpInput(sonic);
            }
        }

        private void UpdateTitleScreen(KeyboardState newState)
        {
            //Any Key, Move to MainMenu
            if (newState != oldState)
                game1.SetToMenuState();

            
        }

        private void UpdateMenuState(KeyboardState newState)
        {

            MainMenu menuState = (MainMenu)game1.State;

            if (newState.IsKeyDown(Keys.Enter))
            {
                menuState.StartMode(game1);             
            }

            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.W))
            {
                menuState.CycleUp();
            }

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                menuState.CycleDown();
            }
        }
        private void UpdatePauseState(KeyboardState newState)
        {

            PauseState menuState = (PauseState)game1.State;

            if (newState.IsKeyDown(Keys.Enter))
            {
                menuState.StartMode(game1);
            }

            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.W))
            {
                menuState.CycleUp();
            }

            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.S))
            {
                menuState.CycleDown();
            }
        }
        private void UpdateEndState(KeyboardState newState)
        {
            if (game1.State is LoseState)
                if (((LoseState)game1.State).timeout == 0)
                    game1.SetToMenuState();

            if (game1.State is EndState)
                if (((EndState)game1.State).timeout == 0)
                    game1.SetToMenuState();
        }
        private void UpdatePlayState(KeyboardState newState)
        {
            if (newState.IsKeyDown(Keys.Q))
            {
                InputActions.QuitGame(game1);
            }
            if (newState.IsKeyDown(Keys.P))
            {
                InputActions.RestartGame(game1);
            }
            if (HUD.Lives == 0)
                game1.GameOver();

            if (GameUtility.EndRingObtained)
                game1.EndGame();

            //sonic states
            if (newState.IsKeyDown(Keys.U) || (sonic.IsDead && !(game1.State is LoseState)))
            {
                //InputActions.Respawn(sonic);
                InputActions.RestartLevel(game1);
            }
            else if (newState.IsKeyDown(Keys.I))
            {
                InputActions.ColorSonic(sonic);
            }
            if (newState.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape))
            {
                game1.State = new PauseState();
            }
            //disable all controls if sonic is dead
            if (!sonic.IsDead || game1.State is LoseState)
            {
                PlayerInput(newState);
            }
        }
        private void UpdateBossTransitionState(KeyboardState newState)
        {
            if (HasStartBossIntro)
                game1.StartBossIntro();
            if (HasStartBossFight)
                game1.StartBossFight();
        }
    }
}


