using MvvmCross.ViewModels;
using TaskDropper.Core.Interface;
using SQLite;
using TaskDropper.Core.Models;
using System.Collections.Generic;

namespace TaskDropper.Core.Services
{
    public class DatabaseTaskService : IDatabaseTaskService
    {
        private SQLiteConnection _con;

        public DatabaseTaskService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            _con.CreateTable<ItemTask>();          
        }

        //Work with ItemTask
        public void AddTaskToTable(ItemTask task1)
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

        public void DeleteTaskFromTable(ItemTask _task)
        {
            if (_task.Id != 0)
                _con.Table<ItemTask>().Where(x => x.Id == _task.Id).Delete();
        }

        public List<ItemTask> LoadListItemsTask(string email)
        {
            List<ItemTask> ListFromDatabase = _con.Table<ItemTask>().Where(x => x.UserEmail == email).ToList();

            return ListFromDatabase;
        }

        public void UpdateLocalDatabese(List<ItemTask> items)
        {
            _con.DropTable<ItemTask>();
            _con.CreateTable<ItemTask>();
            for (int i = 0; i < items.Count; i++)
            {
                _con.Insert(items[i]);
            }
        }
    }
}

