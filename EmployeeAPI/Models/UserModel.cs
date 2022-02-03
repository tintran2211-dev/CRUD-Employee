using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class UserModel 
    { 
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Passwords { get; set; }
        public string Mobile { get; set; }
        public string UseType { get; set; }
    }
}
