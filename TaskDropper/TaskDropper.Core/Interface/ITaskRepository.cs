using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface ITaskRepository
    {
        void AddToTable(ItemTask _tasks);
        List<ItemTask> LoadListItems();

        void DeleteTaskFromTable(ItemTask tasks);
    }
}
