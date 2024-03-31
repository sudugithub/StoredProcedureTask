namespace Services.Books
{
    public interface IBookService
    {
        List<Book> GetAll();

        List<Book> GetByPublisherAuthorThenTitle();
        List<Book> GetByAuthorThenTitle();
        decimal GetTotalPrice();
    }
}
