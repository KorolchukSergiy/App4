using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App4.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email cant be empty")]
        [EmailAddress(ErrorMessage ="Email is incorect")]
        public string email { get; set; }

        [Required(ErrorMessage = "Name cant be empty")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Login must be longer than 6 characters ")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password cant be empty")]
        [StringLength(100, MinimumLength =8,ErrorMessage = "Password must be longer than 8 characters ")]
        public string password { get; set; }

        [Required(ErrorMessage = "Phone cant be empty")]
        [RegularExpression(@"^[+]{1}[0-9]{12}$", ErrorMessage = "Number is Incorect")]
        public string phone { get; set; }

        public string photo { get; set; }
    }
}
