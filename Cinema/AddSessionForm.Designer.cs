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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sessionStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.minPriceMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.hallComboBox = new System.Windows.Forms.ComboBox();
            this.createSessionButton = new System.Windows.Forms.Button();
            this.filmComboBox = new System.Windows.Forms.ComboBox();
            this.filmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maxPriceMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.maxPriceLabel = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название фильма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Начало кинопоказа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Минимальная цена билета";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 171);
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
            this.sessionStartDateTimePicker.Location = new System.Drawing.Point(179, 35);
            this.sessionStartDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.sessionStartDateTimePicker.Name = "sessionStartDateTimePicker";
            this.sessionStartDateTimePicker.Size = new System.Drawing.Size(178, 23);
            this.sessionStartDateTimePicker.TabIndex = 6;
            // 
            // minPriceMaskedTextBox
            // 
            this.minPriceMaskedTextBox.Enabled = false;
            this.minPriceMaskedTextBox.Location = new System.Drawing.Point(179, 93);
            this.minPriceMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.minPriceMaskedTextBox.Mask = "00000";
            this.minPriceMaskedTextBox.Name = "minPriceMaskedTextBox";
            this.minPriceMaskedTextBox.Size = new System.Drawing.Size(178, 23);
            this.minPriceMaskedTextBox.TabIndex = 7;
            this.minPriceMaskedTextBox.ValidatingType = typeof(int);
            // 
            // hallComboBox
            // 
            this.hallComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hallComboBox.FormattingEnabled = true;
            this.hallComboBox.Location = new System.Drawing.Point(179, 169);
            this.hallComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.hallComboBox.Name = "hallComboBox";
            this.hallComboBox.Size = new System.Drawing.Size(178, 23);
            this.hallComboBox.TabIndex = 9;
            // 
            // createSessionButton
            // 
            this.createSessionButton.Location = new System.Drawing.Point(26, 214);
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
            this.filmComboBox.Location = new System.Drawing.Point(179, 8);
            this.filmComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.filmComboBox.Name = "filmComboBox";
            this.filmComboBox.Size = new System.Drawing.Size(178, 23);
            this.filmComboBox.TabIndex = 12;
            // 
            // filmBindingSource
            // 
            this.filmBindingSource.DataSource = typeof(Cinema.Film);
            // 
            // maxPriceMaskedTextBox
            // 
            this.maxPriceMaskedTextBox.Enabled = false;
            this.maxPriceMaskedTextBox.Location = new System.Drawing.Point(179, 118);
            this.maxPriceMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.maxPriceMaskedTextBox.Mask = "00000";
            this.maxPriceMaskedTextBox.Name = "maxPriceMaskedTextBox";
            this.maxPriceMaskedTextBox.Size = new System.Drawing.Size(178, 23);
            this.maxPriceMaskedTextBox.TabIndex = 14;
            this.maxPriceMaskedTextBox.ValidatingType = typeof(int);
            // 
            // maxPriceLabel
            // 
            this.maxPriceLabel.AutoSize = true;
            this.maxPriceLabel.Location = new System.Drawing.Point(8, 124);
            this.maxPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxPriceLabel.Name = "maxPriceLabel";
            this.maxPriceLabel.Size = new System.Drawing.Size(160, 15);
            this.maxPriceLabel.TabIndex = 13;
            this.maxPriceLabel.Text = "Максимальная цена билета";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 149);
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
            this.comboBox1.Location = new System.Drawing.Point(179, 144);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 23);
            this.comboBox1.TabIndex = 16;
            // 
            // basePriceNUD
            // 
            this.basePriceNUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.basePriceNUD.Location = new System.Drawing.Point(179, 63);
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
            this.basePriceNUD.Size = new System.Drawing.Size(120, 23);
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
            this.basePricelabel.Location = new System.Drawing.Point(8, 64);
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
            this.ClientSize = new System.Drawing.Size(390, 278);
            this.Controls.Add(this.basePricelabel);
            this.Controls.Add(this.basePriceNUD);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxPriceMaskedTextBox);
            this.Controls.Add(this.maxPriceLabel);
            this.Controls.Add(this.filmComboBox);
            this.Controls.Add(this.createSessionButton);
            this.Controls.Add(this.hallComboBox);
            this.Controls.Add(this.minPriceMaskedTextBox);
            this.Controls.Add(this.sessionStartDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
        private Label label4;
        private Label label5;
        private DateTimePicker sessionStartDateTimePicker;
        private MaskedTextBox minPriceMaskedTextBox;
        private ComboBox hallComboBox;
        private Button createSessionButton;
        private ComboBox filmComboBox;
        private BindingSource filmBindingSource;
        private MaskedTextBox maxPriceMaskedTextBox;
        private Label maxPriceLabel;
        private Label label3;
        private ComboBox comboBox1;
        private NumericUpDown basePriceNUD;
        private Label basePricelabel;
    }
}