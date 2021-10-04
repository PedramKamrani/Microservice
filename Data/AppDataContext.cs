using Microsoft.EntityFrameworkCore;
using platformService.Models;

namespace platformService.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> opt) : base(opt)
        {

        }


        public DbSet<Platform> platforms{get;set;}
    }
}