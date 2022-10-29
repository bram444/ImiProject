using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
