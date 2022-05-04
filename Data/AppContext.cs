using Microsoft.EntityFrameworkCore;
using Poke.Models;

namespace Poke.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<PokeM> PokesM { get; set; }
        public DbSet<TrainerM> TrainersM { get; set; }

    }
}
