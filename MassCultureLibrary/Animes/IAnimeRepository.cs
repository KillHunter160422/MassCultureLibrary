
namespace MassCultureLibrary.Animes
{
    public interface IAnimeRepository
    {
        Task<Anime> AddAsync(Anime anime);
        Task<Anime?> GetByIdAsync(Guid id);
        Task UpdateAsync(Anime anime);
        Task DeleteAsync(Guid id);
        void AddAsync();
    }

}
