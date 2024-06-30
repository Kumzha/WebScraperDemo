using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraperDemo
{
    public class DataFile
    {
        public static int NumberOfElements { get; set; } = 0;
        public static string FilterString(string input)
        { 
            string pattern = @"^\d+\.\s*";
            string result = Regex.Replace(input, pattern, string.Empty);
            return result;
        }
        public static void AddToDataBase()
        {

        }

    }
}
