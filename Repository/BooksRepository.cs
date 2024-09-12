
using LibraryManangementSys.ApplicationDBContextFolder;
using LibraryManangementSys.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LibraryManangementSys.Repository
{
    public class BooksRepository:IBooksRepository
    {
        private readonly IApplicationDBContext _context;

        public BooksRepository(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task GetBookDetailsPatchRequest(int id,JsonPatchDocument patchDocument)
        {
            var book= await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if (book != null)
            {
                patchDocument.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<BookEntity>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
        public async Task<BookEntity> GetBookByID(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }
        public async Task<BookEntity> AddBook(BookEntity book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
