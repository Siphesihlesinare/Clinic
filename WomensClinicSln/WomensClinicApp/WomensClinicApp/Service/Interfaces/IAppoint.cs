using System;
using System.Collections.Generic;
using System.Text;
using WomensClinicApp.Models;

namespace WomensClinicApp.Service.Interfaces
{
    public interface IAppoint
    {
        void SetLoggedinUser(Appointment book);
        Appointment GetLoggedInUser();
    }
}
