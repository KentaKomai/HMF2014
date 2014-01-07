using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMF_KOMAI_CSHARP.Utils
{
    class Debug
    {
        public static void ShowUserStatus(DataModels.User user)
        {
			Console.WriteLine("--------------USER STATUS-------------");
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Age);
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.Handicap);
            Console.WriteLine(user.Status);
            Console.WriteLine("--------------USER STATUS-------------");
        }
    }
}
