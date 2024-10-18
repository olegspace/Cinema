
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Cinema
{
    [Serializable]
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
            // Загружаем коэффициенты из JSON, если они существуют
            string filePath = $"{this.Name}_coefficients.json";

            if (File.Exists(filePath))
            {
                try
                {
                    // Читаем JSON-файл
                    string json = File.ReadAllText(filePath);
                    var hallCoefficients = JsonConvert.DeserializeObject<HallCoefficients>(json);

                    if (hallCoefficients != null && hallCoefficients.LinearCoefficients != null && hallCoefficients.CenterCoefficients != null)
                    {
                        // Если данные найдены, подгружаем коэффициенты
                        linearCoefficients = hallCoefficients.LinearCoefficients;
                        centerCoefficients = hallCoefficients.CenterCoefficients;

                        return; // Завершаем метод, так как данные успешно загружены
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке коэффициентов из файла: {ex.Message}");
                }
            }

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
        public void SetLinearCoefficients(List<List<double>> coefficients)
        {
            linearCoefficients = coefficients;
        }

        public void SetCenterCoefficients(List<List<double>> coefficients)
        {
            centerCoefficients = coefficients;
        }

        public List<List<double>> GetLinearCoefficients() => linearCoefficients;
        public List<List<double>> GetCenterCoefficients() => centerCoefficients;
        public List<List<double>> GetCoefficients(PricePolicy pricePolicy)
        {
            if (pricePolicy is LinearPricePolicy)
            {
                return linearCoefficients; // Для политики "Расстояние до первого ряда"
            }
            else if (pricePolicy is CenterPricePolicy)
            {
                return centerCoefficients; // Для политики "Близость к центру"
            }
            else
            {
                throw new ArgumentException("Неизвестная политика ценообразования");
            }
        }
        public string SerializeCoefficientsToJson()
        {
            var coefficientsData = new
            {
                LinearCoefficients = linearCoefficients,
                CenterCoefficients = centerCoefficients
            };

            return JsonConvert.SerializeObject(coefficientsData);
        }

        // Метод для загрузки коэффициентов из JSON
        public void DeserializeCoefficientsFromJson(string json)
        {
            var coefficientsData = JsonConvert.DeserializeObject<Dictionary<string, List<List<double>>>>(json);
            linearCoefficients = coefficientsData["LinearCoefficients"];
            centerCoefficients = coefficientsData["CenterCoefficients"];
        }

        public Hall Clone()
        {
            // Клонируем зал, создавая новый объект с теми же параметрами
            Hall clonedHall = new Hall(width, height, name);

            // Клонируем состояние мест
            clonedHall.Places = new List<List<bool>>();
            foreach (var row in this.Places)
            {
                clonedHall.Places.Add(new List<bool>(row));
            }

            // Клонируем коэффициенты
            clonedHall.SetLinearCoefficients(this.linearCoefficients.Select(row => new List<double>(row)).ToList());
            clonedHall.SetCenterCoefficients(this.centerCoefficients.Select(row => new List<double>(row)).ToList());

            return clonedHall;
        }
        public override string ToString()
        {
            return name;
        }
    }    
}
