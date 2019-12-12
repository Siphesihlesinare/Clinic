using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WomensClinicApp.Models;
using WomensClinicApp.Service.Interfaces;
using WomensClinicApp.ViewModels;

namespace WomensClinicApp.Service
{
    public class ClinicData : IDatabase
    {

        private SQLiteAsyncConnection database;

        public ClinicData()
        {
            string dbPath = GetDbPath();

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Users>().Wait();
            database.CreateTableAsync<Appointment>().Wait();

        }

        private string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), " Clinic.Db3");
        }
        public Task<List<Users>> GetItemsAsync()
        {
            return database.Table<Users>().ToListAsync();
        }
        

        public Task<List<Users>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Users>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Users> GetUserByIDNumber(int IdNumber)
        {
            return database.Table<Users>().Where(x => x.IDN == IdNumber).FirstOrDefaultAsync();
        }

        public Task<Users> GetItemAsync(int id)
        {
            return database.Table<Users>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Appointment>> GetAppointmentsByUserId(int userId)
        {
            return database.Table<Appointment>().Where(i => i.UserId == userId).ToListAsync();
        }
        
        public Task<int> SaveAppointment(Appointment appointment)
        {
                return database.InsertAsync(appointment);
        }


        public Task<int> SaveItemAsync(Users item)
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

        public Task<int> DeleteItemAsync(Users item)
        {
            return database.DeleteAsync(item);
        }

      
    }
}
