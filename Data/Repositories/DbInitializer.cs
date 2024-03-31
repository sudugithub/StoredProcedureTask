namespace Data.Repositories
{
    public interface IDbInitializer
    {
        void Initialize();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly Repository _repository;
        public DbInitializer(Repository repository)
        {
            _repository = repository;
        }
        public void Initialize()
        {
            if (!_repository.Books.Any())
            {
                _repository.Books.AddRange(new Book
                {
                    AuthorLastName = "Barzun",
                    AuthorFirstName = "Jacques",
                    Title = "Behind the blue pencil: Censorship or Creeping Creativity?",
                    ContainerTitle = "On Writing, Editing and Publishing",
                    Publisher = "U of Chicago P",
                    PublicationYear = 1986,
                    PageStartNumber = 120,
                    PageEndNumber = 126,
                    Price = 1400
                },
                new Book
                {
                    AuthorFirstName = "Jhon",
                    AuthorLastName = "Schmidt",
                    PublicationYear = 1935,
                    Title = "Mystry of Talking Wombat",
                    ContainerTitle = "Bulletin of the llinois Society for Psychical research 217",
                    VolumeNumber = 2,
                    PublicationMonth = "February",
                    PageStartNumber = 275,
                    PageEndNumber = 278,
                    URL = "https://example.com",
                    Price = 1200
                },
                 new Book
                 {
                     AuthorLastName = "Aarzun",
                     AuthorFirstName = "Jacques",
                     Title = "Behind the blue pencil: Censorship or Creeping Creativity?",
                     ContainerTitle = "On Writing, Editing and Publishing",
                     Publisher = "U of Chicago P",
                     PublicationYear = 1986,
                     PageStartNumber = 120,
                     PageEndNumber = 126,
                     Price = 1400
                 },
                  new Book
                  {
                      AuthorLastName = "Aarzun",
                      AuthorFirstName = "Mathew",
                      Title = "Behind the blue pencil: Censorship or Creeping Creativity?",
                      ContainerTitle = "On Writing, Editing and Publishing",
                      Publisher = "U of Chicago P",
                      PublicationYear = 1986,
                      PageStartNumber = 120,
                      PageEndNumber = 126,
                      Price = 1400
                  },
                   new Book
                   {
                       AuthorLastName = "Aarzun",
                       AuthorFirstName = "Mathew",
                       Title = "Red pencil: Censorship or Creeping Creativity?",
                       ContainerTitle = "On Writing, Editing and Publishing",
                       Publisher = "U of Chicago P",
                       PublicationYear = 1986,
                       PageStartNumber = 120,
                       PageEndNumber = 126,
                       Price = 1400
                   });

                _repository.SaveChanges();
            }
        }
    }
}
