
namespace MassCultureLibrary.Animes
{
    public class AnimeService:IAnimeService
    {
        IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeResitory)
        {
            _animeRepository = animeResitory;
        }

        public async Task<Anime> AddAnimeAsync(Anime anime)
        {
            return await _animeRepository.AddAsync(anime);
        }

        public Task DeleteAnimeAsync(Guid animeId)
        {
            throw new NotImplementedException();
        }

        public Task<Anime?> GetAnimeByIdAsync(Guid animeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anime>> GetAnimeByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Anime> UpdateAnimeAsync(Guid animeId, AnimeUpdateDto updateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
