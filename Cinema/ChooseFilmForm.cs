using Cinema;
using System;
using System.Collections;
using System.Windows.Forms;

namespace CinemaApp
{
    /// <summary>
    /// Форма выбора и подверждения мест в кинозале показа фильма.
    /// </summary>
    public partial class ChooseFilmForm : Form
    {
        private Button removeSessionButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.ComponentModel.IContainer components;
        private DataGridView movieGrid1;
        private BindingSource filmSessionBindingSource;
        private DataGridViewTextBoxColumn movieName;
        private DataGridViewTextBoxColumn Hall;
        private DataGridViewTextBoxColumn dateTime;
/*        private DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
*/        private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn revenueDataGridViewTextBoxColumn;
        private Button addSessionButton;
        private DataGridView filmsDataGridView;
        private BindingSource filmBindingSource;
        private Button deleteFilmButton;
        private Button addFilmButton;
        private DataGridViewTextBoxColumn filmName;
        private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn1;
        private Button settingHallButton;
        private ChooseFilmController controller;
        public ChooseFilmForm(ChooseFilmController controller)
        {
            this.controller = controller;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            InitializeMovieGrid();

            filmBindingSource.DataSource = controller.GetAllFilms();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Create and show the form for adding movie sessions
            var addFilmSessionForm = new AddSessionForm(this);
            addFilmSessionForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (movieGrid1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Показ для удаления не выбран.");
                return;
            }
            var celectedRowIndex = movieGrid1.SelectedRows[0].Index;
            if (celectedRowIndex >= 0 && celectedRowIndex < controller.GetFilmSessionControllers().Count)
            {
                var dialogResult = MessageBox.Show("Вы действительно хотите удалить этот кинопоказ?", "Удаление кинопоказа", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var name = (String)movieGrid1.Rows[celectedRowIndex].Cells["MovieName"].Value;
                    var dateString = (DateTime)movieGrid1.Rows[celectedRowIndex].Cells["DateTime"].Value;
                    var hallNumber = (String)movieGrid1.Rows[celectedRowIndex].Cells["Hall"].Value.ToString();

                    var fscToRemove = controller.FindFilmSessionController(name, dateString, hallNumber);
                    if (fscToRemove != null)
                    {
                        controller.RemoveFilmSession(fscToRemove.GetId());
                        UpdateDataGrid();
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.movieGrid1 = new System.Windows.Forms.DataGridView();
            this.movieName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmSessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.filmsDataGridView = new System.Windows.Forms.DataGridView();
            this.filmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.removeSessionButton = new System.Windows.Forms.Button();
            this.addSessionButton = new System.Windows.Forms.Button();
            this.deleteFilmButton = new System.Windows.Forms.Button();
            this.addFilmButton = new System.Windows.Forms.Button();
            this.settingHallButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movieGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmSessionBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 331);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(952, 492);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.movieGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(944, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Кинопоказы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // movieGrid1
            // 
            this.movieGrid1.AllowUserToAddRows = false;
            this.movieGrid1.AllowUserToDeleteRows = false;
            this.movieGrid1.AutoGenerateColumns = false;
            this.movieGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.movieGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movieGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movieName,
            this.Hall,
            this.dateTime,
            this.durationDataGridViewTextBoxColumn,
            this.revenueDataGridViewTextBoxColumn});
            this.movieGrid1.DataSource = this.filmSessionBindingSource;
            this.movieGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movieGrid1.Location = new System.Drawing.Point(3, 3);
            this.movieGrid1.Name = "movieGrid1";
            this.movieGrid1.ReadOnly = true;
            this.movieGrid1.RowHeadersWidth = 62;
            this.movieGrid1.RowTemplate.Height = 33;
            this.movieGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.movieGrid1.Size = new System.Drawing.Size(938, 458);
            this.movieGrid1.TabIndex = 0;
            // 
            // movieName
            // 
            this.movieName.DataPropertyName = "FilmName";
            this.movieName.HeaderText = "Фильм";
            this.movieName.MinimumWidth = 8;
            this.movieName.Name = "movieName";
            this.movieName.ReadOnly = true;
            // 
            // Hall
            // 
            this.Hall.DataPropertyName = "Hall";
            this.Hall.HeaderText = "Зал";
            this.Hall.MinimumWidth = 8;
            this.Hall.Name = "Hall";
            this.Hall.ReadOnly = true;
            // 
            // dateTime
            // 
            this.dateTime.DataPropertyName = "Date";
            this.dateTime.HeaderText = "Дата и время показа";
            this.dateTime.MinimumWidth = 8;
            this.dateTime.Name = "dateTime";
            this.dateTime.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Продолжительность (чч:мм)";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            this.revenueDataGridViewTextBoxColumn.DataPropertyName = "Revenue";
            this.revenueDataGridViewTextBoxColumn.HeaderText = "Выручка";
            this.revenueDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            this.revenueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filmSessionBindingSource
            // 
            this.filmSessionBindingSource.DataSource = typeof(Cinema.FilmSession);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.filmsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(944, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Фильмы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // filmsDataGridView
            // 
            this.filmsDataGridView.AllowUserToAddRows = false;
            this.filmsDataGridView.AllowUserToDeleteRows = false;
            this.filmsDataGridView.AutoGenerateColumns = false;
            this.filmsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.filmsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filmsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filmName,
            this.durationDataGridViewTextBoxColumn1});
            this.filmsDataGridView.DataSource = this.filmBindingSource;
            this.filmsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filmsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.filmsDataGridView.Name = "filmsDataGridView";
            this.filmsDataGridView.ReadOnly = true;
            this.filmsDataGridView.RowHeadersWidth = 62;
            this.filmsDataGridView.RowTemplate.Height = 33;
            this.filmsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filmsDataGridView.Size = new System.Drawing.Size(938, 458);
            this.filmsDataGridView.TabIndex = 0;
            // 
            // filmName
            // 
            this.filmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.filmName.DataPropertyName = "name";
            this.filmName.Frozen = true;
            this.filmName.HeaderText = "Название";
            this.filmName.MinimumWidth = 8;
            this.filmName.Name = "filmName";
            this.filmName.ReadOnly = true;
            this.filmName.Width = 84;
            // 
            // durationDataGridViewTextBoxColumn1
            // 
            this.durationDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.durationDataGridViewTextBoxColumn1.DataPropertyName = "duration";
            this.durationDataGridViewTextBoxColumn1.HeaderText = "Продолжительность";
            this.durationDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.durationDataGridViewTextBoxColumn1.Name = "durationDataGridViewTextBoxColumn1";
            this.durationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // filmBindingSource
            // 
            this.filmBindingSource.DataSource = typeof(Cinema.Film);
            // 
            // removeSessionButton
            // 
            this.removeSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSessionButton.Location = new System.Drawing.Point(7, 494);
            this.removeSessionButton.Name = "removeSessionButton";
            this.removeSessionButton.Size = new System.Drawing.Size(167, 42);
            this.removeSessionButton.TabIndex = 6;
            this.removeSessionButton.Text = "Удалить показ";
            this.removeSessionButton.UseVisualStyleBackColor = true;
            this.removeSessionButton.Click += new System.EventHandler(this.removeSessionButton_Click);
            // 
            // addSessionButton
            // 
            this.addSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSessionButton.Location = new System.Drawing.Point(791, 494);
            this.addSessionButton.Name = "addSessionButton";
            this.addSessionButton.Size = new System.Drawing.Size(157, 42);
            this.addSessionButton.TabIndex = 7;
            this.addSessionButton.Text = "Добавить показ";
            this.addSessionButton.UseVisualStyleBackColor = true;
            this.addSessionButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteFilmButton
            // 
            this.deleteFilmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteFilmButton.Location = new System.Drawing.Point(180, 494);
            this.deleteFilmButton.Name = "deleteFilmButton";
            this.deleteFilmButton.Size = new System.Drawing.Size(167, 42);
            this.deleteFilmButton.TabIndex = 8;
            this.deleteFilmButton.Text = "Удалить фильм";
            this.deleteFilmButton.UseVisualStyleBackColor = true;
            this.deleteFilmButton.Click += new System.EventHandler(this.deleteFilmButton_Click);
            // 
            // addFilmButton
            // 
            this.addFilmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilmButton.Location = new System.Drawing.Point(628, 494);
            this.addFilmButton.Name = "addFilmButton";
            this.addFilmButton.Size = new System.Drawing.Size(157, 42);
            this.addFilmButton.TabIndex = 9;
            this.addFilmButton.Text = "Добавить фильм";
            this.addFilmButton.UseVisualStyleBackColor = true;
            this.addFilmButton.Click += new System.EventHandler(this.addFilmButton_Click);
            // 
            // settingHallButton
            // 
            this.settingHallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingHallButton.Location = new System.Drawing.Point(465, 494);
            this.settingHallButton.Name = "settingHallButton";
            this.settingHallButton.Size = new System.Drawing.Size(157, 42);
            this.settingHallButton.TabIndex = 10;
            this.settingHallButton.Text = "Настройки зала";
            this.settingHallButton.UseVisualStyleBackColor = true;
            this.settingHallButton.Click += new System.EventHandler(this.settingHallButton_Click);
            // 
            // ChooseFilmForm
            // 
            this.ClientSize = new System.Drawing.Size(952, 545);
            this.Controls.Add(this.settingHallButton);
            this.Controls.Add(this.addFilmButton);
            this.Controls.Add(this.deleteFilmButton);
            this.Controls.Add(this.addSessionButton);
            this.Controls.Add(this.removeSessionButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ChooseFilmForm";
            this.Text = "Управление фильмами и показами";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movieGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmSessionBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filmsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeMovieGrid()
        {
            filmSessionBindingSource.DataSource = controller.GetFilmSessions();
            // Обработчик события для клика на табличке
            movieGrid1.CellDoubleClick += MovieGrid_CellClick;
        }

        private void MovieGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < movieGrid1.Rows.Count)
            {
                // Получаем выбранный фильм и отображаем его информацию
                DataGridViewRow selectedRow = ((DataGridView)sender).Rows[e.RowIndex];
                string movieName = selectedRow.Cells["MovieName"].Value.ToString();
                string dateTime = selectedRow.Cells["DateTime"].Value.ToString();
                string hallNumber = selectedRow.Cells["Hall"].Value.ToString();

                // Выводим диалоговое окно с кнопками "Окей" и "Отмена"
                DialogResult result = MessageBox.Show($"Вы выбрали фильм '{movieName}' в {dateTime} в зале {hallNumber}",
                                                    "Выбор фильма",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // Пользователь нажал "Окей", создаем новое окно типа CinemaHall                    
                    FilmSessionController fsc = controller.FindFilmSessionController(movieName, DateTime.Parse(dateTime), hallNumber);
                    CinemaHallForm cinemaHallForm = new CinemaHallForm(fsc);
                    cinemaHallForm.ShowDialog();

                    UpdateDataGrid();
                }
            }
        }

