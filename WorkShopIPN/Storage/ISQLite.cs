using SQLite;

namespace WorkShopIPN.Storage
{
	public interface ISQLite
	{
        SQLiteAsyncConnection GetConnection();
	}
}