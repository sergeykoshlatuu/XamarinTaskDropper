using SQLite;

namespace RecycleVIew.Core.Services
{
    public class ItemTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public ItemTask(){}

        public ItemTask(int _id, string _title,string _description, bool _status )
        {
            Id = _id;
            Title = _title;
            Description = _description;
            Status = _status;
        }
    }
}
