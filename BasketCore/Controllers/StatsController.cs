using BasketCore.Services;
using BasketCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService StatsService;
        public StatsController(IStatsService statsService)
        {
            this.StatsService = statsService;
        }
        [HttpGet("getOpponentName/{gameId}")]
        public ActionResult GetOpponentName(int gameId)
        {
            string name = StatsService.GetOpponentName(gameId);
            return Ok(name);
        }
        [HttpGet("getGameStats/{gameId}")]
        public ActionResult GetGameStats(int gameId)
        {
            List<GameStatsVM> data = StatsService.GetGameStats(gameId);
            return Ok(data);
        }
        [HttpGet("getPlayerStats/{id}/{gameId}")]
        public ActionResult GetPlayerStats(int id, int gameId)
        {
            GameStatsVM data = StatsService.GetPlayerStats(id, gameId);
            return Ok(data);
        }
        [HttpPut("updatePlayerStats")]
        public ActionResult UpdatePlayerStats([FromBody] GameStatsVM model)
        {
            if (model == null)
                return NotFound();
            StatsService.UpdatePlayerStats(model);
            return Ok(true);
        }
        [HttpGet("getAvgStats")]
        public ActionResult GetAvgStats()
        {
            IEnumerable<AvgStatsVM> data = StatsService.GetAvgStats();
            return Ok(data);
        }
    }
}
