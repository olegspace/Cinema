using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class CustomPricePolicy : PricePolicy
    {
        private double[,] _coefficients;

        public CustomPricePolicy(double[,] coefficients)
        {
            _coefficients = coefficients;
        }

        public int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall)
        {
            int basePrice = minPrice; // Базовая цена равна минимальной
            double coefficient = _coefficients[position.Y, position.X];
            return (int)(basePrice * coefficient);
        }

        public void SetCoefficient(int row, int column, double value)
        {
            _coefficients[row, column] = value;
        }

        public double GetCoefficient(int row, int column)
        {
            return _coefficients[row, column];
        }
    }

}
