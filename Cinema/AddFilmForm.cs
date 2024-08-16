using CinemaApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class AddFilmForm : Form
    {
        private ChooseFilmForm parent;
        public AddFilmForm(ChooseFilmForm chooseFilmForm)
        {
            InitializeComponent();

            filmNameTextBox.Validating += FilmNameTextBox_Validating;
            durationMaskedTextBox.Validating += DurationMaskedTextBox_Validating;
            parent = chooseFilmForm;
        }

        private void DurationMaskedTextBox_Validating(object? sender, CancelEventArgs e)
        {
            TimeSpan dur;
            if (!TimeSpan.TryParse(durationMaskedTextBox.Text, out dur))
            {
                e.Cancel = true;
                errorProvider.SetError(durationMaskedTextBox, "Данные в поле ввода некорректны.");
                return;
            }

            errorProvider.Clear();
        }

        private void FilmNameTextBox_Validating(object? sender, CancelEventArgs e)
        {
            string name = filmNameTextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                errorProvider.SetError(filmNameTextBox, "Поле не может быть пустым");
                e.Cancel = true;
                return;
            }

            foreach (var f in parent.GetAllFilms())
            {
                if (f.name == name)
                {
                    errorProvider.SetError(filmNameTextBox, "Фильм с таким именем уже существует");
                    e.Cancel = true;
                    return;
                }
            }

            errorProvider.Clear();
        }

        private void addFilmButton_Click(object sender, EventArgs e)
        {
            string name = filmNameTextBox.Text;
            TimeSpan duration = TimeSpan.Parse(durationMaskedTextBox.Text);
            parent.AddFilm(name, duration);
            this.Close();
        }
    }
}
