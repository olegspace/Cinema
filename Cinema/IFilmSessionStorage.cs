using Cinema;

public interface IFilmSessionStorage
{
    void LockPlace(int sessionId, Point pos);
    void UnlockPlace(int sessionId, Point pos);

    bool IsPlaced(int sessionId, Point pos);

    int GetHallWidth(int sessionId);

    int GetHallHeight(int sessionId);

    List<FilmSession> GetFilmSessions();

    void Add(FilmSession fs);
    void Remove(int fsId);
}
