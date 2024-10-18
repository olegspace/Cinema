using CinemaApp;
using System.Data;

namespace Cinema
{
    public partial class AddSessionForm : Form
    {
        private ChooseFilmForm controller;
        string movieName;
        DateTime dateAndTime;
        string hallNumber;
        int minPrice;
        int maxPrice;
        int basePrice;
        TimeSpan duration;

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

        private void createSessionButton_Click(object sender, EventArgs e)
        {

            // Retrieve entered details
            movieName = filmComboBox.Text;
            dateAndTime = DateTimeWithoutMinutes(sessionStartDateTimePicker.Value);
            hallNumber = hallComboBox.Text;

            if (!ValidateFormData())
            {
                return;
            }            

            basePrice = (int)basePriceNUD.Value;

            Film f = controller.FindFilm(movieName);
            duration = f.duration;

            if (IsSessionHasTimeCollision())
            {
                MessageBox.Show("Данный зал на время создаваемого кинопоказа занят. Попробуйте назначить другое время или другой зал.", "Пересечение времени в зале");
                return;
            }

            PricePolicy pp = ChoosePricePolicy();
            if (f != null)
            {
                controller.AddFilmSession(f, dateAndTime, hallNumber, basePrice, pp);
            }
            else 
            {
                MessageBox.Show("Невозможно найти фильм с навзанием " + movieName, "Ошибка данных");
            }

            Close();
        }

        private DateTime DateTimeWithoutMinutes(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
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

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Поле с политикой ценообразования не может быть пустым");
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
                basePrice = (int)basePriceNUD.Value;

            }
            catch
            {
                MessageBox.Show("Ошибка в формате вводимых данных");
                return false;
            }

            return true;
        }

        //private bool IsSessionHasTimeCollision()
        //{
        //    var potentialCollisions = controller.GetFilmSessions().Where(fsc => fsc.GetHall().Name == hallComboBox.Text).ToList();

        //    foreach (var fsc in potentialCollisions)
        //    {
        //        DateTime start1 = fsc.GetSessionDate();
        //        DateTime start2 = dateAndTime;

        //        DateTime end1 = start1 + fsc.GetDuration();
        //        DateTime end2 = start2 + duration;

        //        // Проверка на пересечение
        //        if ((start1 >= start2 && start1 < end2) || (end1 > start2 && end1 <= end2) || (start1 <= start2 && end1 >= end2))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        private bool IsSessionHasTimeCollision()
        {
            var potentialCollisions = controller.GetFilmSessions()
                .Where(fsc => fsc.GetHall().Name == hallComboBox.Text).ToList();

            foreach (var fsc in potentialCollisions)
            {
                DateTime start1 = fsc.GetSessionDate();   // Время начала текущего кинопоказа
                DateTime start2 = dateAndTime;            // Время начала нового кинопоказа

                DateTime end1 = start1 + fsc.GetDuration(); // Время окончания текущего кинопоказа
                DateTime end2 = start2 + duration;          // Время окончания нового кинопоказа

                // Проверка на пересечение: если один сеанс начинается до того, как другой закончится,
                // и заканчивается после начала другого сеанса
                if (start1 <= end2 && end1 >= start2)
                {
                    return true; // Пересечение по времени найдено
                }
            }

            return false; // Нет пересечений
        }
    }
}
