using BasketCore.Context;
using BasketCore.Enums;
using BasketCore.Models;
using BasketCore.Utils;
using BasketCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public IEnumerable<GameVM> GetGames()
        {
            List<GameVM> data = MainDatabaseContext.Games.Select(x => new GameVM()
            {
                Id = x.Id,
                OpponentName = x.OpponentName,
                Court = x.Court,
                Date = x.Date,
                GameTypeName = x.GameType.GetDisplayName()
            }).ToList();
            return data;
        }
        public async Task<GameVM> GetGameById(int id)
        {
            Game game = await MainDatabaseContext.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            GameVM gameVM = new GameVM
            {
                Id = game.Id,
                OpponentName = game.OpponentName,
                Court = game.Court,
                GameType = (int)game.GameType,
            };
            return gameVM;
        }
        public GameVM UpdateGame(GameVM model)
        {
            Game game = MainDatabaseContext.Games.Where(x => x.Id == model.Id).FirstOrDefault();
            game.OpponentName = model.OpponentName;
            game.Court = model.Court;
            game.Date = model.Date;
            game.GameType = (GameType)model.GameType;

            MainDatabaseContext.Games.Update(game);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteGame(int id)
        {
            Game game = MainDatabaseContext.Games.Where(x => x.Id == id).FirstOrDefault();
            if (game == null)
            {
                throw new ArgumentNullException();
            }
            MainDatabaseContext.Games.Remove(game);
            MainDatabaseContext.SaveChanges();

            List<Stats> gameStats = MainDatabaseContext.Stats.Where(x => x.GameId == id).ToList();
            MainDatabaseContext.Stats.RemoveRange(gameStats);
            MainDatabaseContext.SaveChanges();

        }

        public Game AddGame(GameAddVM model)
        {
            Game game = new Game
            {
                OpponentName = model.add_opponentname,
                Court = model.add_court,
                Date = model.add_date,
                GameType = (GameType)model.add_gametype
            };
            MainDatabaseContext.Games.Add(game);
            MainDatabaseContext.SaveChanges();

            AddStatsRecordsToGame(game.Id);

            return game;
        }
        internal void AddStatsRecordsToGame(int gameId)
        {
            List<Player> players = MainDatabaseContext.Players.ToList();
            foreach(var item in players)
            {
                Stats stats = new Stats
                {
                    GameId = gameId,
                    PlayerId = item.Id
                };
                MainDatabaseContext.Stats.Add(stats);
                MainDatabaseContext.SaveChanges();
            }
        }
    }
}
