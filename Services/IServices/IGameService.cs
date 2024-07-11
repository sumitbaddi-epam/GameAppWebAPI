using GameAppWebAPI.Entities;
using GameAppWebAPI.Model;

namespace GameAppWebAPI.Services.IServices
{
    public interface IGameService
    {
        /// <summary>
        /// Interface for getting all the games
        /// </summary>
        /// <returns></returns>
        Task<IAsyncEnumerable<Game>> GetAllGamesAsync();  
        
        /// <summary>
        /// Gets a particular game details
        /// </summary>
        /// <param name="id">This is a GUID value</param>
        /// <returns></returns>
        Task<Game> GetGameByIdAsync(Guid id);

        /// <summary>
        /// Gets the games based on the page number and count
        /// </summary>
        /// <param name="count">Number of games to be fetched</param>
        /// <param name="page">Page number of the list of games</param>
        /// <returns></returns>
        Task<IAsyncEnumerable<Game>> GetGamesWithPaginationAsync(int count, int page);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateGameAsync(CreateRequest model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateGameAsync(UpdateRequest model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteGameAsync(Guid id);
    }
}
