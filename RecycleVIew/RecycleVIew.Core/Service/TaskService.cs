using MvvmCross.ViewModels;
using RecycleVIew.Core.Interface;
using SQLite;
using System;
using System.Collections.Generic;

namespace RecycleVIew.Core.Services
{
    public class TaskService : ITaskRepositiry
    {
        private SQLiteConnection _con;
        private Random random = new Random();
      
        public TaskService(IDatabaseConnectionService con)
        {
            _con = con.GetDatebaseConnection();
            //_con.DropTable<Tasks>();
            _con.CreateTable<ItemTask>();
            //_con.Insert(new Tasks("Test Task"+random.Next(0,100), "Not important", false));
            
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
