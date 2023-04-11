namespace otk
{
    partial class DataUploadForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelHeader = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходВОкноРегистрацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходВОкноВходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.numericUpDownForSelected = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownForAdd = new System.Windows.Forms.NumericUpDown();
            this.labelForSelected = new System.Windows.Forms.Label();
            this.labelForAdd = new System.Windows.Forms.Label();
            this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(858, 400);
            this.dataGridView1.TabIndex = 5;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(12, 100);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(115, 29);
            this.labelHeader.TabIndex = 4;
            this.labelHeader.Text = "Данные:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьДанныеToolStripMenuItem,
            this.редактироватьДанныеToolStripMenuItem,
            this.загрузитьДанныеToolStripMenuItem,
            this.выгрузитьДанныеToolStripMenuItem,
            this.изменитьДанныеToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // обновитьДанныеToolStripMenuItem
            // 
            this.обновитьДанныеToolStripMenuItem.Name = "обновитьДанныеToolStripMenuItem";
            this.обновитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.обновитьДанныеToolStripMenuItem.Text = "Обновить данные";
            // 
            // редактироватьДанныеToolStripMenuItem
            // 
            this.редактироватьДанныеToolStripMenuItem.Name = "редактироватьДанныеToolStripMenuItem";
            this.редактироватьДанныеToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.редактироватьДанныеToolStripMenuItem.Text = "Редактировать данные";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзПрограммыToolStripMenuItem,
            this.выходВОкноРегистрацииToolStripMenuItem,
            this.выходВОкноВходаToolStripMenuItem});
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // выходИзПрограммыToolStripMenuItem
            // 
            this.выходИзПрограммыToolStripMenuItem.Name = "выходИзПрограммыToolStripMenuItem";
            this.выходИзПрограммыToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.выходИзПрограммыToolStripMenuItem.Text = "Выход из программы";
            // 
            // выходВОкноРегистрацииToolStripMenuItem
            // 
            this.выходВОкноРегистрацииToolStripMenuItem.Name = "выходВОкноРегистрацииToolStripMenuItem";
            this.выходВОкноРегистрацииToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.выходВОкноРегистрацииToolStripMenuItem.Text = "Выход в окно регистрации";
            // 
            // выходВОкноВходаToolStripMenuItem
            // 
            this.выходВОкноВходаToolStripMenuItem.Name = "выходВОкноВходаToolStripMenuItem";
            this.выходВОкноВходаToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.выходВОкноВходаToolStripMenuItem.Text = "Выход в окно входа";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonChoose);
            this.groupBoxSettings.Controls.Add(this.buttonCreate);
            this.groupBoxSettings.Controls.Add(this.numericUpDownForSelected);
            this.groupBoxSettings.Controls.Add(this.numericUpDownForAdd);
            this.groupBoxSettings.Controls.Add(this.labelForSelected);
            this.groupBoxSettings.Controls.Add(this.labelForAdd);
            this.groupBoxSettings.Location = new System.Drawing.Point(327, 36);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(518, 93);
            this.groupBoxSettings.TabIndex = 6;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Настройки";
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(400, 63);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(96, 23);
            this.buttonChoose.TabIndex = 2;
            this.buttonChoose.Text = "Выбрать";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(400, 29);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(96, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // numericUpDownForSelected
            // 
            this.numericUpDownForSelected.Location = new System.Drawing.Point(261, 63);
            this.numericUpDownForSelected.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownForSelected.Name = "numericUpDownForSelected";
            this.numericUpDownForSelected.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownForSelected.TabIndex = 1;
            this.numericUpDownForSelected.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownForAdd
            // 
            this.numericUpDownForAdd.Location = new System.Drawing.Point(261, 30);
            this.numericUpDownForAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownForAdd.Name = "numericUpDownForAdd";
            this.numericUpDownForAdd.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownForAdd.TabIndex = 1;
            this.numericUpDownForAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelForSelected
            // 
            this.labelForSelected.AutoSize = true;
            this.labelForSelected.Location = new System.Drawing.Point(143, 63);
            this.labelForSelected.Name = "labelForSelected";
            this.labelForSelected.Size = new System.Drawing.Size(102, 16);
            this.labelForSelected.TabIndex = 0;
            this.labelForSelected.Text = "Выбор данных:";
            // 
            // labelForAdd
            // 
            this.labelForAdd.AutoSize = true;
            this.labelForAdd.Location = new System.Drawing.Point(17, 32);
            this.labelForAdd.Name = "labelForAdd";
            this.labelForAdd.Size = new System.Drawing.Size(228, 16);
            this.labelForAdd.TabIndex = 0;
            this.labelForAdd.Text = "Количество добавляемых данных:";
            // 
            // загрузитьДанныеToolStripMenuItem
            // 
            this.загрузитьДанныеToolStripMenuItem.Name = "загрузитьДанныеToolStripMenuItem";
            this.загрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить данные";
            this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеToolStripMenuItem_Click);
            // 
            // выгрузитьДанныеToolStripMenuItem
            // 
            this.выгрузитьДанныеToolStripMenuItem.Name = "выгрузитьДанныеToolStripMenuItem";
            this.выгрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.выгрузитьДанныеToolStripMenuItem.Text = "Выгрузить данные";
            this.выгрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьДанныеToolStripMenuItem_Click);
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.изменитьДанныеToolStripMenuItem_Click);
            // 
            // DataUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "DataUploadForm";
            this.Text = "DataUploadForm";
            this.Shown += new System.EventHandler(this.DataUploadForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходВОкноРегистрацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходВОкноВходаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.NumericUpDown numericUpDownForSelected;
        private System.Windows.Forms.NumericUpDown numericUpDownForAdd;
        private System.Windows.Forms.Label labelForSelected;
        private System.Windows.Forms.Label labelForAdd;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
    }
}