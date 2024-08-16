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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            filmNameTextBox = new TextBox();
            durationMaskedTextBox = new MaskedTextBox();
            addFilmButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 23);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 0;
            label1.Text = "Название фильма";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(311, 25);
            label2.TabIndex = 1;
            label2.Text = "Продолжительность фильма (чч:мм)";
            // 
            // filmNameTextBox
            // 
            filmNameTextBox.Location = new Point(323, 17);
            filmNameTextBox.Name = "filmNameTextBox";
            filmNameTextBox.Size = new Size(327, 31);
            filmNameTextBox.TabIndex = 2;
            // 
            // durationMaskedTextBox
            // 
            durationMaskedTextBox.Location = new Point(323, 63);
            durationMaskedTextBox.Mask = "00:00";
            durationMaskedTextBox.Name = "durationMaskedTextBox";
            durationMaskedTextBox.Size = new Size(190, 31);
            durationMaskedTextBox.TabIndex = 3;
            // 
            // addFilmButton
            // 
            addFilmButton.Location = new Point(12, 100);
            addFilmButton.Name = "addFilmButton";
            addFilmButton.Size = new Size(689, 73);
            addFilmButton.TabIndex = 4;
            addFilmButton.Text = "Создать фильм";
            addFilmButton.UseVisualStyleBackColor = true;
            addFilmButton.Click += addFilmButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // AddFilmForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 185);
            Controls.Add(addFilmButton);
            Controls.Add(durationMaskedTextBox);
            Controls.Add(filmNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddFilmForm";
            Text = "Добавление фильма";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
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