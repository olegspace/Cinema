namespace Cinema
{
    partial class CoefficientForm
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
            this.PlacesDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlacesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PlacesDataGridView
            // 
            this.PlacesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlacesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlacesDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlacesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PlacesDataGridView.Name = "PlacesDataGridView";
            this.PlacesDataGridView.RowTemplate.Height = 25;
            this.PlacesDataGridView.Size = new System.Drawing.Size(906, 464);
            this.PlacesDataGridView.TabIndex = 0;
            this.PlacesDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.PlacesDataGridView_EditingControlShowing);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(326, 485);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(241, 38);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CoefficientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 535);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.PlacesDataGridView);
            this.Name = "CoefficientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoefficientForm";
            ((System.ComponentModel.ISupportInitialize)(this.PlacesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button saveButton;
        private DataGridView PlacesDataGridView;
    }
}