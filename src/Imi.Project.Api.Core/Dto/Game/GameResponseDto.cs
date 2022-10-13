using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.Game
{
    public class GameResponseDto:BaseDto
    {
        public string Name { get; set; }

        public float Price { get; set; }

        //public PublisherResponseDto Publisher { get; set; }
    }
}
