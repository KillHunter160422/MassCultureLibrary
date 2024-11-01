using FluentAssertions;
using MassCultureLibrary.Animes;
using MassCultureLibrary.Games;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassCultureLibrary.Tests
{
    public class AnimeMangaTests
    {
        private readonly IAnimeService _animeService;
        private readonly Anime _anime;
        public AnimeMangaTests()
        {
            var animeRepository = new Mock<IAnimeRepository>();
            animeRepository.Setup(x => x.AddAsync(It.IsAny<Anime>())).ReturnsAsync((Anime anime) => anime);
            var animeService = new AnimeService(animeRepository.Object);
            _animeService = animeService;
            _anime = new Anime {Id = Guid.NewGuid(), Title = "Наруто", Genre = "Экшен", Status = "Завершено" };
        }

        [Fact]
        public async Task AddAnime_ShouldAddAnimeCorrectly()
        {
            var anime = _anime;

            var result = await _animeService.AddAnimeAsync(anime);
            

            result.Should().NotBeNull();
            result.Title.Should().Be("Наруто");
        }

        [Fact]
        public async Task AddAnime_ShouldEqualsAddAnime()
        {
            var anime = _anime;

            var result = await _animeService.AddAnimeAsync(anime);

            result.Should().NotBeNull();
            result.Title.Should().Be("Наруто");



        }
        [Fact]
        public async Task GetAnimeByStatus_ShouldReturnAnimeWithCorrectStatus()
        {
            var status = "Онгоинг";

            var animes = await _animeService.GetAnimeByStatusAsync(status);

            animes.Should().NotBeEmpty();
            animes.All(a => a.Status == status).Should().BeTrue();
        }

        [Fact]
        public async Task UpdateAnime_ShouldUpdateAnimeStatus()
        {
            var animeId = _anime.Id;
            var updateInfo = new AnimeUpdateDto { Status = "Онгоинг" };

            var updatedAnime = await _animeService.UpdateAnimeAsync(animeId, updateInfo);

            updatedAnime.Should().NotBeNull();
            updatedAnime.Status.Should().Be("Онгоинг");
        }

        [Fact]
        public async Task DeleteAnime_ShouldRemoveAnime()
        {
            var animeId = _anime.Id;

            await _animeService.DeleteAnimeAsync(animeId);

            var anime = await _animeService.GetAnimeByIdAsync(animeId);
            anime.Should().BeNull();
        }
    }

}
