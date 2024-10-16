using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Cinema
{
    [Serializable]
    public class FilmSession
    {
        private static int idGenerator = 0;
        private int id;
        private int revenue;


        [JsonProperty]
        private Film film = new Film("", TimeSpan.Zero);

        [JsonProperty]
        public PricePolicy pricePolicy;

        private Hall hall;
        private DateTime date;
        private int basePrice;
        private int minPrice;
        private int maxPrice;

        public int Revenue { get => revenue; set => revenue = value; }
        public string FilmName 
        {
            get => film.name;
        }
        public Hall Hall { get => hall; set => hall = value; }
        public DateTime Date { get => date; set => date = value; }
        public int MinPrice { get => minPrice; set => minPrice = value; }
        public int MaxPrice { get => maxPrice; set => maxPrice = value; }
        public int BasePrice { get => basePrice; set => basePrice = value; }
        public int Id { get => id; set => id = value; }
        public TimeSpan Duration { get => film.duration; } 

        public FilmSession(Film film, Hall hall, DateTime date, int minPrice, int maxPrice, PricePolicy pp) 
        {
            this.film = film;
            this.Id = idGenerator++;
            this.Hall = hall;
            this.Date = date;
            Revenue = 0;
            this.basePrice = minPrice;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            pricePolicy = pp;
        }

        public FilmSession(Film film, Hall hall, DateTime date, int basePrice, PricePolicy pp)
        {
            this.film = film;
            this.Id = idGenerator++;
            this.Hall = hall;
            this.Date = date;
            Revenue = 0;
            this.basePrice = minPrice;
            minPrice = basePrice;
            pricePolicy = pp;
        }

        // [JsonConstructor]
        public FilmSession(int id, Film film_, Hall hall, DateTime dataTime, int minPrice, int maxPrice)
        {
            Id = id;
            film = film_;
            Hall = hall;
            Date = dataTime;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }

        [JsonConstructor]
        public FilmSession(int id, Film film_, Hall hall, DateTime dataTime, int basePrice)
        {
            Id = id;
            film = film_;
            Hall = hall;
            Date = dataTime;
            BasePrice = basePrice;
        }

        public FilmSession(int id, Hall hall)
        {
            Id = id;
            Hall = hall;
        }
        public int getRevenue() 
        {
            return Revenue;
        }

        public void SetRevenue(int toAdd)
        { 
            this.Revenue = toAdd;
        }
        public string GetFilmName()
        {
            return FilmName;
        }
        public DateTime GetSessionDate()
        {
            return Date;
        }
        
        public Hall GetHall() 
        {
            return Hall;
        }
        public string HallName()
        {
            return Hall.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is FilmSession otherFS)
            {
                return FilmName == otherFS.GetFilmName() &&
                Hall.Name == otherFS.Hall.Name &&
                Date.Equals(otherFS.Date);
            }

            return false;
        }

        public void AddRevenue(int value)
        {
            Revenue += value;
        }

        public int GetMinPrice()
        { 
            return MinPrice;
        }
        public int GetMaxPrice()
        {
            return MaxPrice;
        }
    }
}
