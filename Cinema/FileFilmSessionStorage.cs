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
            string json = JsonConvert.SerializeObject(sessions.Values, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented // Для более удобного чтения
            });
            File.WriteAllText(filePath, json);
        }

        //private List<FilmSession> LoadFilmSessions()
        //{
        //    if (File.Exists(filePath))
        //    {
        //        try
        //        {
        //            string json = File.ReadAllText(filePath);
        //            return JsonConvert.DeserializeObject<List<FilmSession>>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto});
        //        }
        //        catch
        //        {
        //            return new List<FilmSession>();
        //        }
        //    }

        //    return new List<FilmSession>();
        //}

        private List<FilmSession> LoadFilmSessions()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    List<FilmSession> sessionsList = JsonConvert.DeserializeObject<List<FilmSession>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                    // Проверяем, есть ли коэффициенты у каждого зала, и инициализируем их при необходимости
                    foreach (var session in sessionsList)
                    {
                        Hall hall = session.Hall;

                        if (hall.GetLinearCoefficients() == null || hall.GetLinearCoefficients().Count == 0)
                        {
                            hall.SetLinearCoefficients(InitializeDefaultLinearCoefficients(hall.Width, hall.Height));
                        }

                        if (hall.GetCenterCoefficients() == null || hall.GetCenterCoefficients().Count == 0)
                        {
                            hall.SetCenterCoefficients(InitializeDefaultCenterCoefficients(hall.Width, hall.Height));
                        }
                    }

                    return sessionsList;
                }
                catch
                {
                    return new List<FilmSession>();
                }
            }

            return new List<FilmSession>();
        }

        private List<List<double>> InitializeDefaultLinearCoefficients(int width, int height)
        {
            var coefficients = new List<List<double>>(height);
            for (int row = 0; row < height; row++)
            {
                var rowCoefficients = new List<double>(width);
                for (int col = 0; col < width; col++)
                {
                    rowCoefficients.Add(Math.Round(1 + ((height - row - 1) * 0.1), 2)); // Пример инициализации
                }
                coefficients.Add(rowCoefficients);
            }
            return coefficients;
        }

        private List<List<double>> InitializeDefaultCenterCoefficients(int width, int height)
        {
            var coefficients = new List<List<double>>(height);
            for (int row = 0; row < height; row++)
            {
                var rowCoefficients = new List<double>(width);
                int middle = width / 2;

                if (width % 2 != 0)
                {
                    rowCoefficients[middle] = 2.0;
                    for (int col = 0; col < middle; col++)
                    {
                        rowCoefficients[col] = Math.Round(1 + ((double)col / middle), 2);
                        rowCoefficients[width - 1 - col] = rowCoefficients[col];
                    }
                }
                else
                {
                    rowCoefficients[middle] = 2.0;
                    rowCoefficients[middle - 1] = 2.0;
                    for (int col = 0; col < middle - 1; col++)
                    {
                        rowCoefficients[col] = Math.Round(1 + ((double)col / (middle - 1)), 2);
                        rowCoefficients[width - 1 - col] = rowCoefficients[col];
                    }
                }

                coefficients.Add(rowCoefficients);
            }
            return coefficients;
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