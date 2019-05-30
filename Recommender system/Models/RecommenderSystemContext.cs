using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Recommender_system.Models.Repositories
{
    public class RecommenderSystemContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<PassingPoints> PassingPoints { get; set; }
        public DbSet<University> Universities { get; set; }
        
        
        public RecommenderSystemContext(DbContextOptions options) : base(options)
        {
        }

    }
}