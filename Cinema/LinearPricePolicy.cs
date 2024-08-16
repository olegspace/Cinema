using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class LinearPricePolicy : PricePolicy
    {
        public int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall)
        {
            int lastRow = hall.Height;
            double val = maxPrice - (maxPrice - minPrice) * (double)position.X / (lastRow - 1);
            return (int)Math.Floor(val);
        }
    }
}
