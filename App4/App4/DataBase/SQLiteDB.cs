using App4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App4.DataBase
{
    class SQLiteDB 
    {
        SQLiteAsyncConnection DbConection;
        public SQLiteDB()
        {
        }

        private async Task Init()
        {
            if (DbConection != null)
                return;

            var DataBasePath = Path.Combine(FileSystem.AppDataDirectory, "MyDB.db");

            DbConection = new SQLiteAsyncConnection(DataBasePath);
            await DbConection.CreateTableAsync<User>();
        }

        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                await Init();
                AsyncTableQuery<User> users = DbConection.Table<User>();
                User resultUser = await DbConection.Table<User>().Where(x => x.name == user.name || x.userName == user.userName).FirstOrDefaultAsync();
                if (resultUser == null)
                {
                    int resultReg = await DbConection.InsertAsync(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

           // var Id = await DbConection.InsertAsync(user);   

        }

        public async Task<IEnumerable<User>> GetUser()
        {
            await Init();
            List<User> users = await DbConection.Table<User>().ToListAsync();
            return users;
        }

        public async Task<bool> LogIn(string name, string Password)
        {
            await Init();
            User resultUser=null;
            try
            {
                resultUser = await DbConection.Table<User>().
                    Where(x => (x.name == name || x.userName == name) && x.password == Password).FirstOrDefaultAsync();

                if (resultUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

    }
}
