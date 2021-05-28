using App4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace App4.Validators
{
    interface IvalidateUser
    {
        Task<List<ValidationResult>> ValidateNewUser(User user, string confirmPassword);

        Task<bool> DeleteUser(int Id);

        Task<bool> AuthenticationUser(string name, string password);

        Task<bool> EditUser(User user);
    }
}
