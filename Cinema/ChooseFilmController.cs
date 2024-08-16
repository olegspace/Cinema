using CinemaApp;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class ChooseFilmController
    {
        private List<Hall> halls = new List<Hall>();
        private List<FilmSession> filmsSessions = new List<FilmSession>();
        private List<FilmSessionController> filmSessionControllers = new List<FilmSessionController>();

        // В этом месте можно перенастроить режим хранения сеансов.
        //private IFilmSessionStorage storage = new InMemoryFilmSessionStorage();
        private IFilmSessionStorage storage = new FileFilmSessionStorage();
        private FilmStorage filmStoarge = new FilmStorage();
        public ChooseFilmController()
        {
            halls.Add(new Hall(15, 15, "hall 1"));
            halls.Add(new Hall(10, 10, "hall 2"));

            foreach (FilmSession fs in storage.GetFilmSessions())
            {
                filmSessionControllers.Add(new FilmSessionController(fs, storage, fs.pricePolicy));
            }
        }

        public List<FilmSessionController> GetFilmSessionControllers()
        {
            return filmSessionControllers;
        }

        public List<Hall> GetHalls()
        {
            return halls;
        }

        public void AddFilmSession(FilmSession f)
        {
            filmsSessions.Add(f);
            filmSessionControllers.Add(new FilmSessionController(f, storage, f.pricePolicy));
            storage.Add(f);
        }

        public Hall GetHallByName(string hallName)
        {
            foreach (Hall h in halls)
            {
                if (h.Name.Equals(hallName))
                {
                    return h;
                }
            }

            throw new ApplicationException("Ошибка при работе приложения. Заданный зал для просмотра фильмов не найден или не существует.");
        }

        public FilmSessionController FindFilmSessionController(string? movieName, DateTime dateTime, string? hallNumber)
        {
            foreach (FilmSessionController f in filmSessionControllers)
            {
                var date1 = f.GetSessionDate();

                if (f.GetFilmName().Equals(movieName) &&
                    CompareDateTime(dateTime, date1)  &&
                    f.GetHall().Name == hallNumber)
                {
                    return f;
                }
            }

            throw new ApplicationException("Ошибка приложения при попытке обращения к контроллеру кинопоказа. Сущность не найдена или не существует.");
        }

        private bool CompareDateTime(DateTime d1, DateTime d2)
        {
            return d1.Day == d2.Day && d1.Month == d2.Month && d1.Year == d2.Year && d1.Hour == d2.Hour && d1.Minute == d2.Minute;
        }
        public List<FilmSession> GetFilmSessions()
        {
            return storage.GetFilmSessions();
        }

        internal void RemoveFilmSession(int fsId)
        {
            filmSessionControllers = filmSessionControllers.Where(fsc => fsc.GetId() != fsId).ToList();
            storage.Remove(fsId);
        }

        internal Film FindFilm(string movieName)
        {
            foreach (var f in filmStoarge.GetFilms())
            {
                if (f.name == movieName)
                {
                    return f;
                }
            }

            return null;
        }

        internal IList<Film> GetAllFilms()
        {
            return filmStoarge.GetFilms();
        }

        internal void RemoveFilm(string name)
        {
            foreach (var fs in storage.GetFilmSessions())
            {
                if (fs.FilmName == name)
                {
                    var res = MessageBox.Show("В таблице с показами присутствует этот фильм. Удалить каскадно показы с этим фильмом?", "каскадное удаление показов", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var fss = storage.GetFilmSessions();
                        foreach (var f in fss)
                        {
                            if (f.FilmName == name)
                            {
                                storage.Remove(f.Id);
                            }
                        }

                        filmStoarge.Remove(name);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            filmStoarge.Remove(name);
        }

        internal void AddFilm(string name, TimeSpan duration)
        {
            filmStoarge.Add(new Film(name, duration));
        }
    }
}
