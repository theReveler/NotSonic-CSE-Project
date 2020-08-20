using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace NotSonicGame
{
    public class RandomLevel
    {

        private List<IGameObject> objectList;
        private Background background;

        internal RandomLevel(List<IGameObject> objects, Background b)
        {
            objectList = objects;
            background = b;
        }

        public List<IGameObject> returnObjectList()
        {
            return objectList;
        }

        public Background returnBackground()
        {
            return background;
        }
    }
}
