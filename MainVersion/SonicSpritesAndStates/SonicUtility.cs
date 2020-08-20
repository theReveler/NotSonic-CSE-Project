using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class SonicUtility
    {
        //Timers and limits
        public static int InvincibilityTimer { get { return 600; } }

        public static int PowerSneakerTimer { get { return 900; } }

        public static int BlinkerDuration { get { return 80; } }

        public static int AnimationTickerLimit { get { return 60; } }

        public static int JumpCounterLimit { get { return 3; } }

        public static float PowerSneakerAcceleration { get { return 1.5f; } }

        //Offset
        public static int DeadOffset { get { return -5; } }

        //Source Rectangles
        public static Rectangle DeadRectangle { get { return new Rectangle(246, 7, 38, 43); } }

        public static Rectangle LeftIdleRectangle { get { return new Rectangle(545, 0, 45, 50); } }

        public static Rectangle LeftJumpingRectangle { get { return new Rectangle(304, 173, 45, 50); } }

        public static Rectangle RightIdleRectangle { get { return new Rectangle(0, 0, 45, 50); } }

        public static Rectangle RightJumpingRectagle { get { return new Rectangle(236, 173, 45, 50); } }
    }
}
