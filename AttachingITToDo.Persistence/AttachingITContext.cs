using AttachingITToDo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace AttachingITToDo.Persistence
{
    public partial class AttachingITContext : DbContext
    {
        public AttachingITContext()
        {
        }

        public AttachingITContext(DbContextOptions<AttachingITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDo { get; set; }

        public static string MDF_Directory
        {
            get
            {
                var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.GetFullPath(Path.Combine(directoryPath, "Database"));
            }
        }

        public string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
                                         "AttachDbFilename=" + MDF_Directory + "\\AttachingITDb.mdf;" +
                                         " Integrated Security=True; Connect Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        /// <summary>
        /// Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sushil\source\repos\Exercise1\AttachingITToDo.Persistence\Database\AttachingITDb.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}