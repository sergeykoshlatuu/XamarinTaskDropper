using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemWebApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public byte[] PhotoTask { get; set; }

        public string UserEmail { get; set; }
    }
}