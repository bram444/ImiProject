using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}