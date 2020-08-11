using DataForSeo.DAL.Entities;
namespace DataForSeo.DAL.EF
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<Data> Data { get; set; }
    }
}
