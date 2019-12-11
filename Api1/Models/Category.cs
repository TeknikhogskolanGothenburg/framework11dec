using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1.Models
{

    class CategoryRoot
    {
        [JsonProperty("trivia_categories")]
        public Category[] TriviaCategories { get; set; }
    }

    class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
