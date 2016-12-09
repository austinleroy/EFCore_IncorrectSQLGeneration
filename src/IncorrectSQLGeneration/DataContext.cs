using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncorrectSQLGeneration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> builder)
            :base(builder)
        { }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MysteryBook> Publishers { get; set; }
    }
}
