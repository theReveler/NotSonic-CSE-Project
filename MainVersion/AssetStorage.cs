using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class AssetStorage
    {
        private static Texture2D sonicSpriteSheet;
        private static Texture2D itemObjectSpriteSheet;
        private static Texture2D enemySpriteSheet;
        private static Texture2D terrainSpriteSheet;
        private static Texture2D background;
        private static Texture2D backgroundAssets;
        private static Texture2D blockSheet;
        private static Texture2D moreTerrain;
        private static Texture2D sonicTitleScreen;
        private static Texture2D bossSheet;
        private static Texture2D mainMenu;
        private static SpriteFont noodle14;
        private static SpriteFont noodle32;
        private static Song backgroundMusic;
        private static Song invincibleMusic;
        private static SoundEffect pickUpRingSoundEffect;
        private static SoundEffect dropRingsSoundEffect;
        private static SoundEffect jumpingSoundEffect;
        private static SoundEffect springJumpSoundEffect;
        private static SoundEffect bounceOffEnemeySoundEffect;
        private static SoundEffect oneUpSoundEffect;

        public static void LoadAllTextures(ContentManager content)
        {
            sonicSpriteSheet = content.Load<Texture2D>("sonic-11");
            itemObjectSpriteSheet = content.Load<Texture2D>("items-objects");
            terrainSpriteSheet = content.Load<Texture2D>("terrain");
            enemySpriteSheet = content.Load<Texture2D>("enemies");
            background = content.Load<Texture2D>("background");
            backgroundAssets = content.Load<Texture2D>("BackgroundAssets");
            mainMenu = content.Load<Texture2D>("FracturedHills");
            blockSheet = content.Load<Texture2D>("BlockSheet");
            moreTerrain = content.Load<Texture2D>("more_terrain");
            sonicTitleScreen = content.Load<Texture2D>("sonicTitleScreen");
            bossSheet = content.Load<Texture2D>("mmx1chillpenguin");
            noodle14 = content.Load<SpriteFont>("noodle14");
            noodle32 = content.Load<SpriteFont>("noodle32");
            //noodle14 = content.Load<SpriteFont>("noodle14");
            backgroundMusic = content.Load<Song>("Sound/EscapeFromTheCity");
            invincibleMusic = content.Load<Song>("Sound/Invincible");
            pickUpRingSoundEffect = content.Load<SoundEffect>("Sound/Coin");
            dropRingsSoundEffect = content.Load<SoundEffect>("Sound/DropCoins");
            jumpingSoundEffect = content.Load<SoundEffect>("Sound/Jumping");
            springJumpSoundEffect = content.Load<SoundEffect>("Sound/SpringJump");
            bounceOffEnemeySoundEffect = content.Load<SoundEffect>("Sound/BounceOffEnemy");
            oneUpSoundEffect = content.Load<SoundEffect>("Sound/1Up");
        }

        public static Texture2D SonicSpriteSheet { get { return sonicSpriteSheet; } }

        public static Texture2D ItemObjectSpriteSheet { get { return itemObjectSpriteSheet; } }

        public static Texture2D EnemySpriteSheet { get { return enemySpriteSheet; } }

        public static Texture2D TerrainSpriteSheet { get { return terrainSpriteSheet; } }

        public static Texture2D BackgroundAssets { get { return backgroundAssets; } }

        public static Texture2D Background { get { return background; } }

        public static Texture2D BlockSpriteSheet { get { return blockSheet; } }

        public static Texture2D MoreTerrain { get { return moreTerrain; } }

        public static Texture2D SonicTitleScreen { get { return sonicTitleScreen; } }

        public static Texture2D BossSpriteSheet { get { return bossSheet; } }
        public static Texture2D MainMenuSplash { get { return mainMenu; } }

        public static SpriteFont Noodle14 { get { return noodle14; } }
        public static SpriteFont Noodle32 { get { return noodle32; } }
        //public static SpriteFont Noodle14 { get { return noodle14; } }

        public static Song BackgroundMusic { get { return backgroundMusic; } }
        
        public static Song InvincibleMusic { get { return invincibleMusic; } }

        public static SoundEffect PickUpRingSoundEffect { get { return pickUpRingSoundEffect; } }

        public static SoundEffect DropRingsSoundEffect {  get { return dropRingsSoundEffect; } }

        public static SoundEffect JumpingSoundEffect { get { return jumpingSoundEffect; } }

        public static SoundEffect SpringJumpSoundEffect { get { return springJumpSoundEffect; } }

        public static SoundEffect BounceOffEnemeySoundEffect { get { return bounceOffEnemeySoundEffect; } }

        public static SoundEffect OneUpSoundEffect { get { return oneUpSoundEffect; } }
    }
}
