using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.Genre
{
    public class GenreResponseDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
