using Cinema;

public class FilmSessionController : IFilmSessionController
{
    IFilmSessionStorage sessionStorage;
    // Тут можно поменять политику ценообразования.
    // PricePolicy pricePolicy = new CenterPricePolicy();
    PricePolicy pricePolicy;
    FilmSession fs;

    public FilmSessionController(FilmSession fs, IFilmSessionStorage storage, PricePolicy pp)
    {
        this.sessionStorage = storage;
        this.fs = fs;
        this.pricePolicy = pp;
    }

    public string GetFilmName()
    {
        return fs.GetFilmName();
    }

    public int GetPrice(Point pos)
    {
        return pricePolicy.CalculatePrice(fs.GetMinPrice(), pos, fs.GetHall());
    }

    public int GetRevenue()
    { 
        return fs.getRevenue();
    }

    public void LockPlace(Point pos)
    {
        sessionStorage.LockPlace(fs.Id, pos);
        fs.AddRevenue(GetPrice(pos));
    }

    public void UnlockPlace(Point pos)
    {
        sessionStorage.UnlockPlace(fs.Id, pos);
        fs.AddRevenue(-GetPrice(pos));
    }

    public bool IsPlaced(Point pos) 
    {
        return sessionStorage.IsPlaced(fs.Id, pos);
    }

    public int Width()
    { 
        return sessionStorage.GetHallWidth(fs.Id);
    }

    public int Height() 
    {
        return sessionStorage.GetHallHeight(fs.Id);
    }

    internal DateTime GetSessionDate()
    {
        return fs.GetSessionDate();
    }

    public  Hall GetHall()
    {
        return fs.GetHall();
    }

    public override bool Equals(object? obj)
    {
        return obj != null && obj is FilmSessionController && ((FilmSessionController)obj).GetId() == GetId();
    }

    public int GetId()
    {
        return fs.Id;
    }

    internal TimeSpan GetDuration()
    {
        return fs.Duration;
    }
}
