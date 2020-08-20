using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    interface IBossState : IEnemyState
    {
        bool IsFacingLeft { get; }
    }
}
