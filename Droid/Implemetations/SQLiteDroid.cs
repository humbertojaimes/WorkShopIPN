using System;
using System.IO;
using WorkShopIPN.Droid;
using WorkShopIPN.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace WorkShopIPN.Droid
{
	public class SQLiteDroid : ISQLite
	{
		public SQLite.SQLiteConnection GetConnection()
		{
			SQLitePCL.Batteries.Init();
			var sqliteFilename = "TodoSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}
