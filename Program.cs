using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkIssue4940
{
    public class Program
    {
        private readonly Context _db;

        public Program(Context db)
        {
            _db = db;
        }

        public void Run()
        {
            _db.Add(new StringValue() { Value = "a string", Created = DateTime.UtcNow });
            _db.Add(new IntegerValue() { Value = 1337, Created = DateTime.UtcNow });
            _db.SaveChanges();

            var works = _db.Values
                .FromSql("SELECT * FROM issue4940.ValueFunction(@p0, @p1)", false, DateTime.UtcNow)
                .Where(x => x is StringValue || x is IntegerValue)
                .ToList();

            var throws = _db.Values
                .FromSql("SELECT * FROM issue4940.ValueFunction(@p0, @p1)", false, DateTime.UtcNow)
                .ToList();
        }

        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddLogging()
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Context>();

            var provider = services.BuildServiceProvider();

            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddConsole(LogLevel.Information);

            var program = ActivatorUtilities.CreateInstance<Program>(provider);
            program.Run();
        }
    }
}
