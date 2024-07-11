using AutoMapper;
using GameAppWebAPI.Controllers;
using GameAppWebAPI.Entities;
using GameAppWebAPI.Helpers;
using GameAppWebAPI.Model;

namespace GameAppWebAPI.Repository
{
    public class GameRepository:IGameRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private DataContext _context;        
        private ILogger<GameRepository> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public GameRepository(DataContext context, ILogger<GameRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Game>> GetAllGamesAsync()
        {
            return  _context.Games.AsAsyncEnumerable();
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            return getGame(id);
        }


        public Task<IAsyncEnumerable<Game>> GetGamesWithPaginationAsync(int count, int page)
        {
            return (Task<IAsyncEnumerable<Game>>)_context.Games.Skip(page - 1 * count).Take(count).OrderBy(x => x.Title).AsAsyncEnumerable();
        }


        public async Task CreateGameAsync(CreateRequest model)
        {
            // validate
            if (_context.Games.Any(x => x.Title == model.Title && x.Id == model.Id))
                throw new AppException("Game with the title '" + model.Title + "' already exists");

            // map model to new game object
            //var game = _mapper.Map<Game>(model);

            Game game = new Game
            {
                Id = new Guid(),
                Title = model.Title,
                Description = model.Description,
                Genre = model.Genre,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                StockQuantity = model.StockQuantity
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
            if(game.)
            int returnVal = await _context.SaveChangesAsync();
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
