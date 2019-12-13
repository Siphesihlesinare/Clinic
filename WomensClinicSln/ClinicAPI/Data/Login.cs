using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Data
{
    public class Login
    {
        [Key]
        public int idNumber { get; set; }
        public string Password { get; set; }
    }
}
