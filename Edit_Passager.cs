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
    public partial class Edit_Passager : Form
    {
        private SQLiteConnection SQLConn;
        private SQLiteCommand SQLComm;
        public Edit_Passager(SQLiteConnection SQLConn, SQLiteCommand SQLComm)
        {
            InitializeComponent();
            this.SQLConn = SQLConn;
            this.SQLComm = SQLComm;
            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Flights";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                dTable.Clear();
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        listBox2.Items.Add(dTable.Rows[i].ItemArray[1].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Нет созданных рейсов! Создайте рейс!");
                    this.Close();
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            try
            {
                sqlQuery = "SELECT * FROM BagageList";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                dTable.Clear();
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        listBox1.Items.Add(dTable.Rows[i].ItemArray[3].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Нет созданных пассажиров! Создайте пассажира");
                    this.Close();
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Passager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            String Res = "";
            String sqlQuery;
            if (listBox1.Text == "")
            {
                MessageBox.Show("Выберите ФИО!");
                return;
            }
            if (listBox2.Text == "")
            {
                MessageBox.Show("Выберите рейс!");
                return;
            }
            try
            {
                sqlQuery = "SELECT id FROM Flights WHERE flight_number = " + listBox2.Text;
                SQLComm.CommandText = sqlQuery;
                Res = SQLComm.ExecuteScalar().ToString();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            try
            {
                sqlQuery = "UPDATE BagageList SET flight_id = " + Res + " WHERE fio = '" + listBox1.Text + "'";
                SQLComm.CommandText = sqlQuery;
                SQLComm.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            MessageBox.Show("Обновлено!");
            this.Close();
        }
    }
}
