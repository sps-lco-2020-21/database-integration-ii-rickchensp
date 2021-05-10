using DatabaseIntegration.Lib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseIntegration.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ConnectionStringSettings cxnstring = ConfigurationManager.ConnectionStrings["sl"];

            MovieDatabase md = new MovieDatabase(cxnstring.ConnectionString);

            foreach (string s in md.MoviesByRating(5))
            {
                Console.WriteLine(s);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MoviesForm());
        }
    }
}
