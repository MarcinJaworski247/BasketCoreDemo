using AutoMapper;
using BasketCore.Models;
using BasketCore.Repositories;
using BasketCore.Utils;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public PlayerService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public IEnumerable<PlayerVM> GetPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetPlayers(); 
        }
        public async Task<PlayerVM> GetPlayerById(int id)
        {
            return await RepositoriesWrapper.PlayerRepository.GetPlayerById(id);
        }
        public PlayerVM UpdatePlayer(PlayerVM model)
        {
            return RepositoriesWrapper.PlayerRepository.UpdatePlayer(model);
        }
        public void DeletePlayer(int id)
        {
            RepositoriesWrapper.PlayerRepository.DeletePlayer(id);
        }
        public Player AddPlayer(PlayerAddVM model)
        {
            return RepositoriesWrapper.PlayerRepository.AddPlayer(model);
        }
        public List<SelectModelBinder<int>> GetPlayersToLookup()
        {
            return RepositoriesWrapper.PlayerRepository.GetPlayersToLookup();
        }
    }
}
