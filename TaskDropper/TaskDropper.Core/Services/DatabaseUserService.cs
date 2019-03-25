using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.Services
{ 
        public class DatabaseUserService : IDatabaseUserService
        {
            private SQLiteConnection _con;

            public DatabaseUserService(IDatabaseConnectionService con)
            {
                _con = con.GetDatebaseConnection();
                _con.CreateTable<Users>();
                _con.CreateTable<LastUser>();              
            }

            //Work with users
            public void AddUserToTable(string email,string token)
            {
                Users user = new Users(email,token);
                List<Users> users = _con.Table<Users>().ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == user.Email)
                    {
                        return;
                    }
                }

                _con.Insert(user);
            }


            public int GetLastUserId()
            {
                List<LastUser> lastUsers = _con.Table<LastUser>().ToList();
                if (lastUsers.Count == 0) return 0;
                return lastUsers[0].Id;
            }

            public void LogOutUser()
            {
                _con.DropTable<LastUser>();
                _con.CreateTable<LastUser>();
            }

            public void UpdateLastUser(string email)
            {
                _con.DropTable<LastUser>();
                _con.CreateTable<LastUser>();
                List<Users> users = _con.Table<Users>().ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == email)
                    {
                        LastUser user = new LastUser(users[i].Id, users[i].Email,users[i].Token);
                        _con.Insert(user);
                    }
                }

            }

            public string GetLastUserEmail()
            {
                List<LastUser> lastUsers = _con.Table<LastUser>().ToList();
                if (lastUsers.Count == 0) return "";
                return lastUsers[0].Email;
            }

        public LastUser GetLastUser()
        {
            List<LastUser> lastUsers = _con.Table<LastUser>().ToList();
            if (lastUsers.Count == 0) return null;
            return lastUsers[0];
        }
    }
    }

