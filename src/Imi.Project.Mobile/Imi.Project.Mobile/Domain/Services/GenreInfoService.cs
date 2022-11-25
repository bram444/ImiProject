using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GenreInfoService
    {
        private static List<GenreInfo> inMemoryGenre = new List<GenreInfo>
        {
            new GenreInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Name ="FPS",
              Description=""
            },
            new GenreInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
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

        public void SaveGenre(GenreInfo genreInfo)
        {
            var genreInfoEdit = GenreById(genreInfo.Id);
            genreInfoEdit.Result.Name = genreInfo.Name;
            genreInfoEdit.Result.Description = genreInfo.Description;
        }

        public void AddGenre(GenreInfo genreInfo)
        {
            inMemoryGenre.Add(genreInfo);
        }

        public void RemoveGenre(Guid id)
        {
            inMemoryGenre.Remove(GenreById(id).Result);
        }
    }
}
