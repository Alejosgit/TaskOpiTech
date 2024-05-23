using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string? Name {  get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public preference? Preference  { get; set; }
    }
}
