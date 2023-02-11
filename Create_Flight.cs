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

namespace Bagage_Passager
{
    public partial class Create_Flight : Form
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        public Create_Flight(SQLiteConnection SQLConn, SQLiteCommand SQLComm)
        {
            InitializeComponent();
            conn = SQLConn;
            cmd = SQLComm;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Flight_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            String sqlQuery;
            DataTable dTable = new DataTable();
            if (conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                sqlQuery = "SELECT * FROM Flights";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, conn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        if(dTable.Rows[i].ItemArray[1].ToString() == numericUpDown1.Value.ToString())
                        {
                            MessageBox.Show("Такой рейс уже существует!");
                            return;
                        }
                        
                    }
                    try
                    {
                        cmd.CommandText = "INSERT INTO Flights ('flight_number') values ('" +
                            numericUpDown1.Value + "')";

                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    MessageBox.Show("Рейс создан!");
                    this.Close();

                }
                else
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO Flights ('flight_number') values ('" +
                            numericUpDown1.Value + "')";

                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    MessageBox.Show("Рейс создан!");
                    this.Close();
                }
                    
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
