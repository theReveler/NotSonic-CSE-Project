﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    interface IPlatform : IBlock, IGameObject
    {
        void SetDirection(Direction direction);
    }
}
