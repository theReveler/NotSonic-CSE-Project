using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Game1;
using Microsoft.Xna.Framework;
using static NotSonicGame.GameUtility;
using static NotSonicGame.EnemyUtility;
using Microsoft.Xna.Framework.Media;

namespace NotSonicGame
{
    public class OnePlayerPlayState : IPlayState
    {
        private gameState gameState;
        private HUD hud;
        private ISonic sonic;
        private GraphicsDevice graphicsDevice;
        private static List<IGameObject> gameObjectList;
        private Camera camera = new Camera();
        private CollisionDetector collisionDetector = new CollisionDetector();
        private ScoreControl scoreControl = new ScoreControl();

        public List<IGameObject> GameObjectList { get { return gameObjectList; } }
        public HUD Hud { get { return hud; } }
        public Camera Camera { get { return camera; } }
        public gameState GameState { get { return gameState; } set { gameState = value; } }
        public OnePlayerLevel OnePlayerLevel { get; set; }
        public ISonic Sonic { get { return sonic; } }

        public OnePlayerPlayState(GraphicsDevice graphicsDevice)
        {
            gameState = gameState.play;
            this.graphicsDevice = graphicsDevice;
            LoadLevel();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: camera.Transform);
            foreach (IGameObject gameObject in gameObjectList)
            {
                gameObject.Draw(spriteBatch);
            }
            scoreControl.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            spriteBatch.End();
        }
        public void Update()
        {
            camera.Update((Sonic)sonic);
            collisionDetector.Update(gameObjectList);
            if (gameState == gameState.play)
                UpdatePlayState();
            else if (gameState == gameState.bossTransition)
                UpdateBossTransition();
            
            hud.Update();
        }
        public void RemoveFromGameList(IGameObject gameObject)
        {
            gameObjectList.Remove(gameObject);
        }

        public void AddToGameList(IGameObject gameObject)
        {
            gameObjectList.Add(gameObject);
        }
        public IGameObject FindSonic()
        {
            foreach (IGameObject gameObject in gameObjectList)
            {
                if (gameObject is ISonic)
                    return gameObject;
            }
            return null;
        }
        public void LoadLevel()
        {
            var onePlayerLevelLoader = new OnePlayerLevelLoader();
            OnePlayerLevel = onePlayerLevelLoader.LoadOnePlayerLevel();
            sonic = new Sonic(new Vector2(400, 580));
            gameObjectList = OnePlayerLevel.returnObjectList();
            AddToGameList(sonic);
            Background main = OnePlayerLevel.returnBackground();
            main.ConnectCamera(camera);
            hud = new HUD(camera, this);
        }

        private void UpdatePlayState()
        {
            var gameObjectArray = gameObjectList.ToArray();
            foreach (IGameObject gameObject in gameObjectArray)
            {
                gameObject.Update();
            }
            scoreControl.Update();
        }

        private void UpdateBossTransition()
        {
            var gameObjectArray = gameObjectList.ToArray();
            foreach (IGameObject gameObject in gameObjectArray)
            {
                gameObject.Update();
            }
            scoreControl.Update();

            if (Sonic.Position.X < 3500)
            {
                Sonic.MoveRight();
                Sonic.Position = new Vector2(Sonic.Position.X + 1, Sonic.Position.Y);
            }
            else
            {
                HasStartBossIntro = true;
            }
        }
    }
}
