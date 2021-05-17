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

            /*foreach (string s in md.MoviesByRating(5))
            {
                Console.WriteLine(s);
            }

            // the same results, but returned in a different way 
            string qry = string.Format(MovieDatabase.N_STAR_MOVIES, 5);
            DataSet ds = md.GetMeSomeData(qry);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"{row["id"]}: {row["title"]}");
            }*/

            foreach(DataRow row in md.GetEveryRating().Tables[0].Rows)
            {
                Console.WriteLine($"{row["rid"]}, {row["mid"]}, {row["rating"]}, { row["date"]}");
            }

            Console.WriteLine("Please Enter some details to insert a new rating into the datebase:");
            Console.Write("Your name: ");
            string name = Console.ReadLine();
            Console.Write("The title of the movie: ");
            string title = Console.ReadLine();
            Console.Write("Your rating: ");
            string rating = Console.ReadLine();
            Console.Write("The date: ");
            string date = Console.ReadLine();

            md.Insert(name, title, rating, date);

            DataSet insertedDS = md.GetEveryRating();

            foreach (DataRow row in insertedDS.Tables[0].Rows)
            {
                Console.WriteLine($"{row["rid"]}, {row["mid"]}, {row["rating"]}, { row["date"]}");
            }

            Console.ReadKey();
        }

    }
}
