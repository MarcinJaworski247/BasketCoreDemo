using AutoMapper;
using BasketCore.Enums;
using BasketCore.Models;
using BasketCore.Services;
using BasketCore.Utils;
using BasketCore.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public PlayerController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getPlayers")]
        public ActionResult GetPlayers()
        {
            IEnumerable<PlayerVM> data = PlayerService.GetPlayers();
            return Ok(data);
        }
        [HttpGet("getPlayerDetails/{id}")]
        public async Task<ActionResult<PlayerVM>> GetPlayerDetails(int id)
        {
            var data = await PlayerService.GetPlayerById(id);
            return Ok(data);
        }
        [HttpPut("updatePlayer")]
        public ActionResult<PlayerVM> UpdatePlayer([FromBody] PlayerVM model)
        {
            if (model == null)
                return NotFound();

            PlayerVM result = PlayerService.UpdatePlayer(model);

            return Ok(result);
        }
        [HttpDelete("deletePlayer/{id}")]
        public ActionResult DeletePlayer(int id)
        {
            PlayerService.DeletePlayer(id);
            return Ok();
        }
        [HttpPut("addPlayer")]
        public ActionResult<Player> AddPlayer([FromBody] PlayerAddVM model)
        {
            if (model == null)
                throw new ArgumentNullException();
            Player player = PlayerService.AddPlayer(model);
            return Ok(player);
        }
        [HttpGet("getPositions")]
        public ActionResult GetPositionsToSelectBox()
        {
            List<EnumModelBinder> positions = EnumHelpers.GetEnumBinderList<Position>();
            return Ok(positions);
        }
        [HttpGet("getPlayersToLookup")]
        public ActionResult GetPlayersToLookup()
        {
            List<SelectModelBinder<int>> players = PlayerService.GetPlayersToLookup();
            return Ok(players);
        }
    }
}
