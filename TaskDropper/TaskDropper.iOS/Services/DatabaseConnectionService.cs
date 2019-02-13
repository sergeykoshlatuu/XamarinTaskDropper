using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using TaskDropper.Core.Interface;
using UIKit;

namespace TaskDropper.iOS.Services
{
    public class DatabaseConnectionService
          : IDatabaseConnectionService
    {
        public DatabaseConnectionService()
        {
            var database = GetDatebaseConnection();
        }

        public SQLiteConnection GetDatebaseConnection()
        {
            var dbName = "TaskyDB.db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, dbName);
            return new SQLiteConnection(path);
        }
    }
}