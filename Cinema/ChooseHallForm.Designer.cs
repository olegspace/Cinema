namespace Cinema
{
    partial class ChooseHallForm
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
            this.pricePoliceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hallComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.countineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pricePoliceComboBox
            // 
            this.pricePoliceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pricePoliceComboBox.FormattingEnabled = true;
            this.pricePoliceComboBox.Items.AddRange(new object[] {
            "Расстояние места до первого ряда",
            "Близость места к центру"});
            this.pricePoliceComboBox.Location = new System.Drawing.Point(271, 112);
            this.pricePoliceComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.pricePoliceComboBox.Name = "pricePoliceComboBox";
            this.pricePoliceComboBox.Size = new System.Drawing.Size(178, 23);
            this.pricePoliceComboBox.TabIndex = 20;
            this.pricePoliceComboBox.SelectedIndexChanged += new System.EventHandler(this.pricePolicyComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Политика ценообразования";
            // 
            // hallComboBox
            // 
            this.hallComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hallComboBox.FormattingEnabled = true;
            this.hallComboBox.Location = new System.Drawing.Point(271, 72);
            this.hallComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.hallComboBox.Name = "hallComboBox";
            this.hallComboBox.Size = new System.Drawing.Size(178, 23);
            this.hallComboBox.TabIndex = 18;
            this.hallComboBox.SelectedIndexChanged += new System.EventHandler(this.hallComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(34, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Зал для настройки";
            // 
            // countineButton
            // 
            this.countineButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countineButton.Location = new System.Drawing.Point(36, 200);
            this.countineButton.Name = "countineButton";
            this.countineButton.Size = new System.Drawing.Size(403, 46);
            this.countineButton.TabIndex = 21;
            this.countineButton.Text = "Продолжить";
            this.countineButton.UseVisualStyleBackColor = true;
            this.countineButton.Click += new System.EventHandler(this.countineButton_Click);
            // 
            // ChooseHallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 258);
            this.Controls.Add(this.countineButton);
            this.Controls.Add(this.pricePoliceComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hallComboBox);
            this.Controls.Add(this.label5);
            this.Name = "ChooseHallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор зала для настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox pricePoliceComboBox;
        private Label label3;
        private ComboBox hallComboBox;
        private Label label5;
        private Button countineButton;
    }
}