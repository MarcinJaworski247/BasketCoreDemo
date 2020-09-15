using BasketCore.Context;
using BasketCore.Enums;
using BasketCore.Models;
using BasketCore.Utils;
using BasketCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public IEnumerable<PlayerVM> GetPlayers()
        {
            List<PlayerVM> data = MainDatabaseContext.Players.Select(x => new PlayerVM()
            {
                Id = x.Id,
                FirstName = x.FirstName, 
                LastName = x.LastName,
                Number = x.Number,
                BirthDate = x.BirthDate,
                Height = x.Height,
                Weight = x.Weight,
                PositionName = x.Position.GetDisplayName()
            }).ToList();
            return data;
        }
        public async Task<PlayerVM> GetPlayerById(int id)
        {
            Player player = await MainDatabaseContext.Players.Where(x => x.Id == id).FirstOrDefaultAsync();
            PlayerVM playerVM = new PlayerVM
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Number = player.Number,
                Position = (int)player.Position,
                BirthDate = player.BirthDate,
                Height = player.Height,
                Weight = player.Weight
            };
            return playerVM;
        }
        public PlayerVM UpdatePlayer(PlayerVM model)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == model.Id).FirstOrDefault();
            player.FirstName = model.FirstName;
            player.LastName = model.LastName;
            player.Height = model.Height;
            player.Weight = model.Weight;
            player.Position = (Position)model.Position;
            player.Number = model.Number;
            player.BirthDate = model.BirthDate;

            MainDatabaseContext.Players.Update(player);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeletePlayer(int id)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == id).FirstOrDefault();
            if (player == null)
            {
                throw new ArgumentNullException();
            }
            MainDatabaseContext.Players.Remove(player);
            MainDatabaseContext.SaveChanges();

            List<Stats> playersStats = MainDatabaseContext.Stats.Where(x => x.PlayerId == id).ToList();
            MainDatabaseContext.Stats.RemoveRange(playersStats);
            MainDatabaseContext.SaveChanges();
        }

        public Player AddPlayer(PlayerAddVM model)
        {
            Player player = new Player
            {
                FirstName = model.add_firstname,
                LastName = model.add_lastname,
                Height = model.add_height,
                Weight = model.add_weight,
                Position = (Position)model.add_position,
                Number = model.add_number,
                BirthDate = model.add_birthdate
            };
            MainDatabaseContext.Players.Add(player);
            MainDatabaseContext.SaveChanges();
            return player;
        }
        public List<SelectModelBinder<int>> GetPlayersToLookup()
        {
            List<Player> players = MainDatabaseContext.Players.ToList();
            List<SelectModelBinder<int>> result = players.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.FirstName + " " + x.LastName
            }).ToList();
            return result;
        }
    }
}
