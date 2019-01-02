﻿using System.IO;
using RecycleVIew.Core;
using RecycleVIew.Core.Interface;
using SQLite;

namespace RecycleView.Droid
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
            var dbName = "TaskyDB.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}