using Newtonsoft.Json;
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
    public partial class CoefficientForm : Form
    {
        private List<List<double>> coefficients;
        private Hall hall;
        private PricePolicy pricePolicy;
        private DataGridView dataGridView;

        private int rows;  // Количество рядов в зале
        private int cols;  // Количество мест в ряду

        public CoefficientForm(Hall hall_, PricePolicy pricePolicy_)
        {
            InitializeComponent();
            hall = hall_;
            Text = "Зал " + hall.Name;
            pricePolicy = pricePolicy_;
            PlacesDataGridView.Rows.Clear();
            if (pricePolicy is LinearPricePolicy)
            {
                coefficients = hall.GetLinearCoefficients();
            }
            else if (pricePolicy is CenterPricePolicy)
            {
                coefficients = hall.GetCenterCoefficients();
            }
            if (coefficients is not null)
            {
                rows = coefficients.Count();
                cols = coefficients[0].Count();
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке коэффициентов", "Ошибка в настройке коэффициентов");// Ошибка получения коэффициентов
                return;
            }
            

            InitializeDataGridView(); 
        }

        private void InitializeDataGridView()
        {
            // Настраиваем количество строк и столбцов в DataGridView
            PlacesDataGridView.RowCount = rows;
            PlacesDataGridView.ColumnCount = cols;

            // Устанавливаем названия столбцов и строк
            for (int i = 0; i < cols; i++)
            {
                PlacesDataGridView.Columns[i].HeaderText = $"Место {i + 1}";
                PlacesDataGridView.Columns[i].Width = 50;  // Ширина столбца
            }

            for (int i = 0; i < rows; i++)
            {
                PlacesDataGridView.Rows[i].HeaderCell.Value = $"Ряд {i + 1}";
                PlacesDataGridView.Rows[i].Height = 30;  // Высота строки
            }

            // Заполняем таблицу начальными значениями коэффициентов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PlacesDataGridView[j, i].Value = coefficients[i][j];  // Устанавливаем значение коэффициента
                }
            }
        }
        public void SaveHallWithCoefficients(Hall hall)
        {
            HallCoefficients hallCoefficients  = new HallCoefficients(hall.GetLinearCoefficients(), hall.GetCenterCoefficients());
            // Преобразуем зал в JSON, включая коэффициенты
            string hallCoefficientsJson = JsonConvert.SerializeObject(hallCoefficients);

            // Путь для сохранения файла (например, "hall_coefficients.json")
            string filePath = $"{hall.Name}_coefficients.json";

            // Сохраняем JSON в файл
            File.WriteAllText(filePath, hallCoefficientsJson);

            MessageBox.Show("Коэффициенты зала успешно сохранены!");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Сохранение введённых коэффициентов
            //for (int i = 0; i < coefficients.Count(); i++)
            //{
            //    for (int j = 0; j < coefficients[0].Count(); j++)
            //    {
            //        coefficients[i][j] = Convert.ToDouble(PlacesDataGridView[j, i].Value);
            //    }
            //}

            //DialogResult = DialogResult.OK;
            //Close();

            for (int row = 0; row < PlacesDataGridView.RowCount; row++)
            {
                

                for (int col = 0; col < PlacesDataGridView.ColumnCount; col++)
                {
                    double coefficient = Convert.ToDouble(PlacesDataGridView.Rows[row].Cells[col].Value);
                    coefficients[row][col] = coefficient;
                }
            }

            // Сохраняем коэффициенты для выбранной политики
            if (pricePolicy is LinearPricePolicy)
            {
                hall.SetLinearCoefficients(coefficients);
            }
            else if (pricePolicy is CenterPricePolicy)
            {
                hall.SetCenterCoefficients(coefficients);
            }

            // Сохраняем зал с коэффициентами в JSON
            SaveHallWithCoefficients(hall);

            Close();
        }
    }
}
