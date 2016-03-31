using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkIssue4940
{
    public class Context : DbContext
    {
        public DbSet<Value> Values { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=XXXXXX;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("issue4940");

            modelBuilder.Entity<Value>().HasDiscriminator(x => x.Discriminator)
                .HasValue<StringValue>(ValueDiscriminator.String)
                .HasValue<IntegerValue>(ValueDiscriminator.Integer);

            modelBuilder.Entity<StringValue>().Property(x => x.Value).HasColumnName("String_Value");
            modelBuilder.Entity<IntegerValue>().Property(x => x.Value).HasColumnName("Integer_Value");
        }
    }
}
