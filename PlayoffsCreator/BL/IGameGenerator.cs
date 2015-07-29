using System.Collections.Generic;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.BL
{
    internal interface IGameGenerator
    {
        IEnumerable<GameModel> Generate();
    }
}