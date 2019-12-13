using ClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Data
{
    public class SeedData
    {
        public static void Initialize(ClinicContext context)
        {
            if (!context.LoginDetails.Any())
            {
                context.LoginDetails.AddRange(
                    new Login
                    {

                        idNumber = 111,
                         Password = "122",
                    },
                    new Login
                    {
                         idNumber = 222,
                          Password = "233",
                    }
                );
                context.SaveChanges();
            }
        }
    }
   
}
