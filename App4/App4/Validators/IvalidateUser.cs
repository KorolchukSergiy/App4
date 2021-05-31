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

        Task<bool> EditUser(User user);

        Task<bool> DeleteUser(int id);

        Task<bool> AuthenticationUser(string email, string password);

    }
}
