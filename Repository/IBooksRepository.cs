using LibraryManangementSys.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace LibraryManangementSys.Repository
{
    public interface IBooksRepository
    {
        Task<BookEntity> AddBook(BookEntity book);
        Task<IEnumerable<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookByID(int id);
        Task GetBookDetailsPatchRequest(int id, JsonPatchDocument patchDocument);
    }
}
