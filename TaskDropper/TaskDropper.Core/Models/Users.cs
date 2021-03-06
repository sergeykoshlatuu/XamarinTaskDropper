﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Models
{
   public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Email { get; set; }

        public Users() { }

        public Users(string email)
        {
            Email = email;
        }
    }
}
