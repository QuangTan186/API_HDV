using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Extensions
{
    public static class DateTimeExtension
    {
        public static int GetAge(this DateTime dateofBirth)
        {
            var today = DateTime.Now;
            var age = today.Year - dateofBirth.Year;
            if(dateofBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}