using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imi.Project.Api.WPF.ApiResponseModule
{
    public class GenreApiResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }

    }
}
