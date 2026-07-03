using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Managers
{
    internal class Session
    {
        public static int UserID;
        public static string Username;
        public static DateTime LoginTime = DateTime.Now;
        public static string Role;
    }
}
