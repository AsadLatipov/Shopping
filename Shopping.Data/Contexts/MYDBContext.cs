using Microsoft.EntityFrameworkCore;

namespace Shopping.Data.Contexts
{
    public class MYDBContext : DbContext
    {
        public MYDBContext(DbContextOptions<MYDBContext> options)
            : base(options)
        {
        }
    }
}
