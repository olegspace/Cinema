namespace Cinema
{
    partial class AddFilmForm
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
            this.filmNameTextBox = new System.Windows.Forms.TextBox();
            this.durationMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.addFilmButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название фильма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Продолжительность фильма (чч:мм)";
            // 
            // filmNameTextBox
            // 
            this.filmNameTextBox.Location = new System.Drawing.Point(226, 10);
            this.filmNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.filmNameTextBox.Name = "filmNameTextBox";
            this.filmNameTextBox.Size = new System.Drawing.Size(230, 23);
            this.filmNameTextBox.TabIndex = 2;
            // 
            // durationMaskedTextBox
            // 
            this.durationMaskedTextBox.Location = new System.Drawing.Point(226, 38);
            this.durationMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.durationMaskedTextBox.Mask = "00:00";
            this.durationMaskedTextBox.Name = "durationMaskedTextBox";
            this.durationMaskedTextBox.Size = new System.Drawing.Size(134, 23);
            this.durationMaskedTextBox.TabIndex = 3;
            // 
            // addFilmButton
            // 
            this.addFilmButton.Location = new System.Drawing.Point(11, 97);
            this.addFilmButton.Margin = new System.Windows.Forms.Padding(2);
            this.addFilmButton.Name = "addFilmButton";
            this.addFilmButton.Size = new System.Drawing.Size(482, 44);
            this.addFilmButton.TabIndex = 4;
            this.addFilmButton.Text = "Создать фильм";
            this.addFilmButton.UseVisualStyleBackColor = true;
            this.addFilmButton.Click += new System.EventHandler(this.addFilmButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddFilmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 152);
            this.Controls.Add(this.addFilmButton);
            this.Controls.Add(this.durationMaskedTextBox);
            this.Controls.Add(this.filmNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddFilmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление фильма";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox filmNameTextBox;
        private MaskedTextBox durationMaskedTextBox;
        private Button addFilmButton;
        private ErrorProvider errorProvider;
    }
}