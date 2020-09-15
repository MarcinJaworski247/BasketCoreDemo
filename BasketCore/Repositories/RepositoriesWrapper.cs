using BasketCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Repositories
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private readonly MainDatabaseContext _context;
        private GameRepository _gameRepository;
        private PlayerRepository _playerRepository;
        private StatsRepository _statsRepository;
        public RepositoriesWrapper(MainDatabaseContext context)
        {
            this._context = context;
        }
        public IGameRepository GameRepository => _gameRepository = _gameRepository ?? new GameRepository(_context);
        public IPlayerRepository PlayerRepository => _playerRepository = _playerRepository ?? new PlayerRepository(_context);
        public IStatsRepository StatsRepository => _statsRepository = _statsRepository ?? new StatsRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
