using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class BlockUtility
    {
        //General Use in Blocks
        public static int GeneralMaxFrames { get { return 40; } }

        public static double GeneralBlockFrameOneMultiplier { get { return 0.25; } }

        public static double GeneralBlockFrameTwoMultiplier { get { return 0.50; } }

        public static double GeneralBlockFrameThreeMultiplier { get { return 0.75; } }

        //VideoMonitor Related
        public static int[] GetDestroyedMonitorFrameChanges(){ return new int[] { 1, 8, 11, 16, 24, 32}; }

        public static Rectangle DestroyedMonitorRectangle { get { return new Rectangle(71, 71, 33, 17);} }

        public static int DestroyedMonitorYOffset { get { return 13; } }

        public static int[] GetExplosionXOffset() { return new int[] {5, 2, 0, -4, -2};  }

        public static int[] GetExplosionYOffset() { return new int[] {5, -2, -2, -8, -8}; }

        public static Rectangle[] GetExplosionFrameRectangles()
        {
            return new Rectangle[] {new Rectangle(35, 108, 20, 17), new Rectangle(59, 99, 27, 31), new Rectangle(91, 98, 33, 33), new Rectangle(130, 92, 39, 39), new Rectangle(174, 92, 37, 39)};
        }

        public static int VideoMontiorItemMaxFrames { get { return 10; } }

        public static int ItemXOffset { get { return 7; } }

        public static int ItemYOffset { get { return 3; } }

        public static int VideoMonitorMaxFrames { get { return 20; } }

        public static Rectangle VideoMonitorFrameOne { get { return new Rectangle(7, 58, 31, 30); } }

        public static Rectangle VideoMonitorFrameTwo { get { return new Rectangle(39, 58, 31, 30); } }

        //Simple Blocks
        public static Rectangle HorizontalSpikeRectangle { get { return new Rectangle(179, 10, 31, 41); } }

        public static Rectangle VerticalSpikeRectangle { get { return new Rectangle(114, 15, 41, 31); } }

        public static Rectangle BackgroundTerrainRectangle { get { return new Rectangle(40, 69, 39, 32); } }

        public static Rectangle SimpleTerrainRectangle { get { return new Rectangle(0, 71, 40, 36); } }

        public static Rectangle UndergroundBlockRectangle { get { return new Rectangle(40, 0, 40, 40); } }

        public static Rectangle WoodenBlockRectangle { get { return new Rectangle(0, 0, 40, 40); } }

        public static int PlatformRange { get { return 100; } }

        public static Rectangle WoodenPlatformRectangle { get { return new Rectangle(1244, 597, 47, 17); } }

        //Spring
        public static int SpringMaxFrames { get { return 20; } }

        public static Rectangle[] GetYellowUpFacingFrames() { return new Rectangle[] { new Rectangle(33, 236, 30, 18), new Rectangle(66, 244, 30, 10), new Rectangle(95, 220, 30, 33) };  }

        public static Rectangle[] GetYellowLeftFacingFrames() { return new Rectangle[] { new Rectangle(140, 223, 18, 30), new Rectangle(169, 223, 10, 30), new Rectangle(186, 223, 33, 30)}; }

        public static int SpringColorOffset { get { return 37; } }

        public static int SpringFrameTwoOffset { get { return 8; } }

        public static int SpringFrameThreeOffset { get { return -16; } }
    }
}
