using System.Data.Entity;

namespace RegWPF
{
    class ApplicationContex : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContex() : base("DefaultConnection")
        {   
        }
    }
}
