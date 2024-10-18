using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class LinearPricePolicy : PricePolicy
    {
        public override int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall)
        {
            int lastRow = hall.Height;
            double val = maxPrice - (maxPrice - minPrice) * (double)position.X / (lastRow - 1);
            return (int)Math.Floor(val);
        }

        public override int CalculatePrice(int basePrice, Point position, Hall hall)
        {
            List<List<double>> coefficients = hall.GetCoefficients(this);
            double coefficient = coefficients[position.X][position.Y];  // Получаем коэффициент для места

            int calculatedPrice = (int)(basePrice * coefficient);

            return Math.Max(basePrice, calculatedPrice);  // Убедимся, что цена не меньше минимальной
        }
    }
}
