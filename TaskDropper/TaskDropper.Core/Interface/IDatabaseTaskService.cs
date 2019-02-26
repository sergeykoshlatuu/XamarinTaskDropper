using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface IDatabaseTaskService
    {
        //Tasks
        void AddTaskToTable(ItemTask tasks);
        List<ItemTask> LoadListItemsTask(string userEmail);
        void DeleteTaskFromTable(ItemTask tasks);
        void UpdateLocalDatabese(List<ItemTask> items);
    }
}
