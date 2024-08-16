using Newtonsoft.Json;

namespace Cinema
{
    internal class FileFilmSessionStorage : IFilmSessionStorage
    {
        private Dictionary<int, FilmSession> sessions = new Dictionary<int, FilmSession>();
        private string filePath = "filmsessions.json";

        public FileFilmSessionStorage()
        {
            List<FilmSession> sessionsList = LoadFilmSessions();
             
            foreach (FilmSession session in sessionsList) 
            {
                sessions.Add(session.Id, session);
            }
        }

        public List<FilmSession> GetFilmSessions()
        { 
            return sessions.Values.ToList();
        }

        private void SaveFilmSessions()
        {
            string json = JsonConvert.SerializeObject(sessions.Values, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(filePath, json);
        }

        private List<FilmSession> LoadFilmSessions()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<FilmSession>>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto});
                }
                catch
                {
                    return new List<FilmSession>();
                }
            }

            return new List<FilmSession>();
        }

        public int GetHallHeight(int sessionId)
        {
            return sessions.GetValueOrDefault(sessionId).GetHall().Height;
        }

        public int GetHallWidth(int sessionId)
        {
            return sessions.GetValueOrDefault(sessionId).GetHall().Width;
        }

        public bool IsPlaced(int sessionId, Point pos)
        {
            SaveFilmSessions();
            return sessions.GetValueOrDefault(sessionId).GetHall().IsPlaced(pos);
        }

        public void LockPlace(int sessionId, Point pos)
        {
            sessions.GetValueOrDefault(sessionId).GetHall().LockPlace(pos);
            SaveFilmSessions();
        }

        public void UnlockPlace(int sessionId, Point pos)
        {
            sessions.GetValueOrDefault(sessionId).GetHall().UnlockPlace(pos);
            SaveFilmSessions();
        }

        public void Add(FilmSession f)
        {
            if (sessions.Values.Count > 0)
            {
                f.Id = sessions.Values.Max(s => s.Id) + 1;
                sessions.Add(f.Id, f);
            }
            else 
            {
                sessions.Add(f.Id, f);
            }
            SaveFilmSessions();
        }

        public void Remove(int fsId)
        {
            sessions.Remove(fsId);
            SaveFilmSessions();
        }
    }
}