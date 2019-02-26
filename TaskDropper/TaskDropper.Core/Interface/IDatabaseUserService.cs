using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Interface
{
    public interface IDatabaseUserService
    {
        //Users
        void AddUserToTable(string email);
        void UpdateLastUser(string email);      
        int GetLastUserId();
        string GetLastUserEmail();
        void LogOutUser();
    }
}
