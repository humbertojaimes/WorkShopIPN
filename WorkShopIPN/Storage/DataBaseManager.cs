using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using WorkShopIPN.Model;
using Xamarin.Forms;

namespace WorkShopIPN.Storage
{
    public class DataBaseManager
    {
        SQLiteAsyncConnection database;
        public DataBaseManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTableAsync<Employee>().Wait();

        }

        public async Task SaveValueAsync<T>(T value, bool overrideIfExists = true) where T : IKeyObject, new()
        {

            var table = await database.Table<T>().ToListAsync();
            var all = (from entry in table
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 0)
                await database.InsertAsync(value);
            else
                if (overrideIfExists)
                await database.UpdateAsync(value);
            else
                throw new Exception($"Item {value.Key} already exists in database");

        }


        public async Task DeleteValueAsync<T>(T value) where T : IKeyObject, new()
        {
            var table = await database.Table<T>().ToListAsync();
            var all = (from entry in table
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                await database.DeleteAsync(value);
            else
                throw new Exception($"Item {value.Key} does not exists in database");


        }


        public async Task<List<T>> GetAllItemsAsync<T>() where T : IKeyObject, new()
        {
            List<T> result = null;
            result = await database.Table<T>().ToListAsync();
            return result;
        }


        public async Task<T> GetItemAsync<T>(string key) where T : IKeyObject, new()
        {
            var table = await database.Table<T>().ToListAsync();
            var result = (from entry in table
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;

        }



    }
}

