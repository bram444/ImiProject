﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class GamesInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public Guid PublisherId { get; set; }

        public ICollection<Guid> GenreId { get; set; }
    }
}