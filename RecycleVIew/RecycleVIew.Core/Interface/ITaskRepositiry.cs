using MvvmCross.ViewModels;
using RecycleVIew.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecycleVIew.Core.Interface
{
    public interface ITaskRepositiry
    {
       void AddToTable(ItemTask _tasks);
        List<ItemTask> LoadListItems();

        void DeleteTaskFromTable(ItemTask tasks);
    }
}
