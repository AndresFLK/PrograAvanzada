using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            
        }

        public StudentDTO(int id, string batch, string fullName)
        {
            Id = id;
            Batch = batch;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string Batch { get; set; }
        public string FullName { get; set; }
    }
}
