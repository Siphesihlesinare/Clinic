using System;
using System.Collections.Generic;
using System.Text;
using WomensClinicApp.ViewModels;

namespace WomensClinicApp.Service.Interfaces
{
    public interface IProfile
    {
        void SetLoggedinUser(Users users);
        Users GetLoggedInUser();
    }
}
