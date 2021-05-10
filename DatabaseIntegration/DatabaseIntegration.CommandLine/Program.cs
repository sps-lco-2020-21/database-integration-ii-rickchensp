using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DatabaseIntegration.Lib;

namespace DatabaseIntegration.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings cxnstring = ConfigurationManager.ConnectionStrings["sl"];

            MovieDatabase md = new MovieDatabase(cxnstring.ConnectionString);

            foreach (string s in md.MoviesByRating(5))
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
