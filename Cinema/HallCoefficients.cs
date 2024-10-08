using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class HallCoefficients
    {
        public List<List<double>> LinearCoefficients { get; set; }
        public List<List<double>> CenterCoefficients { get; set; }

        public HallCoefficients()
        {
            LinearCoefficients = new List<List<double>>();
            CenterCoefficients = new List<List<double>>();
        }
        public HallCoefficients(List<List<double>> linearCoefficients, List<List<double>> centerCoefficients)
        {
            LinearCoefficients = linearCoefficients;
            CenterCoefficients = centerCoefficients;
        }
    }
}
