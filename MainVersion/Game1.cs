using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using static NotSonicGame.GameUtility;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private static SpriteBatch spriteBatch;
        ArrayList controllerList;
        Song backgroundMusic;

        public enum gameState{ pause, play, end, lose, titleScreen, menu, subMenu, bossTransition};

        public IGameState State { get; set; }
        public static IPlayState PlayState { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);     
            AssetStorage.LoadAllTextures(Content);  

            backgroundMusic = AssetStorage.BackgroundMusic;

            SetToMenuState();
            State = new TitleScreen();

            //controllerList.Add(new GamepadController(this,(Sonic)playState.Sonic)); //Not in use for now.    

            SetVolume();
        }


        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            State.Update();

            if (State is LoseState)
                if (((LoseState)State).timeout == 0)
                    SetToMenuState();

            else if (State is EndState)
                if (((EndState)State).timeout == 0)
                    SetToMenuState();
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(spriteBatch);
        }
  
        public void Restart()
        {
            //timer so its not instant
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - milliseconds < ResetTime) { }

            //restart level  
            if (PlayState is OnePlayerPlayState)
                SetToPlayState();
            else
                SetToRandomState();
            ResumePlay();
            MediaPlayer.Play(backgroundMusic);
        }

        public void ResumePlay()
        {
            State = PlayState;
            MediaPlayer.Play(backgroundMusic);
        }

        public void TransitionToBossFight()
        {
            ((OnePlayerPlayState)State).GameState = gameState.bossTransition;
        }
        public void StartBossIntro()
        {
            foreach (IBoss boss in ((OnePlayerPlayState)State).GameObjectList)
            {
                boss.StartFight();
            }
        }
        public void StartBossFight()
        {
            ((OnePlayerPlayState)State).GameState = gameState.play;
        }
        public void EndGame()
        {
            State = new EndState();
        }

        public void GameOver()
        {
            State = new LoseState();
        }
        private static void SetVolume()
        {
            SoundEffect.MasterVolume = BackGroundMusicVolume;
            MediaPlayer.Volume = SoundEffectsVolume;
            MediaPlayer.IsRepeating = true;
        }

        public void SetToRandomState()
        {
            controllerList = new ArrayList();
            RandomPlayState randomPlayState = new RandomPlayState(GraphicsDevice);
            controllerList.Add(new KeyboardController(this, (Sonic)randomPlayState.Sonic));
            PlayState = randomPlayState;
            MediaPlayer.Play(backgroundMusic);
        }

        public void SetToPlayState()
        {
            controllerList = new ArrayList();
            OnePlayerPlayState playState = new OnePlayerPlayState(GraphicsDevice);
            controllerList.Add(new KeyboardController(this, (Sonic)playState.Sonic));
            PlayState = playState;
            MediaPlayer.Play(backgroundMusic);
        }

        public void SetToMenuState()
        {
            controllerList = new ArrayList();
            MainMenu menuState = new MainMenu(GraphicsDevice);
            controllerList.Add(new KeyboardController(this));
            State = menuState;
            MediaPlayer.Play(backgroundMusic);
        }
    }
}
