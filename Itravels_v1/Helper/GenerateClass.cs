using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Helper
{
    public class GenerateClass
    {
        private static Random random = new Random();

        public static string GenerateRandomRegNumber()
        {
            try
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception)
            {

                return "";
            }
           
        }
    }
}