        private void UpdateDataGrid()
        {
            movieGrid1.Rows.Clear();
            filmSessionBindingSource.DataSource = controller.GetFilmSessions();
        }

        public void AddFilmSession(Film film, DateTime dateAndTime, string hallNumber, int minPrice, int maxPrice, PricePolicy pp)
        {
            FilmSession newFs = new FilmSession(film, controller.GetHallByName(hallNumber), dateAndTime, minPrice, maxPrice, pp);
            controller.AddFilmSession(newFs);
            UpdateDataGrid();
        }

        public IEnumerable<FilmSessionController> GetFilmSessions()
        {
            return controller.GetFilmSessionControllers();
        }
        public IEnumerable<Hall> GetHalls()
        {
            return controller.GetHalls();
        }

        internal Film FindFilm(string movieName)
        {
            return controller.FindFilm(movieName);
        }

        internal IList<Film> GetAllFilms()
        {
            return controller.GetAllFilms();
        }

        private void UpdateFilmDataGrid()
        {
            filmsDataGridView.Rows.Clear();
            filmBindingSource.DataSource = controller.GetAllFilms();
        }

        private void addFilmButton_Click(object sender, EventArgs e)
        {
            // Create and show the form for adding movie sessions
            var addFilmForm = new AddFilmForm(this);
            addFilmForm.ShowDialog();
            UpdateFilmDataGrid();

        }

