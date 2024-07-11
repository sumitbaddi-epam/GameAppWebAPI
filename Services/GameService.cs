using AutoMapper;
using GameAppWebAPI.Entities;
using GameAppWebAPI.Helpers;
using GameAppWebAPI.Model;
using GameAppWebAPI.Repository;
using GameAppWebAPI.Services.IServices;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace GameAppWebAPI.Services
{
    public class GameService : IGameService
    {
        //DI objects for constructor injuction
        private IGameRepository _gameRepository;
        private ILogger<GameService> _logger;
        private readonly IMapper _mapper;

        public GameService(
            IGameRepository gameRepository, 
            IMapper mapper, 
            ILogger<GameService> logger
        )
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<IAsyncEnumerable<Game>> GetAllGamesAsync()
        {
            _logger.Log(LogLevel.Information, "Call to Game Repository method GetAllGamesAsync");
            return _gameRepository.GetAllGamesAsync();
        }

        public Task<Game> GetGameByIdAsync(Guid id)
        {
            return _gameRepository.GetGameByIdAsync(id);
        }


        public Task<IAsyncEnumerable<Game>> GetGamesWithPaginationAsync(int count, int page)
        {
            return _gameRepository.GetGamesWithPaginationAsync();
        }


        public async Task CreateGameAsync(CreateRequest model)
        {
            // validate
            if (_context.Games.Any(x => x.Title == model.Title && x.Id==model.Id))
                throw new AppException("Game with the title '" + model.Title + "' already exists");

            // map model to new game object
            //var game = _mapper.Map<Game>(model);

            Game game = new Game
            {
                Id = new Guid(),
                Title = model.Title,
                Description= model.Description,
                Genre= model.Genre,
                Price= model.Price,
                ReleaseDate= model.ReleaseDate, 
                StockQuantity= model.StockQuantity
            };
            
            // save game
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(UpdateRequest model)
        {
            var game = getGame(model.Id);

            // validate
            if (model.Title != game.Title && _context.Games.Any(x => x.Title == model.Title))
                throw new AppException("Game with the title '" + model.Title + "' already exists");

            // copy model to game using and save
            //_mapper.Map(model, game);

            //Title = model.Title,
            game.Description = model.Description;
            game.Genre = model.Genre;
            game.Price = model.Price;
            game.ReleaseDate = model.ReleaseDate;
            game.StockQuantity = model.StockQuantity;
            
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(Guid id)
        {
            var game = getGame(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }


        #region Helper methods

        private Game getGame(Guid id)
        {
            var game = _context.Games.Find(id);
            if (game == null) throw new KeyNotFoundException("Game not found");
            return game;
        }
        #endregion
    }
}
