using System.Collections.Generic;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.BL
{
    public interface ITreeDecorator
    {
        IEnumerable<GameModel> Decorate(IEnumerable<GameModel> games);
    }
}