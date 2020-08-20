using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    interface ISpring : IBlock
    {
        bool IsHorizontal { get; set; }
    }
}
