using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    interface IRing : IItem
    {
        Vector2 Position {get; set;}
    }
}
