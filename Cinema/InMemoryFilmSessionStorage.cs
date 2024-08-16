
namespace Cinema
{
    public class InMemoryFilmSessionStorage : IFilmSessionStorage
    {
        private Dictionary<int, FilmSession> sessions = new Dictionary<int, FilmSession>();
        private string filePath = "filmsessions.json";


        public List<FilmSession> GetFilmSessions()
        {
            return sessions.Values.ToList();
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
            return sessions.GetValueOrDefault(sessionId).GetHall().IsPlaced(pos);
        }

        public void LockPlace(int sessionId, Point pos)
        {
            sessions.GetValueOrDefault(sessionId).GetHall().LockPlace(pos);
        }

        public void UnlockPlace(int sessionId, Point pos)
        {
            sessions.GetValueOrDefault(sessionId).GetHall().UnlockPlace(pos);
        }

        public void Add(FilmSession f)
        {
            sessions.Add(f.Id, f);
        }

        public void Remove(int fsId)
        {
            sessions.Remove(fsId);
        }
    }
}
