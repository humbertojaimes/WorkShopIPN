using SQLite;

namespace WorkShopIPN.Storage
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}