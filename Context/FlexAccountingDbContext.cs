using Microsoft.EntityFrameworkCore;

namespace FlexAccounting.Context
{
    public class FlexAccountingDbContext : DbContext
    {
        public FlexAccountingDbContext(DbContextOptions<FlexAccountingDbContext> options):base(options)
        {
                
        }
    }
}
