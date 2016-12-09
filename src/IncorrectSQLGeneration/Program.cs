using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncorrectSQLGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = ":memory:"
            };
            string connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
            //Issue appears when generating SQL for SQLite
            builder.UseSqlite(connection);
            //Issue appears when generating SQL for SQL Server
            //builder.UseSqlServer("Data Source=localhost;Initial Catalog=EFCoreBroke;Integrated Security=true;");

            //Issue is not a problem with an in-memory database
            //builder.UseInMemoryDatabase();

            var log = new Microsoft.Extensions.Logging.LoggerFactory();
            log.AddConsole(LogLevel.Debug);
            log.AddDebug();
            builder.UseLoggerFactory(log);

            using (var context = new DataContext(builder.Options))
            {
                context.Database.EnsureCreated();

                IQueryable<Quote> quotes =
                    context.Quotes
                    .Include(q => q.Book).ThenInclude(b => b.MysteryBook);

                //Commenting out filter on navigation property causes SQL to be generated correctly
                quotes = quotes.Where(q => q.Book.MysteryBook.Hero == "Sherlock");
                quotes = quotes.OrderBy(q => q.ID);
                //Commenting out Skip/Take causes SQL to be generated correctly
                quotes = quotes.Skip(0).Take(10);

                var authorIDs = quotes.Select(q => q.AuthorID).ToList();

                foreach(var id in authorIDs)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
