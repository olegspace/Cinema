using System;

namespace Cinema
{
    internal class CenterPricePolicy : PricePolicy
    {
        public int CalculatePriceDefoult(int minPrice, int maxPrice, Point position, Hall hall)
        {
            int center = (hall.Height % 2 == 0) ? hall.Height / 2 - 1: hall.Height / 2;

            // Расстояние от текущего места до края зала по горизонтали
            int distanceToEdge = Math.Min(position.Y, hall.Height - position.Y - 1);

            // Цена на левом краю или правом - base, на центральном x - 2 base,
            // между ними линейно меняется.
            double val = minPrice + (maxPrice - minPrice) * (double)distanceToEdge / ((double)center);
            return (int)Math.Floor(val);
        }
        public int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall)
        {
            List<List<double>> coefficients = hall.GetCoefficients(this);
            double coefficient = coefficients[position.Y][position.X];  // Получаем коэффициент для места

            int basePrice = minPrice;
            int calculatedPrice = (int)(basePrice * coefficient);

            return Math.Max(minPrice, calculatedPrice);  // Убедимся, что цена не меньше минимальной
        }
    }
}
