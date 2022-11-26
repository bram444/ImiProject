using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GenreInfoService : IGenreService
    {
        private static List<GenreInfo> inMemoryGenre = new List<GenreInfo>
        {
            new GenreInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Name ="FPS",
              Description=""
            },
            new GenreInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000002"),
             Name ="Puzzle",
             Description=""
            }
        };
        public async Task<List<GenreInfo>> GetAllGenre()
        {
            return await Task.FromResult(inMemoryGenre);
        }

        public async Task<GenreInfo> GenreById(Guid id)
        {
            return await Task.FromResult(inMemoryGenre.Where(genre => genre.Id == id).First());
        }

        public Task<GenreInfo> UpdateGenre(GenreInfo genre)
        {
            var genreInfoEdit = GenreById(genre.Id);
            genreInfoEdit.Result.Name = genre.Name;
            genreInfoEdit.Result.Description = genre.Description;

            return genreInfoEdit;
        }

        public Task DeleteGenre(Guid id)
        {
            inMemoryGenre.Remove(GenreById(id).Result);
            return Task.CompletedTask;
        }

        public Task<GenreInfo> AddGenre(GenreInfo genre)
        {
            inMemoryGenre.Add(genre);
            return GenreById(genre.Id);
        }
    }
}