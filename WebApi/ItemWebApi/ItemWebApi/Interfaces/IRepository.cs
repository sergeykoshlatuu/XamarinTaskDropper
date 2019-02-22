using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItemWebApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllByEmail(string id);
        T Get(int id);
        void Create(T item);
        void Update(int id,T item);
        void Delete(int id);
    }

    public class TaskItemRepository : IRepository<TaskItem>
    {
        private TaskItemContext db;

        public TaskItemRepository(TaskItemContext context)
        {
            this.db = context;
        }

        public IEnumerable<TaskItem> GetAllByEmail(string id)
        {
            return db.TaskItems.Where(x => x.UserEmail == id).ToList();
        }

        public TaskItem Get(int id)
        {
            return db.TaskItems.Find(id);
        }

        public void Create(TaskItem task)
        {
            db.TaskItems.Add(task);
            db.SaveChanges();
        }

        public void Update(int id,TaskItem task)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TaskItem task = db.TaskItems.Find(id);
            if (task != null)
                db.TaskItems.Remove(task);
            db.SaveChanges();
        }
    }
}