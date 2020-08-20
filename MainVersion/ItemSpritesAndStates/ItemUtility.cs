using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class ItemUtility
    {
        public static int GeneralMaxFrames { get { return 40; } }

        public static double GeneralItemFrameOneMultiplier { get { return 0.25; } }

        public static double GeneralItemFrameTwoMultiplier { get { return 0.50; } }

        public static double GeneralItemFrameThreeMultiplier { get { return 0.75; } }

        //Dropped Ring
        public static float FallingCapacityVelocity { get { return 3f; } }

        public static int DroppedRingCounter { get { return 400; } }

        public static float DroppedRingAccelerationX { get { return 0.99f; } }

        public static float DroppedRingAccelerationY { get { return 0.25f; } }

        //End Ring
        public static Rectangle[] GetEndRingFrames()
        {
            return new Rectangle[] { new Rectangle(5, 427, 65, 65), new Rectangle(69, 427, 65, 65), new Rectangle(134, 427, 65, 65), new Rectangle(194, 427, 65, 65) };
        }

        public static Rectangle[] GetPickedUpEndRingFrames()
        {
            return new Rectangle[] { new Rectangle(4, 608, 65, 65), new Rectangle(74, 608, 65, 65), new Rectangle(163, 608, 65, 65), new Rectangle(230, 608, 65, 65) };
        }

        //Invincibility

        public static int InvincibilityMaxFrames { get { return 16; } }

        public static Rectangle[] GetInvincibiltyFrames()
        {
           return new Rectangle[]{new Rectangle(20, 778, 49, 49),new Rectangle(73, 778, 49, 49),new Rectangle(127, 778, 49, 49),new Rectangle(180, 778, 49, 49)};
        }

        public static int InvincibiltyListLimit { get { return 4; } }

        //ItemSprites
        public static Rectangle InvincibleItemSpriteRectangle { get { return new Rectangle(131, 66, 17, 17); } }

        public static Rectangle OneUpItemSpriteRectangle { get { return new Rectangle(185, 66, 17, 17); } }

        public static Rectangle PowerSneakerItemSpriteRectangle { get { return new Rectangle(167, 66, 17, 17); } }

        public static Rectangle ShieldItemSpriteRectangle { get { return new Rectangle(149, 66, 17, 17); } }

        public static Rectangle SuperRingItemSpriteRectangle { get { return new Rectangle(113, 66, 17, 17); } }

        public static int SuperRings { get { return 10; } }

        public static int PositionOffset { get { return 3; } }

        //Ring
        public static Rectangle[] GetPickedUpRingFrames()
        {
            return new Rectangle[] { new Rectangle(30, 27, 17, 17), new Rectangle(48, 27, 17, 17), new Rectangle(66, 27, 17, 17), new Rectangle(84, 27, 17, 17)};
        }

        public static Rectangle[] GetRingFrames()
        {
            return new Rectangle[] { new Rectangle(30, 9, 17, 17), new Rectangle(48, 9, 17, 17), new Rectangle(66, 9, 17, 17), new Rectangle(84, 9, 17, 17) };
        }
      
        //Shield
        public static int ShieldMaxFrames { get{ return 24; } }

        public static Rectangle[] GetShieldFrames(){ return new Rectangle[] { new Rectangle(51, 306, 47, 43), new Rectangle(102, 306, 47, 43), new Rectangle(153, 306, 47, 43) }; }

    }
}
