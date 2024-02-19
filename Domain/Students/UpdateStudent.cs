using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public class UpdateStudent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool Active { get; set; }
    }
}
