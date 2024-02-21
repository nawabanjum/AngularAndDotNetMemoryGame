using MemoryGame.DomainModels;
using MemoryGame.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoryGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryGameController : ControllerBase
    {
        // GET: api/<MemoryGameController>
        private readonly MemoryGameService _gameService;

        public MemoryGameController(MemoryGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost("start")]
        public IActionResult StartNewGame()
        {
            _gameService.InitializeGame();
            return Ok(_gameService.GetCurrentGameState());
        }

        [HttpGet("state")]
        public IActionResult GetGameState()
        {
            return Ok(_gameService.GetCurrentGameState());
        }

        [HttpPost("turn")]
        public IActionResult PlayerTurn([FromBody] PlayerTurnRequest request)
        {
            try
            {
                _gameService.HandlePlayerTurn(request.PlayerId, request.Card1Position, request.Card2Position);

                if (_gameService.IsGameEnded())
                {
                    return Ok(new { Message = "Game Ended", Winner = _gameService.GetCurrentGameState().Player1Score > _gameService.GetCurrentGameState().Player2Score ? 1 : 2 });
                }

                return Ok(_gameService.GetCurrentGameState());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("reset")]
        public IActionResult ResetGame()
        {
            _gameService.ResetGame();
            return Ok(_gameService.GetCurrentGameState());
        }
    }
}
