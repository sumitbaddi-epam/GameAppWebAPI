using Asp.Versioning;
using GameAppWebAPI.Model;
using GameAppWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;
        private ILogger<GamesController> _logger;

        public GamesController(IGameService gameService, ILogger<GamesController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }


        // GET: api/<GamesController>
        /// <summary>
        /// Gets all the games
        /// </summary>
        /// <returns>List of all games</returns>
        [HttpGet]
        [ApiVersion("1.0")]        
        public async Task<IActionResult> GetAllGamesAsync()
        {
            _logger.Log(LogLevel.Information, "Call into Game Controller GetAllGamesAsync method");
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        // GET api/<GamesController>/5
        /// <summary>
        /// Gets the game with the specific id
        /// </summary>
        /// <param name="id">a global unique identifier value</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            return Ok(game);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGamesWithPaginationAsync([FromQuery] int count, int page)
        {

            var games = await _gameService.GetGamesWithPagination(count, page);
            return Ok(games);

        }


        // POST api/<GamesController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRequest model)
        {
            await _gameService.Create(model);
            return Ok(new { message = "Game Created" });
        }

        // PUT api/<GamesController>/5
        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRequest model)
        {
            await _gameService.Update(model);
            return Ok(new { message = "Game Updated" });
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.Delete(id);
            return Ok(new { message = "Game Deleted" });

        }
    }
}
