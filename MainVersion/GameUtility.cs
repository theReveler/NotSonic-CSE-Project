using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class GameUtility
    {
        public static int ScreenWidth { get { return 750; } }

        public static int ScreenHeight { get { return 525; } }

        public static int ResetTime { get { return 1000; } }

        public static float BackGroundMusicVolume { get { return 0.2f; } }

        public static float BackGroundMusicPausedVolume { get { return 0.05f; } }

        public static float SoundEffectsVolume { get { return 0.2f; } }

        public static Vector2 SonicStartingPosition { get { return new Vector2(400, 250); } }

        //public static Vector2 SonicRandomStartingPosition { get { return new Vector2(0, 250); } }

        private static Rectangle[] titleScreenSonicSourceRectangles = { new Rectangle(14, 288, 66, 77), new Rectangle(84, 288, 74, 77), new Rectangle(162, 288, 74, 77), new Rectangle(240, 288, 80, 77), new Rectangle(324, 288, 74, 77), new Rectangle(401, 288, 82, 77), new Rectangle(487, 288, 82, 77), new Rectangle(573, 288, 82, 77) };
        public static Rectangle[] GetTitleScreenSonicSourceRectangles() { return titleScreenSonicSourceRectangles; }

        public static int TitleScreenSonicStartFrame { get { return 0; } }

        public static int TitleScreenSonicResetFrame { get { return 6; } }

        public static int TitleScreenSonicEndFrame { get { return 7; } }

        public static Rectangle TitleScreenBackGroundSourceRectangle { get { return new Rectangle(286, 32, 510, 248); } }

        public static Rectangle TitleScreenBackGroundDestRectangle { get { return new Rectangle(0, 0, 750, 525); } }

        public static Rectangle TitleScreenLogoSourceRectangle { get { return new Rectangle(15, 33, 255, 143); } }

        public static Rectangle TitleScreenLogoDestRectangle { get { return new Rectangle(120, 100, 2 * 255, 2 * 143); } }

        public static Rectangle TitleScreenSonicDestRectangle { get { return new Rectangle(301, 88, 2 * 74, 2 * 77); } }

        public static Color MainTextColor { get { return new Color(255, 255, 255, 0.8f); } }
        public static Color MainTextShadow { get { return new Color(0, 0, 0, 0.8f); } }
        public static Color HighlightTextColor { get { return new Color(238, 232, 170, 255);  } }

        public static bool EndRingObtained { get; set; } = false;
    }
}
