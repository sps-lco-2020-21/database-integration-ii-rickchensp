using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DatabaseIntegration.Lib;
using System.Data;

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

            // the same results, but returned in a different way 
            string qry = string.Format(MovieDatabase.N_STAR_MOVIES, 5);
            DataSet ds = md.GetMeSomeData(qry);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"{row["id"]}: {row["title"]}");
            }


            Console.ReadKey();
        }
    }
}
