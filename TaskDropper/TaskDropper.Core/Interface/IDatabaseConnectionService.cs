using SQLite;

namespace TaskDropper.Core.Interface
{
    public interface IDatabaseConnectionService
    {
        SQLiteConnection GetDatebaseConnection();
    }
}
