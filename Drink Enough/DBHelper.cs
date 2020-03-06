using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;

namespace Drink_Enough
{
    class DBHelper
    {
        static string dbName = "Drink-List.db3";
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbName);

        public void createDB()
        {
            if (!File.Exists(dbName))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Drink>();
                db.Close();
            }
        }

        public void insertDrink(Drink drink)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(drink);
            db.Close();
        }

        public void deleteDrink(Drink drink)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete(drink);
            db.Close();
        }

        public void updateDrink(Drink drink)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(drink);
            db.Close();
        }

        public void deleteAllDrinks()
        {
            var db = new SQLiteConnection(dbPath);
            db.DeleteAll<Drink>();
            db.Close();
        }

        public Drink getDrink(DateTime date)
        {
            Drink drink = new Drink();
            var db = new SQLiteConnection(dbPath);
            drink = db.Query<Drink>("SELECT * FROM Drink CreateDate = ?", date)[0];
            //drink = db.Get<Drink>(id);
            db.Close();
            return drink;
        }

        public Drink getLastDrink()
        {
            Drink drink = new Drink();
            var db = new SQLiteConnection(dbPath);
            if (db.Query<Drink>("SELECT * FROM Drink ORDER BY CreateDate DESC LIMIT 1").Count > 0)
            {
                drink = db.Query<Drink>("SELECT * FROM Drink ORDER BY CreateDate DESC LIMIT 1")[0];
            }
            
            db.Close();
            return drink;
        }

        public List<Drink> getAllDrinks()
        {
            List<Drink> drinkList = new List<Drink>();
            var db = new SQLiteConnection(dbPath);
            drinkList = db.Query<Drink>("SELECT * FROM Drink");
            db.Close();
            return drinkList;
        }
    }
}