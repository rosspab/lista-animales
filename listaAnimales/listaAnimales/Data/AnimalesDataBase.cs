using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using listaAnimales.Model;
using SQLite;

namespace listaAnimales.Data
{
	public class AnimalesDataBase
	{
        private readonly SQLiteAsyncConnection database;

        public AnimalesDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Animal>().Wait();
        }

        public async Task<List<Animal>> GetItemsAsync()
        {
            return await database.Table<Animal>().ToListAsync();
        }

        public Task<Animal> GetItemAsync(int id)
        {
            return database.Table<Animal>()
                           .Where(i => i.ID == id)
                           .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Animal item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Animal item)
        {
            return database.DeleteAsync(item);
        }
    }
}

