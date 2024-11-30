using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public static class Extensions
    {
        public static TimeOnly ToTimeOnly(this string time) => TimeOnly.Parse(time, new CultureInfo("uk-UA"));
    }
}
