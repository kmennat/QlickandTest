using Microsoft.EntityFrameworkCore;
using QlickAndTestApi;
using QlickAndTestApi.BusinessObjects;


namespace QlickAndTestApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<IdentityPhoto> IdentityPhoto { get; set; }

        public DbSet<Identity> Identity { get; set; }



    }
}
