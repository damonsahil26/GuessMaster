using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMaster.Utilities
{
    public static class Utility
    {
        public static string GetOrdinalString(int v)
        {
            switch (v)
            {
                case 1:
                    return "First";
                case 2:
                    return "Second";
                case 3:
                    return "Third";
                case 4:
                    return "Fourth";
                case 5:
                    return "Fifth";
                case 6:
                    return "Sixth";
                case 7:
                    return "Seventh";
                case 8:
                    return "Eighth";
                case 9:
                    return "Ninth";
                case 10:
                    return "Tenth";
                default:
                    return "Number out of range (1-10)";
            }
        }
    }
}
