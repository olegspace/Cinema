namespace Cinema
{
    partial class AddSessionForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sessionStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hallComboBox = new System.Windows.Forms.ComboBox();
            this.createSessionButton = new System.Windows.Forms.Button();
            this.filmComboBox = new System.Windows.Forms.ComboBox();
            this.filmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.basePriceNUD = new System.Windows.Forms.NumericUpDown();
            this.basePricelabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePriceNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название фильма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Начало кинопоказа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Зал кинопоказа";
            // 
            // sessionStartDateTimePicker
            // 
            this.sessionStartDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.sessionStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sessionStartDateTimePicker.Location = new System.Drawing.Point(231, 36);
            this.sessionStartDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.sessionStartDateTimePicker.Name = "sessionStartDateTimePicker";
            this.sessionStartDateTimePicker.Size = new System.Drawing.Size(208, 23);
            this.sessionStartDateTimePicker.TabIndex = 6;
            // 
            // hallComboBox
            // 
            this.hallComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hallComboBox.FormattingEnabled = true;
            this.hallComboBox.Location = new System.Drawing.Point(231, 117);
            this.hallComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.hallComboBox.Name = "hallComboBox";
            this.hallComboBox.Size = new System.Drawing.Size(208, 23);
            this.hallComboBox.TabIndex = 9;
            // 
            // createSessionButton
            // 
            this.createSessionButton.Location = new System.Drawing.Point(103, 173);
            this.createSessionButton.Margin = new System.Windows.Forms.Padding(2);
            this.createSessionButton.Name = "createSessionButton";
            this.createSessionButton.Size = new System.Drawing.Size(320, 53);
            this.createSessionButton.TabIndex = 10;
            this.createSessionButton.Text = "Создать кинопоказ";
            this.createSessionButton.UseVisualStyleBackColor = true;
            this.createSessionButton.Click += new System.EventHandler(this.createSessionButton_Click);
            // 
            // filmComboBox
            // 
            this.filmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filmComboBox.FormattingEnabled = true;
            this.filmComboBox.Location = new System.Drawing.Point(231, 9);
            this.filmComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.filmComboBox.Name = "filmComboBox";
            this.filmComboBox.Size = new System.Drawing.Size(208, 23);
            this.filmComboBox.TabIndex = 12;
            // 
            // filmBindingSource
            // 
            this.filmBindingSource.DataSource = typeof(Cinema.Film);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Политика ценообразования";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Расстояние места до первого ряда",
            "Близость места к центру"});
            this.comboBox1.Location = new System.Drawing.Point(231, 92);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 23);
            this.comboBox1.TabIndex = 16;
            // 
            // basePriceNUD
            // 
            this.basePriceNUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.basePriceNUD.Location = new System.Drawing.Point(231, 64);
            this.basePriceNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.basePriceNUD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.basePriceNUD.Name = "basePriceNUD";
            this.basePriceNUD.Size = new System.Drawing.Size(208, 23);
            this.basePriceNUD.TabIndex = 17;
            this.basePriceNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // basePricelabel
            // 
            this.basePricelabel.AutoSize = true;
            this.basePricelabel.Location = new System.Drawing.Point(60, 65);
            this.basePricelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.basePricelabel.Name = "basePricelabel";
            this.basePricelabel.Size = new System.Drawing.Size(120, 15);
            this.basePricelabel.TabIndex = 18;
            this.basePricelabel.Text = "Базовая цена билета";
            // 
            // AddSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 237);
            this.Controls.Add(this.basePricelabel);
            this.Controls.Add(this.basePriceNUD);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filmComboBox);
            this.Controls.Add(this.createSessionButton);
            this.Controls.Add(this.hallComboBox);
            this.Controls.Add(this.sessionStartDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddSessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый кинопоказ";
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePriceNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label5;
        private DateTimePicker sessionStartDateTimePicker;
        private ComboBox hallComboBox;
        private Button createSessionButton;
        private ComboBox filmComboBox;
        private BindingSource filmBindingSource;
        private Label label3;
        private ComboBox comboBox1;
        private NumericUpDown basePriceNUD;
        private Label basePricelabel;
    }
}