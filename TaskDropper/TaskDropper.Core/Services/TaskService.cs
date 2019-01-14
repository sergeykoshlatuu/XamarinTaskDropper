using MvvmCross.ViewModels;
using TaskDropper.Core.Interface;
using SQLite;
using TaskDropper.Core.Models;
using System.Collections.Generic;

namespace TaskDropper.Core.Services
{
    public class TaskService : ITaskRepository
    {
        private SQLiteConnection _con;

        public TaskService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            //_con.DropTable<Users>();
            //_con.DropTable<GoogleProfile>();
            _con.CreateTable<ItemTask>();
            _con.CreateTable<Users>();
            _con.CreateTable<LastUser>();
        }

        public void AddToTable(ItemTask task1)
        {
            if (task1.Id == 0)
            {
                _con.Insert(task1);
            }
            else
            {
                _con.Update(task1);
            }
        }

        public void AddUserToTable(string email)
        {
            Users user = new Users(email);
            List<Users> users = _con.Table<Users>().ToList();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email ==user.Email)
                {
                    return;
                }
            }
            _con.Insert(user);
        }

        

        public void DeleteTaskFromTable(ItemTask _task)
        {
            if (_task.Id != 0)
                _con.Table<ItemTask>().Where(x => x.Id == _task.Id).Delete();
        }

        public List<LastUser> GetLastUser()
        {
            List<LastUser> lastUsers = _con.Table<LastUser>().ToList();
            return lastUsers;
        }

       public int GetLastUserId()
        {
            List<LastUser> lastUsers = _con.Table<LastUser>().ToList();
            return lastUsers[0].Id;
        }


        public List<ItemTask> LoadListItems(int userId)
        {
            List<ItemTask> ListFromDatabase = _con.Table<ItemTask>().Where(x => x.UserId == userId).ToList();

            return ListFromDatabase;
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
                    LastUser user = new LastUser(users[i].Id, users[i].Email);
                    _con.Insert(user);
                }
            }
           
        }
    }
}

