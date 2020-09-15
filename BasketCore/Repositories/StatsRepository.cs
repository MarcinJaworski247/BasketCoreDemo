using BasketCore.Context;
using BasketCore.Models;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public class StatsRepository : Repository<Stats>, IStatsRepository
    {
        public StatsRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public string GetOpponentName(int gameId)
        {
            return MainDatabaseContext.Stats.Where(x => x.GameId == gameId).Select(x => x.Game.OpponentName).FirstOrDefault();
        }
        public List<GameStatsVM> GetGameStats(int gameId)
        {
            List<GameStatsVM> data = MainDatabaseContext.Stats.Where(x => x.GameId == gameId).Select(x => new GameStatsVM()
            {
                PlayerId = x.PlayerId,
                GameId = x.GameId,
                Name = x.Player.FirstName + " " + x.Player.LastName,
                Points = x.Points,
                Assists = x.Assists,
                Rebounds = x.Rebounds,
                Steals = x.Steals,
                Blocks = x.Blocks,
                Fauls = x.Fauls
            }).ToList();
            return data;
        }
        public GameStatsVM GetPlayerStats(int id, int gameId)
        {
            Stats stats = MainDatabaseContext.Stats.Where(x => x.PlayerId == id && x.GameId == gameId).FirstOrDefault();
            GameStatsVM statsVM = new GameStatsVM
            {
                GameId = stats.GameId,
                PlayerId = stats.PlayerId,
                Name = MainDatabaseContext.Players.Where(x => x.Id == stats.PlayerId).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                Points = stats.Points,
                Assists = stats.Assists,
                Rebounds = stats.Rebounds,
                Steals = stats.Steals,
                Blocks = stats.Blocks,
                Fauls = stats.Fauls
            };
            return statsVM;
        }
        public void UpdatePlayerStats(GameStatsVM model)
        {
            Stats stats = MainDatabaseContext.Stats.Where(x => x.PlayerId == model.PlayerId && x.GameId == model.GameId).FirstOrDefault();
            stats.Points = model.Points;
            stats.Assists = model.Assists;
            stats.Rebounds = model.Rebounds;
            stats.Steals = model.Steals;
            stats.Blocks = model.Blocks;
            stats.Fauls = model.Fauls;

            MainDatabaseContext.Stats.Update(stats);
            MainDatabaseContext.SaveChanges();
        }
        public IEnumerable<AvgStatsVM> GetAvgStats()
        {
            IEnumerable<AvgStatsVM> data = from stat in MainDatabaseContext.Stats
                                    group stat by stat.PlayerId into statGroup
                                    select new AvgStatsVM
                                    {
                                        PlayerId = statGroup.Key,
                                        Points = Math.Round(statGroup.Average(x => x.Points),2),
                                        Assists = Math.Round(statGroup.Average(x => x.Assists), 2),
                                        Rebounds = Math.Round(statGroup.Average(x => x.Rebounds), 2),
                                        Steals = Math.Round(statGroup.Average(x => x.Steals), 2),
                                        Blocks = Math.Round(statGroup.Average(x => x.Blocks), 2),
                                        Fauls = Math.Round(statGroup.Average(x => x.Fauls), 2)
                                    };

            return data;
        }
    }
}
