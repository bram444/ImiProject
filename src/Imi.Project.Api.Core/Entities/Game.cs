using System;

namespace Imi.Project.Api.Core.Entities
{
    public class Game: BaseEntity
    {
        public float Price { get; set; }

        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }
    }
}