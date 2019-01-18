using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface IDatabaseHelper
    {
        //Tasks
        void AddTaskToTable(ItemTask tasks);
        List<ItemTask> LoadListItemsTask(int userId);
        void DeleteTaskFromTable(ItemTask tasks);

        //Users
        void AddUserToTable(string email);
        void UpdateLastUser(string email);
        List<LastUser> GetLastUser();
        int GetLastUserId();
        void LogOutUser();
    }
}
