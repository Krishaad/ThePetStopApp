using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThePetStop.Models;

namespace ThePetStop.Data
{
    public class ThePetStopContext : DbContext
    {
        public ThePetStopContext (DbContextOptions<ThePetStopContext> options)
            : base(options)
        {
        }

        public DbSet<ThePetStop.Models.Dog> Dog { get; set; } = default!;
        public DbSet<ThePetStop.Models.Cat> Cat { get; set; } = default!;
    }
}
