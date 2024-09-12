using LibraryManangementSys.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManangementSys.ApplicationDBContextFolder
{
    public interface IApplicationDBContext
    {
        DbSet<BookEntity> Books { get; set; }

        Task<int> SaveChangesAsync();
    }
}
