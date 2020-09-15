using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public interface IRepositoriesWrapper : IDisposable
    {
        IGameRepository GameRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        IStatsRepository StatsRepository { get; }
        Task<int> CommitAsync();
    }
}
