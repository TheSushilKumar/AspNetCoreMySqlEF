using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetMySqlEF.Models;

namespace AspNetMySqlEF.Data
{
    public partial class MySQLDatabaseContext : DbContext
    {        
        public MySQLDatabaseContext(DbContextOptions<MySQLDatabaseContext> options) : base(options) { }

        public virtual DbSet<Student> Student { get; set; }

        public DbQuery<MultipleTablesJoinedData> MultipleTablesJoinedData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RollNumber).HasColumnType("int(11)");
            });
        }
    }
}
