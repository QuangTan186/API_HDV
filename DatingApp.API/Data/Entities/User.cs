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
        public DateTime DateOfBirth{get; set;}
        public int Age {get; set;}
        [MaxLength(32)]
        public string KnownAs {get; set;}
        [MaxLength(6)]
        public string Gender {get; set;}
        [MaxLength(256)]
        public string Introduction {get; set;}
        [MaxLength(32)]
        public string City {get; set;}
        [MaxLength(256)]
        public string Avatar{get; set;}
        public DateTime CreateAt{get; set;}
        public DateTime UpdateAt{get; set;}
    }
}