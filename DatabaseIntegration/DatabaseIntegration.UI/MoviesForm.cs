using DatabaseIntegration.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseIntegration.UI
{
    public partial class MoviesForm : Form
    {
        readonly MovieDatabase _moviesDatabase; 

        public MoviesForm()
        {
            InitializeComponent();

            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["sl"];
            _moviesDatabase = new MovieDatabase(connectionStringSettings.ConnectionString);

        }

        private void MoviesForm_Load(object sender, EventArgs e)
        {
            // the query 
            string qry = string.Format(MovieDatabase.N_STAR_MOVIES, 5);
            // get the connection string from the app.config 
            // NB. the database file must be in a directory that the process can write to (there'll be a lockfile) 
            try
            {
                DataSet ds = _moviesDatabase.GetMeSomeData(qry);

                // bind the dataset to the combobox 
                cbNames.DataSource = ds.Tables[0];
                cbNames.ValueMember = "id"; // these are the field names returned from the query. 
                cbNames.DisplayMember = "title"; // if you want concatenations, do this in the query. 

                lblSelectedItem.Text = "No-one selected yet";
            }
            catch (Exception ex)
            {
                lblSelectedItem.Text = ex.Message;
            }
        }

        private void cbNames_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSelectedItem.Text = $"the movie selected has id #{cbNames.SelectedValue}";
        }
    }
}
