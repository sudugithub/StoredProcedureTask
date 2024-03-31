namespace Data.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        decimal GetTotalPrice();
    }
}
