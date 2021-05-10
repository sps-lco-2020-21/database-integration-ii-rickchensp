using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DatabaseIntegration.Lib
{
    public class MovieDatabase
    {
        // interop error https://stackoverflow.com/a/41700451/2902
        // goto to the directory: DatabaseIntegration.Lib\bin\Debug 
        // copy the two sub-directories x86/ and x64/ (each should have two files in them: sqlite3.dll and SQLite.Interop.dll) 
        // go into the bin/Debug directories for the CommandLine and the UI projects and copy these two sub-directories (replacing any of the same names that are already there)

        readonly string _connectionString;
        public const string N_STAR_MOVIES = "select distinct id, title, director from movies m join ratings r on m.id = r.mid where r.rating = {0} ";

        public MovieDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<string> MoviesByRating(int r)
        {
            string qry = string.Format(N_STAR_MOVIES, r);
            return GetMeAList(qry);
        }


        public IEnumerable<string> GetMeAList(string qry)
        {
            using (SQLiteConnection cxn = new SQLiteConnection(_connectionString))
            {
                cxn.Open();
                SQLiteCommand cmd;
                cmd = cxn.CreateCommand();
                cmd.CommandText = qry;

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // return the second column 
                    yield return reader.GetString(1);
                }
            }
        }

        public DataSet GetMeSomeData(string qry)
        {
            DataSet ds = null;
            // use 'using' the avoid explicitly closing the connection 
            using ( SQLiteConnection cxn = new SQLiteConnection(_connectionString))
            {
                // create a command object based on a query and a connection 
                SQLiteCommand cmd = new SQLiteCommand(qry, cxn);
                cmd.CommandType = CommandType.Text;
                // pass the command to an adapter 
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                // use the adapter to fill a dataset 
                ds = new DataSet();
                // if the location is unwritable, you'll get an error here 
                ad.Fill(ds);
            }

            return ds;
        }
    }
}
