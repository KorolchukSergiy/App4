using App4.DataBase;
using App4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace App4.Validators
{
    class ValidateUser : IvalidateUser
    {
        public async Task<bool> AuthenticationUser(string email, string password)
        {
            IDataBase context = new SQLiteDB();
            bool result = await context.LogIn(email, password);
            return result;
        }

        public async Task<bool> DeleteUser(int id)
        {
            IDataBase context = new SQLiteDB();
            bool result = await context.DeleteUser(id);
            return result;         
        }

        public async Task<bool> EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ValidationResult>> ValidateNewUser(User user, string confirmPassword)
        {
            if (user.password.Equals(confirmPassword))
            {
                ValidationContext ctx = new ValidationContext(user);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(user, ctx, results, true))
                {
                    return results;
                }
                else
                {
                    IDataBase context = new SQLiteDB();
                    bool result = await context.AddUser(user);
                    if (result)
                    {
                        return new List<ValidationResult>();
                    }
                    else
                    {
                        return new List<ValidationResult> {
                             new ValidationResult("Email or Login is already in use", new List<string>{"login"})
                               };
                    }

                }
            }
            else
            {
                return new List<ValidationResult> {
                    new ValidationResult("Passwords mismatch", new List<string>{"confirmPassword"})
                     };
            }
        }
    }
}
