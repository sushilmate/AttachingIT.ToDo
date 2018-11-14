using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AttachingITToDo.WebUI.Models
{
    public partial class CUSERSSUSHILSOURCEREPOSATTACHINGITTODOATTACHINGITTODOPERSISTENCEDATABASEATTACHINGITDBMDFContext : DbContext
    {
        public CUSERSSUSHILSOURCEREPOSATTACHINGITTODOATTACHINGITTODOPERSISTENCEDATABASEATTACHINGITDBMDFContext()
        {
        }

        public CUSERSSUSHILSOURCEREPOSATTACHINGITTODOATTACHINGITTODOPERSISTENCEDATABASEATTACHINGITDBMDFContext(DbContextOptions<CUSERSSUSHILSOURCEREPOSATTACHINGITTODOATTACHINGITTODOPERSISTENCEDATABASEATTACHINGITDBMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sushil\\source\\repos\\AttachingIT.ToDo\\AttachingITToDo.Persistence\\Database\\AttachingITDb.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

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
