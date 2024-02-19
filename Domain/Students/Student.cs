using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.Students
{
    
    public class Student
    {
        

        private Student() 
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
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        public string Batch { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minimum:"1900-01-01", maximum:"2024-01-01")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Active { get; set; }

       
    }
}
