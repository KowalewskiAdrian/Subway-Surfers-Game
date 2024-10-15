using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MyCoffeeApp.Annotations;
using MyCoffeeApp.Shared.Models;
using Xamarin.Essentials;

namespace MyCoffeeApp.Services
{
    public static class CoffeeService
    {
        private static SQLiteAsyncConnection db;

        private static async Task Init()
        {
            if (db != null) return;

            //string databasePath =
                //Path.Combine(Environment.GetFolderPath(
                //        Environment.SpecialFolder.MyDocuments), "MyData.db");

            string databasePath =
                Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.db");
            
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Coffee>();
        }

        public static async Task AddCoffee(string name, string roaster)
        {
            await Init();
            string image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            int id = await db.InsertAsync(coffee);
        }

        public static async Task RemoveCoffee(int id)
        {
            await Init();
            await db.DeleteAsync<Coffee>(id);
        }

        [ItemCanBeNull]
        public static async Task<IEnumerable<Coffee>> GetCoffee()
        {
            await Init();

            IEnumerable<Coffee> coffees = await db.Table<Coffee>().ToListAsync();
            return coffees;
        }

    }
}
