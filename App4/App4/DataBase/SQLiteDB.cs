using App4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App4.DataBase
{
    class SQLiteDB : IDataBase
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

        public async Task<List<User>> GetUsers()
        {
            await Init();
            try
            {
                return await DbConection.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }

        }

        public async Task<bool> LogIn(string name, string Password)
        {
            await Init();
            User resultUser=null;
            try
            {
                resultUser = await DbConection.Table<User>().
                             Where(x => (x.login == name || x.email == name) && x.password == Password).FirstOrDefaultAsync();

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

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await Init();
                AsyncTableQuery<User> users = DbConection.Table<User>();
                User resultUser = await DbConection.Table<User>().Where(x => x.login == user.login || x.email == user.email ).FirstOrDefaultAsync();
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

        public Task<bool> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
