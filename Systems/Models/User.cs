using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Models
{
    public class User
    {
        [Key]
        public int Id;

        public string Password;
        public string Email;
    }
}
