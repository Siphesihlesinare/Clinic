using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WomensClinicApp.ViewModels
{
    public class Users
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; internal set; }
        public string Name { get; set; }

         public string Adress { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public int Phone { get; set; }
        public int IDN { get; set; }

        public string Password { get; set; }

        public string Confirm { get; set; }
         public string Reason { get; set; }

        public  int Time { get; set; }

        public DateTime Date { get; set; }



    }
}
