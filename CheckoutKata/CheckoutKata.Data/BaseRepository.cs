namespace CheckoutKata.Data
{
    public class BaseRepository
    {
        protected readonly CheckoutKataContext _db;

        protected BaseRepository(CheckoutKataContext db)
        {
            _db = db;
        }
    }
}