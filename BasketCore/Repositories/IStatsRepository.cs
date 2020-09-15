using BasketCore.Models;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public interface IStatsRepository : IRepository<Stats>
    {
        string GetOpponentName(int gameId);
        List<GameStatsVM> GetGameStats(int gameId);
        GameStatsVM GetPlayerStats(int id, int gameId);
        void UpdatePlayerStats(GameStatsVM model);
        IEnumerable<AvgStatsVM> GetAvgStats();
    }
}
