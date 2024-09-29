
using System.Security.Cryptography;

namespace Cinema
{
    public class Hall
    {
        private int width;
        private int height;
        private string name;

        // Два списка для коэффициентов ценообразования
        private List<List<double>> linearCoefficients; // Для политики "Расстояние до первого ряда"
        private List<List<double>> centerCoefficients; // Для политики "Близость к центру"

        private List<List<bool>> places = new List<List<bool>>();
        public bool IsPlaced(Point pos)
        {
            return Places[pos.Y][pos.X];
        }

        public void LockPlace(Point pos)
        {
            Places[pos.Y][pos.X] = true;
        }

        public void UnlockPlace(Point pos)
        {
            Places[pos.Y][pos.X] = false;
        }

        public Hall(int width, int height, string name)
        {
            this.width = width;
            this.height = height;
            this.name = name;

            for (int row = 0; row < height; row++)
            {
                Places.Add(new List<bool>());

                for (int place = 0; place < width; place++)
                {
                    Places[row].Add(false);
                }
            }

            InitializeCoefficients(width, height);
        }

        private void InitializeCoefficients(int width, int height)
        {
            linearCoefficients = new List<List<double>>(height);
            centerCoefficients = new List<List<double>>(height);

            for (int row = 0; row < height; row++)
            {
                linearCoefficients.Add(new List<double>(new double[width]));
                centerCoefficients.Add(new List<double>(new double[width]));

                int middle = width / 2;

                if (width % 2 != 0)
                {
                    centerCoefficients[row][middle] = 2.0;

                    for (int col = 0; col < middle; col++)
                    {                        
                        centerCoefficients[row][col] = Math.Round(1 + ((double)col / middle), 2);
                        centerCoefficients[row][width - 1 - col] = centerCoefficients[row][col];
                    }
                }
                else
                {
                    centerCoefficients[row][middle] = 2.0;
                    centerCoefficients[row][middle - 1] = 2.0;

                    for (int col = 0; col < middle - 1; col++)
                    {
                        centerCoefficients[row][col] = Math.Round(1 + ((double)col / (middle - 1)), 2);
                        centerCoefficients[row][width - 1 - col] = centerCoefficients[row][col];

                    }
                }

                for (int col = 0; col < width; col++)
                {
                    linearCoefficients[row][col] = Math.Round(1 + ((height - row - 1) * 0.1), 2); 
                }
            }
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public string Name { get => name; }
        public List<List<bool>> Places { get => places; set => places = value; }

        public List<List<double>> GetLinearCoefficients() => linearCoefficients;
        public List<List<double>> GetCenterCoefficients() => centerCoefficients;

        public override string ToString()
        {
            return name;
        }
    }
}
