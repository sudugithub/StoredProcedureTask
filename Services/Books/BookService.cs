
using Data.Repositories.Books;

namespace Services.Books
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public List<Book> GetByAuthorThenTitle()
        {
            return GetAll()
                 .OrderBy(x => x.AuthorLastName)
                 .ThenBy(x => x.AuthorFirstName)
                 .ThenBy(x => x.Title)
                 .ToList();
        }

        public List<Book> GetByPublisherAuthorThenTitle()
        {
            return GetAll()
                .OrderBy(x => x.Publisher)
                .ThenBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToList();
        }

        public decimal GetTotalPrice()
        {
            return _bookRepository.GetTotalPrice();
        }
    }
}
