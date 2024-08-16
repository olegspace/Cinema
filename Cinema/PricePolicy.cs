using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public interface PricePolicy
    {
        /// <summary>
        ///  Метод предоставляет сокрытие логики вычисления стоимости билета 
        ///  в зависимости от выбранного места и топологии зала.
        /// </summary>
        /// <param name="basePrice"> Базовая цена билета - минимально возможное значение.</param>
        /// <param name="position"> Ряд и место в кинозале.</param>
        /// <param name="gall"> Кинозал.</param>
        /// <returns></returns>
        public int CalculatePrice(int minPrice, int maxPrice, Point position, Hall hall);
    }
}
