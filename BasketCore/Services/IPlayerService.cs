using BasketCore.Models;
using BasketCore.Utils;
using BasketCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Services
{
    public interface IPlayerService
    {
        IEnumerable<PlayerVM> GetPlayers();
        Task<PlayerVM> GetPlayerById(int id);
        PlayerVM UpdatePlayer(PlayerVM model);
        void DeletePlayer(int id);
        Player AddPlayer(PlayerAddVM model);
        List<SelectModelBinder<int>> GetPlayersToLookup();
    }
}
