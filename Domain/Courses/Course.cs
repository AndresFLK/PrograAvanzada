using System;
using Domain.Students;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Courses
{
    public class Course : Entity
    {
        [Key]
        [Required]
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id {  get; private set; }

        [JsonInclude]
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonInclude]
        [JsonPropertyName("active")]
        public bool Active { get; private set; }

        
        [JsonInclude]
        [JsonPropertyName("students")]
        public List<Student> Students { get; private set; }
    }
}
