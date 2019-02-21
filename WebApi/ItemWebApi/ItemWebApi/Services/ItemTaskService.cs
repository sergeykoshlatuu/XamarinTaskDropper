using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemWebApi.Services
{
    public class ItemTaskService : IDisposable
    {
        private TaskItemContext db = new TaskItemContext();
        private TaskItemRepository _itemTaskRepository;
       

        public TaskItemRepository ItemTasks
        {
            get
            {
                if (_itemTaskRepository == null)
                    _itemTaskRepository = new TaskItemRepository(db);
                return _itemTaskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}