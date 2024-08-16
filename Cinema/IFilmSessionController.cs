public interface IFilmSessionController
{
    int GetPrice(Point pos);
    void LockPlace(Point pos);
    void UnlockPlace(Point pos);
}