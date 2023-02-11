namespace Bagage_Passager
{
    partial class View_Passagers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Back_Button = new System.Windows.Forms.Button();
            this.Table_View_Flights = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flight_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count_Bagage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Print_Button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sort_Button = new System.Windows.Forms.Button();
            this.All_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table_View_Flights)).BeginInit();
            this.SuspendLayout();
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(12, 424);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 27);
            this.Back_Button.TabIndex = 0;
            this.Back_Button.Text = "Назад";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Table_View_Flights
            // 
            this.Table_View_Flights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_View_Flights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Flight_number,
            this.FIO,
            this.Count_Bagage,
            this.Weight1,
            this.Weight2,
            this.Weight3,
            this.Weight4,
            this.Weight5});
            this.Table_View_Flights.Location = new System.Drawing.Point(12, 12);
            this.Table_View_Flights.Name = "Table_View_Flights";
            this.Table_View_Flights.RowHeadersWidth = 51;
            this.Table_View_Flights.RowTemplate.Height = 24;
            this.Table_View_Flights.Size = new System.Drawing.Size(1150, 397);
            this.Table_View_Flights.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // Flight_number
            // 
            this.Flight_number.HeaderText = "Flight number";
            this.Flight_number.MinimumWidth = 6;
            this.Flight_number.Name = "Flight_number";
            this.Flight_number.ReadOnly = true;
            this.Flight_number.Width = 125;
            // 
            // FIO
            // 
            this.FIO.HeaderText = "FIO";
            this.FIO.MinimumWidth = 6;
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 125;
            // 
            // Count_Bagage
            // 
            this.Count_Bagage.HeaderText = "Count Bagage";
            this.Count_Bagage.MinimumWidth = 6;
            this.Count_Bagage.Name = "Count_Bagage";
            this.Count_Bagage.ReadOnly = true;
            this.Count_Bagage.Width = 125;
            // 
            // Weight1
            // 
            this.Weight1.HeaderText = "Weight1 ";
            this.Weight1.MinimumWidth = 6;
            this.Weight1.Name = "Weight1";
            this.Weight1.ReadOnly = true;
            this.Weight1.Width = 125;
            // 
            // Weight2
            // 
            this.Weight2.HeaderText = "Weight2";
            this.Weight2.MinimumWidth = 6;
            this.Weight2.Name = "Weight2";
            this.Weight2.ReadOnly = true;
            this.Weight2.Width = 125;
            // 
            // Weight3
            // 
            this.Weight3.HeaderText = "Weight3";
            this.Weight3.MinimumWidth = 6;
            this.Weight3.Name = "Weight3";
            this.Weight3.ReadOnly = true;
            this.Weight3.Width = 125;
            // 
            // Weight4
            // 
            this.Weight4.HeaderText = "Weight4";
            this.Weight4.MinimumWidth = 6;
            this.Weight4.Name = "Weight4";
            this.Weight4.ReadOnly = true;
            this.Weight4.Width = 125;
            // 
            // Weight5
            // 
            this.Weight5.HeaderText = "Weight5";
            this.Weight5.MinimumWidth = 6;
            this.Weight5.Name = "Weight5";
            this.Weight5.ReadOnly = true;
            this.Weight5.Width = 125;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(1000, 424);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(162, 27);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "Удалить по рейсу";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Location = new System.Drawing.Point(232, 424);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(224, 27);
            this.Print_Button.TabIndex = 3;
            this.Print_Button.Text = "Создать файл и распечатать";
            this.Print_Button.UseVisualStyleBackColor = true;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(800, 415);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(78, 36);
            this.listBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(702, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Номер рейса";
            // 
            // Sort_Button
            // 
            this.Sort_Button.Location = new System.Drawing.Point(884, 424);
            this.Sort_Button.Name = "Sort_Button";
            this.Sort_Button.Size = new System.Drawing.Size(110, 27);
            this.Sort_Button.TabIndex = 6;
            this.Sort_Button.Text = "Сортировать";
            this.Sort_Button.UseVisualStyleBackColor = true;
            this.Sort_Button.Click += new System.EventHandler(this.Sort_Button_Click);
            // 
            // All_Button
            // 
            this.All_Button.Location = new System.Drawing.Point(93, 424);
            this.All_Button.Name = "All_Button";
            this.All_Button.Size = new System.Drawing.Size(133, 27);
            this.All_Button.TabIndex = 7;
            this.All_Button.Text = "Показать все";
            this.All_Button.UseVisualStyleBackColor = true;
            this.All_Button.Click += new System.EventHandler(this.All_Button_Click);
            // 
            // View_Passagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 459);
            this.Controls.Add(this.All_Button);
            this.Controls.Add(this.Sort_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Print_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Table_View_Flights);
            this.Controls.Add(this.Back_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "View_Passagers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр рейсов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.View_Flights_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Table_View_Flights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.DataGridView Table_View_Flights;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flight_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count_Bagage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight5;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Print_Button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Sort_Button;
        private System.Windows.Forms.Button All_Button;
    }
}