using BasketCore.Configurations;
using BasketCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Context
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext (DbContextOptions<MainDatabaseContext> options)
            : base(options)
        { }

        //Add-Migration InitialCreate
        //Update-Database

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new StatsConfiguration());

            builder.Entity<Player>().HasData(
            #region Player
                new Player
                {
                    Id = 1,
                    FirstName = "Patrick",
                    LastName = "Beverley",
                    Height = 185,
                    Weight = 81.6,
                    Position = Enums.Position.PointGuard,
                    Number = 21,
                    BirthDate = new DateTime(1988, 12, 7)
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Paul",
                    LastName = "George",
                    Height = 203,
                    Weight = 99.8,
                    Position = Enums.Position.SmallForward,
                    Number = 13,
                    BirthDate = new DateTime(1990, 2, 5)
                },
                new Player
                {
                    Id = 3,
                    FirstName = "Kawhi",
                    LastName = "Leonard",
                    Height = 201,
                    Weight = 102.1,
                    Position = Enums.Position.SmallForward,
                    Number = 2,
                    BirthDate = new DateTime(1991, 6, 29)
                },
                new Player
                {
                    Id = 4,
                    FirstName = "Lou",
                    LastName = "Williams",
                    Height = 185,
                    Weight = 79.4,
                    Position = Enums.Position.ShootingGuard,
                    Number = 23,
                    BirthDate = new DateTime(1986, 10, 27)
                },
                new Player
                {
                    Id = 5,
                    FirstName = "Ivica",
                    LastName = "Zubac",
                    Height = 213,
                    Weight = 108.9,
                    Position = Enums.Position.Center,
                    Number = 40,
                    BirthDate = new DateTime(1997, 3, 18)
                },
                new Player
                {
                    Id = 6,
                    FirstName = "Montrezl",
                    LastName = "Harrell",
                    Height = 201,
                    Weight = 108.9,
                    Position = Enums.Position.PowerForward,
                    Number = 5,
                    BirthDate = new DateTime(1994, 1, 26)
                },
                new Player
                {
                    Id = 7,
                    FirstName = "Reggie",
                    LastName = "Jackson",
                    Height = 190,
                    Weight = 94.3,
                    Position = Enums.Position.ShootingGuard,
                    Number = 1,
                    BirthDate = new DateTime(1990, 4, 16)
                },
                new Player
                {
                    Id = 8,
                    FirstName = "Landry",
                    LastName = "Shamet",
                    Height = 193,
                    Weight = 86.2,
                    Position = Enums.Position.ShootingGuard,
                    Number = 20,
                    BirthDate = new DateTime(1997, 3, 13)
                },
                new Player
                {
                    Id = 9,
                    FirstName = "Marcus",
                    LastName = "Morris Sr.",
                    Height = 203,
                    Weight = 98.9,
                    Position = Enums.Position.PowerForward,
                    Number = 31,
                    BirthDate = new DateTime(1989, 9, 2)
                },
                new Player
                {
                    Id = 10,
                    FirstName = "JaMychal",
                    LastName = "Green",
                    Height = 203,
                    Weight = 103,
                    Position = Enums.Position.SmallForward,
                    Number = 4,
                    BirthDate = new DateTime(1990, 6, 21)
                }                
            );
            #endregion
            #region Game
            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    OpponentName = "Los Angeles Lakers",
                    Date = new DateTime(2020, 9, 1),
                    Court = "Staples Center",
                    GameType = Enums.GameType.Towarzyski
                },
                new Game
                {
                    Id = 2,
                    OpponentName = "Philadelphia 76ers",
                    Date = new DateTime(2020, 9, 3),
                    Court = "Wells Fargo Center",
                    GameType = Enums.GameType.Ligowy
                },
                new Game
                {
                    Id = 3,
                    OpponentName = "New Orleans Pelicans",
                    Date = new DateTime(2020, 9, 6),
                    Court = "New Orleans Arena",
                    GameType = Enums.GameType.Ligowy
                },
                new Game
                {
                    Id = 4,
                    OpponentName = "Chicago Bulls",
                    Date = new DateTime(2020, 9, 14),
                    Court = "United Center",
                    GameType = Enums.GameType.Pucharowy
                },
                new Game
                {
                    Id = 5,
                    OpponentName = "San Antonio Spurs",
                    Date = new DateTime(2020, 9, 20),
                    Court = "AT&T Center",
                    GameType = Enums.GameType.Ligowy
                }
            );
            #endregion
            #region Stats
            builder.Entity<Stats>().HasData(
                new Stats
                {
                    Id = 1,
                    GameId = 1,
                    PlayerId = 1,
                    Points = 5,
                    Assists = 3,
                    Rebounds = 2,
                    Steals = 0,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 2,
                    GameId = 1,
                    PlayerId = 2,
                    Points = 25,
                    Assists = 3,
                    Rebounds = 6,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 3,
                    GameId = 1,
                    PlayerId = 3,
                    Points = 30,
                    Assists = 6,
                    Rebounds = 8,
                    Steals = 3,
                    Blocks = 1,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 4,
                    GameId = 1,
                    PlayerId = 4,
                    Points = 12,
                    Assists = 7,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 5,
                    GameId = 1,
                    PlayerId = 5,
                    Points = 5,
                    Assists = 2,
                    Rebounds = 11,
                    Steals = 1,
                    Blocks = 4,
                    Fauls = 5
                },
                new Stats
                {
                    Id = 6,
                    GameId = 1,
                    PlayerId = 6,
                    Points = 11,
                    Assists = 4,
                    Rebounds = 10,
                    Steals = 1,
                    Blocks = 3,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 7,
                    GameId = 1,
                    PlayerId = 7,
                    Points = 5,
                    Assists = 3,
                    Rebounds = 2,
                    Steals = 0,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 8,
                    GameId = 1,
                    PlayerId = 8,
                    Points = 14,
                    Assists = 2,
                    Rebounds = 2,
                    Steals = 0,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 9,
                    GameId = 1,
                    PlayerId = 9,
                    Points = 15,
                    Assists = 2,
                    Rebounds = 2,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 10,
                    GameId = 1,
                    PlayerId = 10,
                    Points = 5,
                    Assists = 1,
                    Rebounds = 3,
                    Steals = 0,
                    Blocks = 1,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 11,
                    GameId = 2,
                    PlayerId = 1,
                    Points = 9,
                    Assists = 11,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 12,
                    GameId = 2,
                    PlayerId = 2,
                    Points = 22,
                    Assists = 5,
                    Rebounds = 3,
                    Steals = 0,
                    Blocks = 1,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 13,
                    GameId = 2,
                    PlayerId = 3,
                    Points = 40,
                    Assists = 4,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 14,
                    GameId = 2,
                    PlayerId = 4,
                    Points = 11,
                    Assists = 12,
                    Rebounds = 4,
                    Steals = 0,
                    Blocks = 0,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 15,
                    GameId = 2,
                    PlayerId = 5,
                    Points = 3,
                    Assists = 7,
                    Rebounds = 5,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 16,
                    GameId = 2,
                    PlayerId = 6,
                    Points = 15,
                    Assists = 2,
                    Rebounds = 11,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 5
                },
                new Stats
                {
                    Id = 17,
                    GameId = 2,
                    PlayerId = 7,
                    Points = 9,
                    Assists = 9,
                    Rebounds = 5,
                    Steals = 0,
                    Blocks = 1,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 18,
                    GameId = 2,
                    PlayerId = 8,
                    Points = 20,
                    Assists = 4,
                    Rebounds = 2,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 19,
                    GameId = 2,
                    PlayerId = 9,
                    Points = 10,
                    Assists = 3,
                    Rebounds = 6,
                    Steals = 0,
                    Blocks = 3,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 20,
                    GameId = 2,
                    PlayerId = 10,
                    Points = 10,
                    Assists = 0,
                    Rebounds = 5,
                    Steals = 1,
                    Blocks = 2,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 21,
                    GameId = 3,
                    PlayerId = 1,
                    Points = 7,
                    Assists = 11,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 22,
                    GameId = 3,
                    PlayerId = 2,
                    Points = 29,
                    Assists = 8,
                    Rebounds = 6,
                    Steals = 0,
                    Blocks = 1,
                    Fauls = 5
                },
                new Stats
                {
                    Id = 23,
                    GameId = 3,
                    PlayerId = 3,
                    Points = 37,
                    Assists = 5,
                    Rebounds = 5,
                    Steals = 3,
                    Blocks = 1,
                    Fauls = 5
                },
                new Stats
                {
                    Id = 24,
                    GameId = 3,
                    PlayerId = 4,
                    Points = 18,
                    Assists = 4,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 25,
                    GameId = 3,
                    PlayerId = 5,
                    Points = 10,
                    Assists = 1,
                    Rebounds = 9,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 6
                },
                new Stats
                {
                    Id = 26,
                    GameId = 3,
                    PlayerId = 6,
                    Points = 6,
                    Assists = 2,
                    Rebounds = 11,
                    Steals = 1,
                    Blocks = 2,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 27,
                    GameId = 3,
                    PlayerId = 7,
                    Points = 4,
                    Assists = 5,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 28,
                    GameId = 3,
                    PlayerId = 8,
                    Points = 6,
                    Assists = 5,
                    Rebounds = 0,
                    Steals = 2,
                    Blocks = 2,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 29,
                    GameId = 3,
                    PlayerId = 9,
                    Points = 16,
                    Assists = 3,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 5
                },
                new Stats
                {
                    Id = 30,
                    GameId = 3,
                    PlayerId = 10,
                    Points = 11,
                    Assists = 1,
                    Rebounds = 4,
                    Steals = 0,
                    Blocks = 2,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 41,
                    GameId = 4,
                    PlayerId = 1,
                    Points = 9,
                    Assists = 6,
                    Rebounds = 2,
                    Steals = 2,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 42,
                    GameId = 4,
                    PlayerId = 2,
                    Points = 23,
                    Assists = 5,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 43,
                    GameId = 4,
                    PlayerId = 3,
                    Points = 29,
                    Assists = 4,
                    Rebounds = 9,
                    Steals = 2,
                    Blocks = 1,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 44,
                    GameId = 4,
                    PlayerId = 4,
                    Points = 10,
                    Assists = 9,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 45,
                    GameId = 4,
                    PlayerId = 5,
                    Points = 11,
                    Assists = 2,
                    Rebounds = 9,
                    Steals = 0,
                    Blocks = 3,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 46,
                    GameId = 4,
                    PlayerId = 6,
                    Points = 15,
                    Assists = 3,
                    Rebounds = 11,
                    Steals = 0,
                    Blocks = 2,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 47,
                    GameId = 4,
                    PlayerId = 7,
                    Points = 4,
                    Assists = 8,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 48,
                    GameId = 4,
                    PlayerId = 8,
                    Points = 13,
                    Assists = 1,
                    Rebounds = 5,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 49,
                    GameId = 4,
                    PlayerId = 9,
                    Points = 13,
                    Assists = 3,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 50,
                    GameId = 4,
                    PlayerId = 10,
                    Points = 8,
                    Assists = 2,
                    Rebounds = 3,
                    Steals = 0,
                    Blocks = 1,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 51,
                    GameId = 5,
                    PlayerId = 1,
                    Points = 5,
                    Assists = 7,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 52,
                    GameId = 5,
                    PlayerId = 2,
                    Points = 24,
                    Assists = 8,
                    Rebounds = 5,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 53,
                    GameId = 5,
                    PlayerId = 3,
                    Points = 32,
                    Assists = 5,
                    Rebounds = 6,
                    Steals = 1,
                    Blocks = 2,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 54,
                    GameId = 5,
                    PlayerId = 4,
                    Points = 15,
                    Assists = 3,
                    Rebounds = 5,
                    Steals = 2,
                    Blocks = 2,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 55,
                    GameId = 5,
                    PlayerId = 5,
                    Points = 9,
                    Assists = 4,
                    Rebounds = 13,
                    Steals = 2,
                    Blocks = 2,
                    Fauls = 4
                },
                new Stats
                {
                    Id = 56,
                    GameId = 5,
                    PlayerId = 6,
                    Points = 15,
                    Assists = 3,
                    Rebounds = 8,
                    Steals = 4,
                    Blocks = 2,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 57,
                    GameId = 5,
                    PlayerId = 7,
                    Points = 6,
                    Assists = 2,
                    Rebounds = 4,
                    Steals = 1,
                    Blocks = 2,
                    Fauls = 3
                },
                new Stats
                {
                    Id = 58,
                    GameId = 5,
                    PlayerId = 8,
                    Points = 12,
                    Assists = 1,
                    Rebounds = 3,
                    Steals = 1,
                    Blocks = 1,
                    Fauls = 1
                },
                new Stats
                {
                    Id = 59,
                    GameId = 5,
                    PlayerId = 9,
                    Points = 10,
                    Assists = 4,
                    Rebounds = 4,
                    Steals = 0,
                    Blocks = 0,
                    Fauls = 2
                },
                new Stats
                {
                    Id = 60,
                    GameId = 5,
                    PlayerId = 10,
                    Points = 7,
                    Assists = 4,
                    Rebounds = 2,
                    Steals = 1,
                    Blocks = 0,
                    Fauls = 2
                }
            );
            #endregion

        }
    }
}
