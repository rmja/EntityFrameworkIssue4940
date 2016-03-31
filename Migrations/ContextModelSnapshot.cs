using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EntityFrameworkIssue4940;

namespace EntityFrameworkIssue4940.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("Relational:DefaultSchema", "issue4940")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkIssue4940.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("Discriminator");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");
                });

            modelBuilder.Entity("EntityFrameworkIssue4940.IntegerValue", b =>
                {
                    b.HasBaseType("EntityFrameworkIssue4940.Value");

                    b.Property<int>("Value")
                        .HasAnnotation("Relational:ColumnName", "Integer_Value");

                    b.HasAnnotation("Relational:DiscriminatorValue", ValueDiscriminator.Integer);
                });

            modelBuilder.Entity("EntityFrameworkIssue4940.StringValue", b =>
                {
                    b.HasBaseType("EntityFrameworkIssue4940.Value");

                    b.Property<string>("Value")
                        .HasAnnotation("Relational:ColumnName", "String_Value");

                    b.HasAnnotation("Relational:DiscriminatorValue", ValueDiscriminator.String);
                });
        }
    }
}
