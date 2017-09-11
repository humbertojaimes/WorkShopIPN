using System;
using System.IO;
using WorkShopIPN.iOS;
using WorkShopIPN.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace WorkShopIPN.iOS
{
	public class SQLiteIOS:ISQLite
	{
		public SQLite.SQLiteAsyncConnection GetConnection()
		{
			var sqliteFilename = "TodoSQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			// Create the connection
            var conn = new SQLite.SQLiteAsyncConnection(path);
			// Return the database connection
			return conn;
		}
	}
}
