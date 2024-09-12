using LibraryManangementSys.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManangementSys.ApplicationDBContextFolder
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        
        public DbSet<BookEntity> Books { get; set; }
    }
}
