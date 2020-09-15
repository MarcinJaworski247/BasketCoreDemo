using BasketCore.Repositories;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Services
{
    public class StatsService : IStatsService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public StatsService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public string GetOpponentName(int gameId)
        {
            return RepositoriesWrapper.StatsRepository.GetOpponentName(gameId);
        }
        public List<GameStatsVM> GetGameStats(int gameId)
        {
            return RepositoriesWrapper.StatsRepository.GetGameStats(gameId);
        }
        public GameStatsVM GetPlayerStats(int id, int gameId)
        {
            return RepositoriesWrapper.StatsRepository.GetPlayerStats(id, gameId);
        }
        public void UpdatePlayerStats(GameStatsVM model)
        {
            RepositoriesWrapper.StatsRepository.UpdatePlayerStats(model);
        }
        public IEnumerable<AvgStatsVM> GetAvgStats()
        {
            return RepositoriesWrapper.StatsRepository.GetAvgStats();
        }
    }
}
