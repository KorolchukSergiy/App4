using App4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App4.DataBase
{
    interface IDataBase
    {
        Task<bool> AddUser(User user);
        Task<bool> DeleteUser(int Id);
        Task<List<User>> GetUsers();

        Task<bool> LogIn(string name, string Password);

        Task<bool> EditUser(User user);

    }
}
