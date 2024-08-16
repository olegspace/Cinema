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
        private Button removeButton;
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
        private Button addButton;
        private DataGridView filmsDataGridView;
        private BindingSource filmBindingSource;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn filmName;
        private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn1;
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
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            movieGrid1 = new DataGridView();
            movieName = new DataGridViewTextBoxColumn();
            Hall = new DataGridViewTextBoxColumn();
            dateTime = new DataGridViewTextBoxColumn();
            durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            revenueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            filmSessionBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            filmsDataGridView = new DataGridView();
            filmName = new DataGridViewTextBoxColumn();
            durationDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            filmBindingSource = new BindingSource(components);
            removeButton = new Button();
            addButton = new Button();
            button1 = new Button();
            button2 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movieGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmSessionBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filmsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Location = new Point(12, 331);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(744, 516);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(movieGrid1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(736, 478);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Кинопоказы";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // movieGrid1
            // 
            movieGrid1.AllowUserToAddRows = false;
            movieGrid1.AllowUserToDeleteRows = false;
            movieGrid1.AutoGenerateColumns = false;
            movieGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            movieGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movieGrid1.Columns.AddRange(new DataGridViewColumn[] { movieName, Hall, dateTime, durationDataGridViewTextBoxColumn, revenueDataGridViewTextBoxColumn });
            movieGrid1.DataSource = filmSessionBindingSource;
            movieGrid1.Dock = DockStyle.Fill;
            movieGrid1.Location = new Point(3, 3);
            movieGrid1.Name = "movieGrid1";
            movieGrid1.ReadOnly = true;
            movieGrid1.RowHeadersWidth = 62;
            movieGrid1.RowTemplate.Height = 33;
            movieGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            movieGrid1.Size = new Size(730, 472);
            movieGrid1.TabIndex = 0;
            // 
            // movieName
            // 
            movieName.DataPropertyName = "FilmName";
            movieName.HeaderText = "Фильм";
            movieName.MinimumWidth = 8;
            movieName.Name = "movieName";
            movieName.ReadOnly = true;
            // 
            // Hall
            // 
            Hall.DataPropertyName = "Hall";
            Hall.HeaderText = "Зал";
            Hall.MinimumWidth = 8;
            Hall.Name = "Hall";
            Hall.ReadOnly = true;
            // 
            // dateTime
            // 
            dateTime.DataPropertyName = "Date";
            dateTime.HeaderText = "Дата и время показа";
            dateTime.MinimumWidth = 8;
            dateTime.Name = "dateTime";
            dateTime.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            durationDataGridViewTextBoxColumn.HeaderText = "Продолжительность (чч:мм)";
            durationDataGridViewTextBoxColumn.MinimumWidth = 8;
            durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            revenueDataGridViewTextBoxColumn.DataPropertyName = "Revenue";
            revenueDataGridViewTextBoxColumn.HeaderText = "Выручка";
            revenueDataGridViewTextBoxColumn.MinimumWidth = 8;
            revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            revenueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filmSessionBindingSource
            // 
            filmSessionBindingSource.DataSource = typeof(FilmSession);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(filmsDataGridView);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(736, 478);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Фильмы";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // filmsDataGridView
            // 
            filmsDataGridView.AllowUserToAddRows = false;
            filmsDataGridView.AllowUserToDeleteRows = false;
            filmsDataGridView.AutoGenerateColumns = false;
            filmsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            filmsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filmsDataGridView.Columns.AddRange(new DataGridViewColumn[] { filmName, durationDataGridViewTextBoxColumn1 });
            filmsDataGridView.DataSource = filmBindingSource;
            filmsDataGridView.Dock = DockStyle.Fill;
            filmsDataGridView.Location = new Point(3, 3);
            filmsDataGridView.Name = "filmsDataGridView";
            filmsDataGridView.ReadOnly = true;
            filmsDataGridView.RowHeadersWidth = 62;
            filmsDataGridView.RowTemplate.Height = 33;
            filmsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            filmsDataGridView.Size = new Size(730, 472);
            filmsDataGridView.TabIndex = 0;
            // 
            // filmName
            // 
            filmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            filmName.DataPropertyName = "name";
            filmName.Frozen = true;
            filmName.HeaderText = "Название";
            filmName.MinimumWidth = 8;
            filmName.Name = "filmName";
            filmName.ReadOnly = true;
            filmName.Width = 126;
            // 
            // durationDataGridViewTextBoxColumn1
            // 
            durationDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            durationDataGridViewTextBoxColumn1.DataPropertyName = "duration";
            durationDataGridViewTextBoxColumn1.HeaderText = "Продолжительность";
            durationDataGridViewTextBoxColumn1.MinimumWidth = 8;
            durationDataGridViewTextBoxColumn1.Name = "durationDataGridViewTextBoxColumn1";
            durationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // filmBindingSource
            // 
            filmBindingSource.DataSource = typeof(Film);
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeButton.Location = new Point(7, 518);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(167, 42);
            removeButton.TabIndex = 6;
            removeButton.Text = "Удалить показ";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += RemoveButton_Click;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addButton.Location = new Point(583, 518);
            addButton.Name = "addButton";
            addButton.Size = new Size(157, 42);
            addButton.TabIndex = 7;
            addButton.Text = "Добавить показ";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(180, 518);
            button1.Name = "button1";
            button1.Size = new Size(167, 42);
            button1.TabIndex = 8;
            button1.Text = "Удалить фильм";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(420, 518);
            button2.Name = "button2";
            button2.Size = new Size(157, 42);
            button2.TabIndex = 9;
            button2.Text = "Добавить фильм";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ChooseFilmForm
            // 
            ClientSize = new Size(744, 569);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(tabControl1);
            Controls.Add(flowLayoutPanel1);
            Name = "ChooseFilmForm";
            Text = "Управление фильмами и показами";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movieGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmSessionBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)filmsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void UpdateFilmDataGrid()
        {
            filmsDataGridView.Rows.Clear();
            filmBindingSource.DataSource = controller.GetAllFilms();
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
