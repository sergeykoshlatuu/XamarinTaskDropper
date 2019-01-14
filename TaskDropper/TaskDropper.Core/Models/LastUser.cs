using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Models
{
    public class LastUser
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Unique]
        public string Email { get; set; }

        public LastUser() { }

        public LastUser(int id,string email)
        {
            Id = id;
            Email = email;
        }
    }
}
