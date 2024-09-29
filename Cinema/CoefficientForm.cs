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

        public CoefficientForm(Hall hall, PricePolicy pricePolicy_)
        {
            InitializeComponent();
            pricePolicy = pricePolicy_;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Сохранение введённых коэффициентов
            for (int i = 0; i < coefficients.Count(); i++)
            {
                for (int j = 0; j < coefficients[0].Count(); j++)
                {
                    coefficients[i][j] = Convert.ToDouble(PlacesDataGridView[j, i].Value);
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
