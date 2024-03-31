
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Books
{
    public class BookRepository(Repository repository) : IBookRepository
    {
        private readonly Repository _repository = repository;

        public List<Book> GetAll()
        {
           return _repository.Books.FromSql($"spGetAllBooks").ToList();
        }

        public decimal GetTotalPrice()
        {
            return _repository.Books.Sum(x => x.Price);
        }
    }
}
