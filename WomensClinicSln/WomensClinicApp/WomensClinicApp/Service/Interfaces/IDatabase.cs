using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WomensClinicApp.ViewModels;

namespace WomensClinicApp.Service.Interfaces
{
    public interface IDatabase
    {
         Task<List<Users>> GetItemsAsync();
         Task<List<Users>> GetItemsNotDoneAsync();
         Task<Users> GetItemAsync(int id);
        Task<int> SaveItemAsync(Users item);
         Task<int> DeleteItemAsync(Users item);
        Task<Users> GetUserByIDNumber(int IdNumber);
     
    }
}
