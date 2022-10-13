using Imi.Project.Api.Core.Dto.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.Publisher
{
    public class PublisherResponseDto:BaseDto
    {
        public string Name { get; set; }

        public string Country { get; set; }

        //public ICollection<GameResponseDto> Games { get; set; }
    }
}
