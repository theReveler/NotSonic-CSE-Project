using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class ScoreUtility
    {
        public static int ScoreTimer { get { return 15; } }

        public static int ScoreMultiplierLimit { get { return 10; } }

        //public static int ScoreYPositionOffest { get { return 5; } }

        public static Rectangle OneHundredRectangle {get { return new Rectangle(82, 190, 15, 9); } }

        public static Rectangle TwoHundredFiftyRectangle { get { return new Rectangle(101, 190, 16, 9); } }

        public static Rectangle FiveHundredRectangle { get { return new Rectangle(121, 190, 16, 9); } }

        public static Rectangle OneThousandRectangle { get { return new Rectangle(141, 190, 20, 9); } }

        public static int ScoreTierOne { get { return 100; } }

        public static int ScoreTierTwo { get { return 250; } }

        public static int ScoreTierThree { get { return 500; } }

        public static int ScoreTierFour { get { return 1000; } }

        public static int TierOne { get { return 1; } }

        public static int TierTwo { get { return 2; } }

        public static int TierThree { get { return 4; } }

        public static int TierFour { get { return 10; } }

        public static int TimeStart { get { return 200; } }
    }
}
