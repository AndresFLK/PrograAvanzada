using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Account
{
    public class AccountViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
