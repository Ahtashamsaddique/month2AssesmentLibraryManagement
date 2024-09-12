using LibraryManangementSys.ApplicationDBContextFolder;
using LibraryManangementSys.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryManangementSys.Repository
{
    public class BooksRepositoryTests
    {
        private readonly BooksRepository _repository;
        private readonly ApplicationDBContext _applicationDBContext;

        public BooksRepositoryTests(BooksRepository repository, ApplicationDBContext applicationDBContext)
        {
            _repository = repository;
            _applicationDBContext = applicationDBContext;
        }
        public BooksRepositoryTests()
            {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseInMemoryDatabase(databaseName: "libraryManagement").Options;
            _applicationDBContext=new ApplicationDBContext(options);
            _repository = new BooksRepository(_applicationDBContext);
        }
        [Fact]
        public async Task AddBook_ShouldAddBookToDatabase()
        {
            var book = new BookEntity { Id=1,Title="Test book",Author="Test Author",ISBN="2312456"};
            await _repository.AddBook(book);
            var savebook=await _applicationDBContext.Books.FindAsync(book.Id);
            Assert.NotNull(savebook);
            Assert.Equal("Test Book", savebook.Title);
        }
    }
}
