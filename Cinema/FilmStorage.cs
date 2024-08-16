
using Newtonsoft.Json;

namespace Cinema
{
    public class FilmStorage 
    {
        private Dictionary<string, Film> sessions = new Dictionary<string, Film>();
        private string filePath = "films.json";

        public FilmStorage() 
        {
/*            sessions["Oppengamer"] = new Film("Oppengamer", TimeSpan.FromMinutes(175));
            sessions["Barby"] = new Film("Barby", TimeSpan.FromMinutes(155));
            SaveFilms();
            sessions.Clear();
*/
            var films = LoadFilms();
            foreach (var f in films)
            {
                sessions.Add(f.name, f);
            }
        }
        private void SaveFilms()
        {
            string json = JsonConvert.SerializeObject(sessions.Values);
            File.WriteAllText(filePath, json);
        }

        private List<Film> LoadFilms()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Film>>(json);
                }
                catch
                {
                    return new List<Film>();
                }
            }

            return new List<Film>();
        }


        public List<Film> GetFilms()
        {
            return sessions.Values.ToList();
        }

        public void Add(Film f)
        {
            sessions.Add(f.name, f);
            SaveFilms();
        }

        public void Remove(string name)
        {
            sessions.Remove(name);
            SaveFilms();
        }
    }
}
