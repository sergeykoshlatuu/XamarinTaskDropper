using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface ITaskRepository
    {
        //Tasks
        void AddTaskToTable(ItemTask tasks);
        List<ItemTask> LoadListItems(int userId);
        void DeleteTaskFromTable(ItemTask tasks);
        //Users
        void AddUserToTable(string email);

        void UpdateLastUser(string email);
        List<LastUser> GetLastUser();
        int GetLastUserId();

        List<GoogleProfile> ListGoogleUsers();

        void LogOutUser();
    }
}
