using BasketCore.Models;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Services
{
    public interface IGameService
    {
        IEnumerable<GameVM> GetGames();
        Task<GameVM> GetGameById(int id);
        GameVM UpdateGame(GameVM model);
        void DeleteGame(int id);
        Game AddGame(GameAddVM model);
    }
}
