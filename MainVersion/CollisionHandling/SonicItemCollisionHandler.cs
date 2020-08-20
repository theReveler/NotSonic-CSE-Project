using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;
using static NotSonicGame.Game1;

namespace NotSonicGame
{
    class SonicItemCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            IItem item = (IItem)gameObject2;

            if (collisionType != Direction.None && (item is Ring || item is EndRing || (item is DroppedRing && ((DroppedRing)item).TimeUp < 350)))
            {
                if (item is Ring || item is DroppedRing)
                {
                    AssetStorage.PickUpRingSoundEffect.Play();
                }
                else if(item is EndRing)
                {
                    GameUtility.EndRingObtained = true;
                }
                item.GetPickedUp();
            }
        }
    }
}
