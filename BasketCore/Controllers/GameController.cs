using BasketCore.Enums;
using BasketCore.Models;
using BasketCore.Services;
using BasketCore.Utils;
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
    public class GameController : ControllerBase
    {
        private readonly IGameService GameService;
        public GameController(IGameService gameService)
        {
            this.GameService = gameService;
        }
        [HttpGet("getGames")]
        public ActionResult GetGames()
        {
            IEnumerable<GameVM> data = GameService.GetGames();
            return Ok(data);
        }
        [HttpGet("getGameDetails/{id}")]
        public async Task<ActionResult<GameVM>> GetGameDetails(int id)
        {
            var data = await GameService.GetGameById(id);
            return Ok(data);
        }
        [HttpPut("updateGame")]
        public ActionResult<GameVM> UpdateGame([FromBody] GameVM model)
        {
            if (model == null)
                return NotFound();

            GameVM result = GameService.UpdateGame(model);

            return Ok(result);
        }
        [HttpDelete("deleteGame/{id}")]
        public ActionResult DeleteGame(int id)
        {
            GameService.DeleteGame(id);
            return Ok();
        }
        [HttpPut("addGame")]
        public ActionResult<Game> AddGame([FromBody] GameAddVM model)
        {
            if (model == null)
                throw new ArgumentNullException();
            Game game = GameService.AddGame(model);
            return Ok(game);
        }
        [HttpGet("getGameTypes")]
        public ActionResult GetGameTypesToSelectBox()
        {
            List<EnumModelBinder> gameTypes = EnumHelpers.GetEnumBinderList<GameType>();
            return Ok(gameTypes);
        }
    }
}
