using System;
using System.Collections.Generic;
using System.Text;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.Interface
{
    public interface IDatabaseUserService
    {
        //Users
        void AddUserToTable(string email,string token);
        void UpdateLastUser(string email);      
        int GetLastUserId();
        string GetLastUserEmail();
        LastUser GetLastUser();
        void LogOutUser();
    }
}
