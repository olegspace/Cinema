
namespace Cinema
{
    public class Hall
    {
        private int width;
        private int height;
        private string name;

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
            for (int row = 0; row < height; row++)
            {
                Places.Add(new List<bool>());

                for (int place = 0; place < width; place++)
                {
                    Places[row].Add(false);
                }
            }

            this.width = width;
            this.height = height;
            this.name = name;
        }   

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public string Name { get => name; }
        public List<List<bool>> Places { get => places; set => places = value; }


        public override string ToString()
        {
            return name;
        }
    }
}
