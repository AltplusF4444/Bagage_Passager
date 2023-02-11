namespace Bagage_Passager
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.View_Passagers = new System.Windows.Forms.Button();
            this.Create_Flight = new System.Windows.Forms.Button();
            this.Create_Passager = new System.Windows.Forms.Button();
            this.Load_DB = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Edit_Passager = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПО журнала \"Багаж пассажира\"";
            // 
            // View_Passagers
            // 
            this.View_Passagers.Location = new System.Drawing.Point(325, 64);
            this.View_Passagers.Name = "View_Passagers";
            this.View_Passagers.Size = new System.Drawing.Size(151, 47);
            this.View_Passagers.TabIndex = 1;
            this.View_Passagers.Text = "Просмотр пассажиров";
            this.View_Passagers.UseVisualStyleBackColor = true;
            this.View_Passagers.Click += new System.EventHandler(this.View_Passagers_Click);
            // 
            // Create_Flight
            // 
            this.Create_Flight.Location = new System.Drawing.Point(325, 117);
            this.Create_Flight.Name = "Create_Flight";
            this.Create_Flight.Size = new System.Drawing.Size(151, 38);
            this.Create_Flight.TabIndex = 2;
            this.Create_Flight.Text = "Создать рейс";
            this.Create_Flight.UseVisualStyleBackColor = true;
            this.Create_Flight.Click += new System.EventHandler(this.Create_Flight_Click);
            // 
            // Create_Passager
            // 
            this.Create_Passager.Location = new System.Drawing.Point(325, 161);
            this.Create_Passager.Name = "Create_Passager";
            this.Create_Passager.Size = new System.Drawing.Size(151, 44);
            this.Create_Passager.TabIndex = 3;
            this.Create_Passager.Text = "Создать пассажира";
            this.Create_Passager.UseVisualStyleBackColor = true;
            this.Create_Passager.Click += new System.EventHandler(this.Create_Passager_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Edit_Passager
            // 
            this.Edit_Passager.Location = new System.Drawing.Point(325, 211);
            this.Edit_Passager.Name = "Edit_Passager";
            this.Edit_Passager.Size = new System.Drawing.Size(151, 42);
            this.Edit_Passager.TabIndex = 4;
            this.Edit_Passager.Text = "Редактирование пассажира";
            this.Edit_Passager.UseVisualStyleBackColor = true;
            this.Edit_Passager.Click += new System.EventHandler(this.Edit_Passager_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Состояние соединения";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Edit_Passager);
            this.Controls.Add(this.Create_Passager);
            this.Controls.Add(this.Create_Flight);
            this.Controls.Add(this.View_Passagers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Багаж пассажира";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button View_Passagers;
        private System.Windows.Forms.Button Create_Flight;
        private System.Windows.Forms.Button Create_Passager;
        private System.ComponentModel.BackgroundWorker Load_DB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Edit_Passager;
        private System.Windows.Forms.Label label2;
    }
}

