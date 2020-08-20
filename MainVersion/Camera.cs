using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public class Camera
    {

        private Matrix transform;
        private Vector2 position;
        private Vector2 focus;
        private Vector2 previousFrame;
        private Vector2 anchor;
        private bool isLocked = true;

        public Camera()
        {
            previousFrame = new Vector2(0, 0);
        }
        public Matrix Transform { get { return transform; } }

        public Vector2 Position { get { return position; } }

        public static int ScreenWidth { get { return GraphicsDeviceManager.DefaultBackBufferWidth; } }

        public static int ScreenHeight { get { return GraphicsDeviceManager.DefaultBackBufferHeight; } }

        //^ populates the width and height with whatever the window has (incase we change it), do we need to manually set these for some reason?
        //public int ScreenWidth = 750;
        //public int ScreenHeight = 525; 


        public void GetFocus(Sonic sonic) //And other arguments
        {
            focus.X = sonic.Position.X;
            focus.Y = sonic.Position.Y;
            //average the elements
        }

        public void VerticalSmoothing(Sonic sonic)
        {
            Vector2 temp = focus;
            if (Math.Abs(focus.Y - previousFrame.Y) < 3 && !sonic.HasJumped)
            {
                focus.Y = previousFrame.Y;
            } else { previousFrame = temp; }
            
        }

        public void SetAnchor()
        {
            if (isLocked)
                anchor = focus;
        }

        public void Update(Sonic sonic)
        {

            GetFocus(sonic);
            VerticalSmoothing(sonic);
            SetAnchor();

            float scale = 1.5f;

            //this and the 375 below make the camera 'snap'; gets rid of the shaking problem when running across the ground
            position.X = focus.X - ((ScreenWidth) / (scale + .2f) / 2);
            position.Y = focus.Y - (ScreenHeight / scale / 2);

            if (position.X < 0)
            {
                position.X = 0;
            }

            //Three Vertical divisions
            if(sonic.Position.Y < 0)
            {
                position.Y -= (float)(focus.Y * .3);
            }

            if (sonic.Position.Y > 0 && sonic.Position.Y <= 375)
            {
                position.Y -= (float)(focus.Y * .1);
            }
            
            if(sonic.Position.Y > 375)
            {
                position.Y = 400;
            }

            transform = Matrix.CreateTranslation(new Vector3(-position, 0));
            transform = Matrix.Multiply(transform, Matrix.CreateScale(new Vector3(scale, scale, 1)));
        }
    
    }
}
