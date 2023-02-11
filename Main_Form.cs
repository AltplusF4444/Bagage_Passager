using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace Bagage_Passager
{
    public partial class Main_Form : Form
    {
        private String dbName;
        private SQLiteConnection SQLConn;
        private SQLiteCommand SQLComm;

        public Main_Form()
        {
            InitializeComponent();
            SQLConn = new SQLiteConnection();
            SQLComm = new SQLiteCommand();

            dbName = "BP.sqlite";
            label2.Text = "Disconnected";
            if (!File.Exists(dbName))
            {


                SQLiteConnection.CreateFile(dbName);

                try
                {
                    SQLConn = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                    SQLConn.Open();
                    SQLComm.Connection = SQLConn;

                    SQLComm.CommandText = "CREATE TABLE IF NOT EXISTS BagageList (id INTEGER PRIMARY KEY AUTOINCREMENT, flight_id INTEGER, fio TEXT, count_bagage INTEGER, weight1 INTEGER, weight2 INTEGER, weight3 INTEGER, weight4 INTEGER, weight5 INTEGER, FOREIGN KEY(flight_id) REFERENCES Flights(id))";
                    SQLComm.ExecuteNonQuery();
                    SQLComm.CommandText = "CREATE TABLE IF NOT EXISTS Flights (id INTEGER PRIMARY KEY AUTOINCREMENT, flight_number INTEGER)";
                    SQLComm.ExecuteNonQuery();

                    label2.Text = "Created and Connected";
                }
                catch (SQLiteException ex)
                {
                    label2.Text = "Disconnected";
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                SQLConn = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                SQLConn.Open();
                SQLComm.Connection = SQLConn;
                label2.Text = "Connected";
            }
        }

        private void View_Passagers_Click(object sender, EventArgs e)
        {
            Form vp = new View_Passagers(SQLConn, SQLComm);
            vp.Show();
            this.Hide();
        }

        private void Create_Flight_Click(object sender, EventArgs e)
        {
            Form cf = new Create_Flight(SQLConn, SQLComm);
            cf.Show();
            this.Hide();
        }

        private void Create_Passager_Click(object sender, EventArgs e)
        {
            Form cp = new Create_Passager(SQLConn, SQLComm);
            cp.Show();
            this.Hide();
        }

        private void Edit_Passager_Click(object sender, EventArgs e)
        {
            Form ep = new Edit_Passager(SQLConn, SQLComm);
            ep.Show();
            this.Hide();
        }
    }
}
