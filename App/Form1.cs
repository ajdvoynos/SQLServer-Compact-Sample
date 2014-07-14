using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new SqlCeConnection())
            {
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                //con.ConnectionString = @"Data Source = |DataDirectory|\Database\DB.sdf;Persist Security Info=False";
                var cmd = new SqlCeCommand("SELECT * FROM TEST", con);
                con.Open();
                var data = new DataTable("whatever");
                data.Load(cmd.ExecuteReader());
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var con = new SqlCeConnection())
            {
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                var cmd = new SqlCeCommand("INSERT INTO TEST VALUES('1','2')", con);
                con.Open();
                MessageBox.Show(cmd.ExecuteNonQuery().ToString());
                con.Close();
            }
        }
    }
}
