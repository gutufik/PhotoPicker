using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoPicker
{
    public class PhotoRepository
    {
        SQLiteConnection database;
        public PhotoRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Photo>();
        }
        public IEnumerable<Photo> GetPhotos()
        {
            return database.Table<Photo>().ToList();
        }
        public Photo GetItem(int id)
        {
            return database.Get<Photo>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Photo>(id);
        }
        public int SavePhoto(Photo item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
