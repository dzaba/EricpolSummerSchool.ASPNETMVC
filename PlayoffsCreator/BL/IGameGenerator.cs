using System.Collections.Generic;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.BL
{
    public interface IGameGenerator
    {
        IEnumerable<GameModel> Generate();
    }
}