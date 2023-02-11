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
    public partial class Create_Passager : Form
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        public Create_Passager(SQLiteConnection SQLConn, SQLiteCommand SQLComm)
        {
            InitializeComponent();
            conn = SQLConn;
            cmd = SQLComm;
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
                        listBox1.Items.Add(dTable.Rows[i].ItemArray[1].ToString());

                    }
                    

                }
                else
                {
                    MessageBox.Show("Нет созданных рейсов! Создайте рейс!");
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Passager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            
            if (listBox1.Text=="")
            {
                MessageBox.Show("Выберите рейс!");
                return;
            }
            String sqlQuery = "SELECT id FROM Flights WHERE flight_number=" + listBox1.Text;
            cmd.CommandText = sqlQuery;
            String Res = cmd.ExecuteScalar().ToString();
            switch (numericUpDown1.Value)
            {
                case 0:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage') values ('" +
                            Res + "','"+ textBox1.Text +"','"+numericUpDown1.Value.ToString()+"')";
                    break;
                case 1:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage','weight1') values ('" +
                            Res + "','" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" + numericUpDown2.Value.ToString() + "')";
                    break;
                case 2:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage','weight1','weight2') values ('" +
                            Res + "','" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" +
                            numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "')";
                    break;
                case 3:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage','weight1','weight2','weight3') values ('" +
                            Res + "','" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" +
                            numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + numericUpDown4.Value.ToString() + "')";
                    break;
                case 4:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage','weight1','weight2','weight3','weight4') values ('" +
                            Res + "','" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" +
                            numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + numericUpDown4.Value.ToString() +
                            "','" + numericUpDown5.Value.ToString() + "')";
                    break;
                case 5:
                    cmd.CommandText = "INSERT INTO BagageList ('flight_id','fio','count_bagage','weight1','weight2','weight3','weight4','weight5') values ('" +
                           Res + "','" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" +
                           numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + numericUpDown4.Value.ToString() +
                           "','" + numericUpDown5.Value.ToString() + "','" + numericUpDown6.Value.ToString() + "')";
                    break;
            }
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("Пассажир создан!");
            this.Close();
        }
    }
}
