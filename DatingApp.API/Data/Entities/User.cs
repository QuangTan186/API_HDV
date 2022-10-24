using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Data.Entities
{
    public class User
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [StringLength(32)]
        public string Username {get; set;}

        [Required]
        [StringLength(255)]
        public string Email {get; set;}

        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public string abc;
    }
}