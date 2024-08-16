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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            sessionStartDateTimePicker = new DateTimePicker();
            minPriceMaskedTextBox = new MaskedTextBox();
            hallComboBox = new ComboBox();
            createSessionButton = new Button();
            filmComboBox = new ComboBox();
            filmBindingSource = new BindingSource(components);
            maxPriceMaskedTextBox = new MaskedTextBox();
            maxPriceLabel = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 0;
            label1.Text = "Название фильма";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(174, 25);
            label2.TabIndex = 1;
            label2.Text = "Начало кинопоказа";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 103);
            label4.Name = "label4";
            label4.Size = new Size(229, 25);
            label4.TabIndex = 3;
            label4.Text = "Минимальная цена билета";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 220);
            label5.Name = "label5";
            label5.Size = new Size(141, 25);
            label5.TabIndex = 4;
            label5.Text = "Зал кинопоказа";
            // 
            // sessionStartDateTimePicker
            // 
            sessionStartDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            sessionStartDateTimePicker.Format = DateTimePickerFormat.Custom;
            sessionStartDateTimePicker.Location = new Point(256, 62);
            sessionStartDateTimePicker.Name = "sessionStartDateTimePicker";
            sessionStartDateTimePicker.Size = new Size(213, 31);
            sessionStartDateTimePicker.TabIndex = 6;
            // 
            // minPriceMaskedTextBox
            // 
            minPriceMaskedTextBox.Location = new Point(258, 97);
            minPriceMaskedTextBox.Mask = "00000";
            minPriceMaskedTextBox.Name = "minPriceMaskedTextBox";
            minPriceMaskedTextBox.Size = new Size(213, 31);
            minPriceMaskedTextBox.TabIndex = 7;
            minPriceMaskedTextBox.ValidatingType = typeof(int);
            // 
            // hallComboBox
            // 
            hallComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            hallComboBox.FormattingEnabled = true;
            hallComboBox.Location = new Point(256, 220);
            hallComboBox.Name = "hallComboBox";
            hallComboBox.Size = new Size(213, 33);
            hallComboBox.TabIndex = 9;
            // 
            // createSessionButton
            // 
            createSessionButton.Location = new Point(12, 270);
            createSessionButton.Name = "createSessionButton";
            createSessionButton.Size = new Size(457, 88);
            createSessionButton.TabIndex = 10;
            createSessionButton.Text = "Создать кинопоказ";
            createSessionButton.UseVisualStyleBackColor = true;
            createSessionButton.Click += button1_Click;
            // 
            // filmComboBox
            // 
            filmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filmComboBox.FormattingEnabled = true;
            filmComboBox.Location = new Point(256, 13);
            filmComboBox.Name = "filmComboBox";
            filmComboBox.Size = new Size(213, 33);
            filmComboBox.TabIndex = 12;
            // 
            // filmBindingSource
            // 
            filmBindingSource.DataSource = typeof(Film);
            // 
            // maxPriceMaskedTextBox
            // 
            maxPriceMaskedTextBox.Location = new Point(258, 135);
            maxPriceMaskedTextBox.Mask = "00000";
            maxPriceMaskedTextBox.Name = "maxPriceMaskedTextBox";
            maxPriceMaskedTextBox.Size = new Size(213, 31);
            maxPriceMaskedTextBox.TabIndex = 14;
            maxPriceMaskedTextBox.ValidatingType = typeof(int);
            // 
            // maxPriceLabel
            // 
            maxPriceLabel.AutoSize = true;
            maxPriceLabel.Location = new Point(12, 141);
            maxPriceLabel.Name = "maxPriceLabel";
            maxPriceLabel.Size = new Size(235, 25);
            maxPriceLabel.TabIndex = 13;
            maxPriceLabel.Text = "Максимальная цена билета";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 181);
            label3.Name = "label3";
            label3.Size = new Size(244, 25);
            label3.TabIndex = 15;
            label3.Text = "Политика ценообразования";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Расстояние места до первого ряда", "Близость места к центру" });
            comboBox1.Location = new Point(258, 173);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 33);
            comboBox1.TabIndex = 16;
            // 
            // AddSessionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 364);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(maxPriceMaskedTextBox);
            Controls.Add(maxPriceLabel);
            Controls.Add(filmComboBox);
            Controls.Add(createSessionButton);
            Controls.Add(hallComboBox);
            Controls.Add(minPriceMaskedTextBox);
            Controls.Add(sessionStartDateTimePicker);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddSessionForm";
            Text = "Новый кинопоказ";
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}