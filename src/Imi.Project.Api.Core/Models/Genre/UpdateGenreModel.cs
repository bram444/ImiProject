using System;

namespace Imi.Project.Api.Core.Models.Genre
{
    public class UpdateGenreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}