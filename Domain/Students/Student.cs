using Domain.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Domain.Students
{
    
    public class Student : Entity
    {
        public Student() 
        { 
            
        }

        public static Student Create(int id, string batch, string firstname, string lastname, DateTime birthDate, string email ,string phoneNumber, Boolean active)
        {
            return new()
            {
                Id = id,
                Batch = batch,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                PhoneNumber = phoneNumber,
                Active = active,
                BirthDate = birthDate
            };
        }

        public static Student Create(int id, Student student)
        {
            return new()
            {
                Id = id,
                Batch = student.Batch,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Active = student.Active,
                BirthDate = student.BirthDate
            };
        }


        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonPropertyName("batch")]
        public string Batch { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minimum:"1930-01-01", maximum:"2024-12-12")]
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonInclude]
        [JsonPropertyName("courses")]
        public List<Course> Courses { get; private set; }
    }
}
