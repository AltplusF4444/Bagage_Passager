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
using System.Drawing.Printing;
using System.IO;

namespace Bagage_Passager
{
    public partial class View_Passagers : Form
    {
        SQLiteConnection SQLConn;
        SQLiteCommand SQLComm;
        private string result = "";
        public View_Passagers(SQLiteConnection SQLConn, SQLiteCommand SQLComm)
        {
            InitializeComponent();
            this.SQLConn = SQLConn;
            this.SQLComm = SQLComm;
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (SQLConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                sqlQuery = "SELECT BagageList.id,Flights.flight_number, BagageList.fio,BagageList.count_bagage, BagageList.weight1, BagageList.weight2, BagageList.weight3, BagageList.weight4, BagageList.weight5 FROM BagageList INNER JOIN Flights on BagageList.flight_id=Flights.id";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    
                    
                    Table_View_Flights.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++) {

                        Table_View_Flights.Rows.Add(dTable.Rows[i].ItemArray);
                        
                        
                        }
                }
                else
                    MessageBox.Show("Database is empty");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                        listBox1.Items.Add(dTable.Rows[i].ItemArray[1].ToString());

                    }


                }
                else
                {
                    MessageBox.Show("Нет созданных рейсов! Создайте рейс!");
                    listBox1.Items.Add("Нет рейсов");
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
        

        private void View_Flights_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }
        private string stringToPrint = "";
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            stringToPrint = stringToPrint.Substring(charactersOnPage);

            e.HasMorePages = (stringToPrint.Length > 0);
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            string docName = "FullBagage.txt";
            int FullWeight = 0;
            DataTable dTable = new DataTable();
            String sqlQuery;
            if (!File.Exists(docName))
            {
                File.Create(docName);
                
            }
            sqlQuery = "SELECT * FROM Flights";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
            dTable.Clear();
            adapter.Fill(dTable);
            String[] flights_id = new String[dTable.Rows.Count];
            String[] flights = new String[dTable.Rows.Count];
            for (int i = 0; i < flights_id.Length; i++)
            {
                flights_id[i] = dTable.Rows[i].ItemArray[0].ToString();
                flights[i] = dTable.Rows[i].ItemArray[1].ToString();
            }
            
            try
            {
                StreamWriter sw = new StreamWriter(docName, false);
                sw.WriteLine("Номер рейса   Общий вес багажа");
                try
                {
                    for (int i = 0; i < flights_id.Length; i++)
                    {
                        sqlQuery = "SELECT * FROM BagageList WHERE flight_id = " + flights_id[i];
                        adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                        dTable.Clear();
                        adapter.Fill(dTable);

                        if (dTable.Rows.Count > 0)
                        {
                            for (int j = 0; j < dTable.Rows.Count; j++)
                            {
                                if (dTable.Rows[j].ItemArray[5].ToString() != "")
                                    FullWeight += Int32.Parse(dTable.Rows[j].ItemArray[5].ToString());
                                if (dTable.Rows[j].ItemArray[6].ToString() != "")
                                    FullWeight += Int32.Parse(dTable.Rows[j].ItemArray[6].ToString());
                                if (dTable.Rows[j].ItemArray[7].ToString() != "")
                                    FullWeight += Int32.Parse(dTable.Rows[j].ItemArray[7].ToString());
                                if (dTable.Rows[j].ItemArray[8].ToString() != "")
                                    FullWeight += Int32.Parse(dTable.Rows[j].ItemArray[8].ToString());
                                if (dTable.Rows[j].ItemArray[9].ToString() != "")
                                    FullWeight += Int32.Parse(dTable.Rows[j].ItemArray[9].ToString());
                            }
                        }
                        sw.WriteLine(flights[i] + "                    " + FullWeight.ToString());
                        FullWeight = 0;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            stringToPrint = System.IO.File.ReadAllText(docName);

            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = docName;
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        private void Sort_Button_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;
            if (listBox1.Text == "")
            {
                MessageBox.Show("Выберите рейс!");
                return;
            }
            try
            {
                sqlQuery = "SELECT BagageList.id,Flights.flight_number, BagageList.fio,BagageList.count_bagage, BagageList.weight1, BagageList.weight2, BagageList.weight3, BagageList.weight4, BagageList.weight5 FROM BagageList INNER JOIN Flights on BagageList.flight_id=Flights.id WHERE Flights.flight_number = " + listBox1.Text + " AND (BagageList.weight1 > 20 OR BagageList.weight2 > 20 OR BagageList.weight3 > 20 OR BagageList.weight4 > 20 OR BagageList.weight5 > 20) ";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    Table_View_Flights.Rows.Clear();
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        Table_View_Flights.Rows.Add(dTable.Rows[i].ItemArray);
                    }
                }
                else
                {
                    MessageBox.Show("Таких пассажиров нет!");
                    try
                    {
                        sqlQuery = "SELECT BagageList.id,Flights.flight_number, BagageList.fio,BagageList.count_bagage, BagageList.weight1, BagageList.weight2, BagageList.weight3, BagageList.weight4, BagageList.weight5 FROM BagageList INNER JOIN Flights on BagageList.flight_id=Flights.id";
                        adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                        dTable.Clear();
                        adapter.Fill(dTable);

                        if (dTable.Rows.Count > 0)
                        {
                            Table_View_Flights.Rows.Clear();
                            for (int i = 0; i < dTable.Rows.Count; i++)
                            {
                                Table_View_Flights.Rows.Add(dTable.Rows[i].ItemArray);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Database is empty");
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            String sqlQuery;
            String Res = "";
            if (listBox1.Text == "")
            {
                MessageBox.Show("Выберите рейс!");
                return;
            }
            try
            {
                sqlQuery = "SELECT id FROM Flights WHERE flight_number = " + listBox1.Text;
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
                sqlQuery = "DELETE FROM BagageList WHERE flight_id = " + Res;
                SQLComm.CommandText = sqlQuery;
                SQLComm.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            MessageBox.Show("Удаление выполнено!");
            DataTable dTable = new DataTable();
            try
            {
                sqlQuery = "SELECT BagageList.id,Flights.flight_number, BagageList.fio,BagageList.count_bagage, BagageList.weight1, BagageList.weight2, BagageList.weight3, BagageList.weight4, BagageList.weight5 FROM BagageList INNER JOIN Flights on BagageList.flight_id=Flights.id";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    Table_View_Flights.Rows.Clear();
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        Table_View_Flights.Rows.Add(dTable.Rows[i].ItemArray);
                    }
                }
                else
                {
                    MessageBox.Show("Database is empty");
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void All_Button_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT BagageList.id,Flights.flight_number, BagageList.fio,BagageList.count_bagage, BagageList.weight1, BagageList.weight2, BagageList.weight3, BagageList.weight4, BagageList.weight5 FROM BagageList INNER JOIN Flights on BagageList.flight_id=Flights.id";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, SQLConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    Table_View_Flights.Rows.Clear();
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        Table_View_Flights.Rows.Add(dTable.Rows[i].ItemArray);
                    }
                }
                else
                {
                    MessageBox.Show("Database is empty");
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
