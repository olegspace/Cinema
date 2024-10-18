using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public abstract class PricePolicy
    {
        public abstract int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall);

        public abstract int CalculatePrice(int basePrice, Point position, Hall hall);

    }
}
