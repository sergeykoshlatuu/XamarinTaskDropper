using SQLite;

namespace RecycleVIew.Core.Interface
{
    public interface IDatabaseConnectionService
    {
        SQLiteConnection GetDatebaseConnection();
    }
}
