using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WomensClinicApp.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
 
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Reason { get; set; }

        public int Time { get; set; }

        public DateTime Date { get; set; }


    }
}
