using Futebol.Models;
using Microsoft.EntityFrameworkCore;

namespace Futebol.Data
{
    public class FutebolContext : DbContext
    {
        public FutebolContext(DbContextOptions<FutebolContext> options) : base(options)
        {            
        }
        public DbSet<CampeonatoModel> Campeonato { get; set; }
        public DbSet<TimeModel> Time { get; set; }
    }
}