        internal void AddFilm(string name, TimeSpan duration)
        {
            controller.AddFilm(name, duration);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Create and show the form for adding movie sessions
            var addFilmSessionForm = new AddSessionForm(this);
            addFilmSessionForm.ShowDialog();
        }

        private void deleteFilmButton_Click(object sender, EventArgs e)
        {
            if (filmsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Фильм для удаления не выбран.");
                return;
            }
            var celectedRowIndex = filmsDataGridView.SelectedRows[0].Index;
            if (celectedRowIndex >= 0 && celectedRowIndex < controller.GetAllFilms().Count)
            {
                var dialogResult = MessageBox.Show("Вы действительно хотите удалить этот фильм?", "Удаление фильма", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var name = (String)filmsDataGridView.Rows[celectedRowIndex].Cells["filmName"].Value;

                    var filmToRemove = controller.FindFilm(name);
                    if (filmToRemove != null)
                    {
                        controller.RemoveFilm(filmToRemove.name);
                        UpdateFilmDataGrid();
                        UpdateDataGrid();
                    }
                }
            }
        }

        private void removeSessionButton_Click(object sender, EventArgs e)
        {
            if (movieGrid1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Показ для удаления не выбран.");
                return;
            }
            var celectedRowIndex = movieGrid1.SelectedRows[0].Index;
            if (celectedRowIndex >= 0 && celectedRowIndex < controller.GetFilmSessionControllers().Count)
            {
                var dialogResult = MessageBox.Show("Вы действительно хотите удалить этот кинопоказ?", "Удаление кинопоказа", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var name = (String)movieGrid1.Rows[celectedRowIndex].Cells["MovieName"].Value;
                    var dateString = (DateTime)movieGrid1.Rows[celectedRowIndex].Cells["DateTime"].Value;
                    var hallNumber = (String)movieGrid1.Rows[celectedRowIndex].Cells["Hall"].Value.ToString();

                    var fscToRemove = controller.FindFilmSessionController(name, dateString, hallNumber);
                    if (fscToRemove != null)
                    {
                        controller.RemoveFilmSession(fscToRemove.GetId());
                        UpdateDataGrid();
                    }
                }
            }
        }

        private void settingHallButton_Click(object sender, EventArgs e)
        {
            ChooseHallForm chooseHallForm = new ChooseHallForm(controller);
            chooseHallForm.ShowDialog();
        }
    }
}
