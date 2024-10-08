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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cinema
{
    public partial class ChooseHallForm : Form
    {
        private ChooseFilmController controller;
        private string hallName;
        private string pricePolicy;
        
        public ChooseHallForm(ChooseFilmController controller)
        {
            InitializeComponent();
            this.controller = controller;

            foreach (var hall in controller.GetHalls())
            {
                hallComboBox.Items.Add(hall.Name);
            }
        }

        private void hallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pricePolicyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void countineButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFormData())
            {
                return;
            }

            hallName = hallComboBox.Text;
            pricePolicy = pricePoliceComboBox.Text;

            Hall hall = controller.GetHallByName(hallName);
            PricePolicy pp = ChoosePricePolicy();

            CoefficientForm coefficientForm = new CoefficientForm(hall, pp);
            coefficientForm.ShowDialog();
            Close();
        }

        private PricePolicy ChoosePricePolicy()
        {
            if (pricePolicy == "Расстояние места до первого ряда")
            {
                return new LinearPricePolicy();
            }
            else if (pricePolicy == "Близость места к центру")
            {
                return new CenterPricePolicy();
            }

            throw new Exception("Указанная политика ценообразования не может быть обработана");
        }

        private bool ValidateFormData()
        {

            if (string.IsNullOrWhiteSpace(hallComboBox.Text))
            {
                MessageBox.Show("Поле с номером зала кинопоказа не может быть пустым");
                return false;
            }

            if (string.IsNullOrWhiteSpace(pricePoliceComboBox.Text))
            {
                MessageBox.Show("Поле с политикой ценообразования не может быть пустым");
                return false;
            }
            return true;
        }
    }
}
