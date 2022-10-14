namespace Week_3.Services
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<User> users { get; set; }
    }
}
