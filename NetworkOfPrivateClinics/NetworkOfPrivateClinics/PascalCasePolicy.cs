using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class PascalCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return char.IsLower(name[0]) ? char.ToUpper(name[0]) + name.Substring(1) : name;
        }
    }
}
