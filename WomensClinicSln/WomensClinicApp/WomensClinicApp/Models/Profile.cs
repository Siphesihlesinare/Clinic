using System;
using System.Collections.Generic;
using System.Text;
using WomensClinicApp.Service.Interfaces;
using WomensClinicApp.ViewModels;

namespace WomensClinicApp.Models
{
    public class Profile :IProfile

    {
        private Users _loggedInUser;

     
        public Users GetLoggedInUser()
        {
            return _loggedInUser;
        }

        public void SetLoggedinUser(Users users)
        {
            _loggedInUser = users;
        }
    }
    
}
