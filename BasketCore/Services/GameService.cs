using BasketCore.Models;
using BasketCore.Repositories;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Services
{
    public class GameService : IGameService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public GameService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public IEnumerable<GameVM> GetGames()
        {
            return RepositoriesWrapper.GameRepository.GetGames();
        }
        public async Task<GameVM> GetGameById(int id)
        {
            return await RepositoriesWrapper.GameRepository.GetGameById(id);
        }
        public GameVM UpdateGame(GameVM model)
        {
            return RepositoriesWrapper.GameRepository.UpdateGame(model);
        }
        public void DeleteGame(int id)
        {
            RepositoriesWrapper.GameRepository.DeleteGame(id);
        }
        public Game AddGame(GameAddVM model)
        {
            return RepositoriesWrapper.GameRepository.AddGame(model);
        }
    }
}
