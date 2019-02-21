
using System.Data.Entity;

namespace ItemWebApi.Models
{
    public class TaskItemContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}