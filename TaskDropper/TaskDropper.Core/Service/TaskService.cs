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
            //_con.DropTable<Tasks>();
            _con.CreateTable<ItemTask>();
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

        public void DeleteTaskFromTable(ItemTask _task)
        {
            if (_task.Id != 0)
                _con.Table<ItemTask>().Where(x => x.Id == _task.Id).Delete();
        }

        public List<ItemTask> LoadListItems()
        {
            List<ItemTask> ListFromDatabase = _con.Table<ItemTask>().ToList();

            return ListFromDatabase;
        }


    }
}

