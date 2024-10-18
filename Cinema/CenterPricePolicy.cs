using System;

namespace Cinema
{
    internal class CenterPricePolicy : PricePolicy
    {
        public override int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall)
        {
            int center = (hall.Height % 2 == 0) ? hall.Height / 2 - 1 : hall.Height / 2;

            // Расстояние от текущего места до края зала по горизонтали
            int distanceToEdge = Math.Min(position.Y, hall.Height - position.Y - 1);

            // Цена на левом краю или правом - base, на центральном x - 2 base,
            // между ними линейно меняется.
            double val = minPrice + (maxPrice - minPrice) * (double)distanceToEdge / ((double)center);
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
