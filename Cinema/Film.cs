namespace Cinema
{
    public class Film { 

        public Film(string name, TimeSpan dur) 
        {
            this.name = name;
            duration = dur;
        }

        public string name { get; set; }
        public TimeSpan duration { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
