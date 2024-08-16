using CinemaApp;
using System.Data;

namespace Cinema
{
    public partial class AddSessionForm : Form
    {
        private ChooseFilmForm controller;
        public AddSessionForm(ChooseFilmForm controller)
        {
            InitializeComponent();

            this.controller = controller;
            foreach (var hall in controller.GetHalls())
            {
                hallComboBox.Items.Add(hall.Name);
            }

            foreach (var f in controller.GetAllFilms())
            {
                filmComboBox.Items.Add(f.name);
            }
        }

        string movieName;
        DateTime dateAndTime;
        string hallNumber;
        int minPrice;
        int maxPrice;
        TimeSpan duration;

        private void button1_Click(object sender, EventArgs e)
        {

            // Retrieve entered details
            movieName = filmComboBox.Text;
            dateAndTime = sessionStartDateTimePicker.Value;
            hallNumber = hallComboBox.Text;

            if (!ValidateFormData())
            {
                return;
            }

            minPrice = int.Parse(minPriceMaskedTextBox.Text);
            maxPrice = int.Parse(maxPriceMaskedTextBox.Text);
            Film f = controller.FindFilm(movieName);
            PricePolicy pp = ChoosePricePolicy();
            if (f != null)
            {
                // Add a new film session to the controller
                controller.AddFilmSession(f, dateAndTime, hallNumber, minPrice, maxPrice,  pp);
            }
            else 
            {
                MessageBox.Show("невозможно найти фильм с навзанием " + movieName, "Ошибка данных");
            }

            // Close the form
            Close();
        }

        private PricePolicy ChoosePricePolicy()
        {
            if (comboBox1.Text == "Расстояние места до первого ряда")
            {
                return new LinearPricePolicy();
            }
            else if (comboBox1.Text == "Близость места к центру")
            {
                return new CenterPricePolicy();
            }

            throw new Exception("Указанная политика ценообразования не может быть обработана");
        }

        private bool ValidateFormData()
        {

            if (string.IsNullOrWhiteSpace(filmComboBox.Text))
            {
                MessageBox.Show("Поле с именем фильма не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(minPriceMaskedTextBox.Text))
            {
                MessageBox.Show("Поле с минимальной ценой билета не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Поле с политикой ценообразования не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(maxPriceMaskedTextBox.Text))
            {
                MessageBox.Show("Поле с максимальной ценой билета не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(sessionStartDateTimePicker.Text))
            {
                MessageBox.Show("Поле с датой и временем начала показа не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(hallComboBox.Text))
            {
                MessageBox.Show("Поле с номером зала кинопоказа не может быть пустым");
                return false;
            }

            try
            {
                minPrice = int.Parse(minPriceMaskedTextBox.Text);
                maxPrice = int.Parse(maxPriceMaskedTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в формате вводимых данных");
                return false;
            }
          
            if (minPrice > maxPrice)
            {
                MessageBox.Show("Минимальная цена должна быть меньше максимальной");
                return false;
            }

            if (IsSessionHasTimeCollision())
            {
                MessageBox.Show("Данный зал на время создаваемого кинопоказа занят. Попробуйте назначить другое время или другой зал.", "Пересечение времени в зале");
                return false;
            }


            return true;
        }

        private bool IsSessionHasTimeCollision()
        {
            var potentialCollisions = controller.GetFilmSessions().Where(fsc => fsc.GetHall().Name == hallComboBox.Text).ToList();

            foreach (var fsc in potentialCollisions)
            {
                DateTime start1 = fsc.GetSessionDate();
                DateTime start2 = dateAndTime;

                DateTime end1 = start1 + fsc.GetDuration();
                DateTime end2 = start2 + duration;

                // Проверка на пересечение
                if ((start1 >= start2 && start1 < end2) || (end1 > start2 && end1 <= end2) || (start1 <= start2 && end1 >= end2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
