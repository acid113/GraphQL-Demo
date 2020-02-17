using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class DataProfileDBContext : DbContext
    {
        public DataProfileDBContext()
        {
        }

        public DataProfileDBContext(DbContextOptions<DataProfileDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FileLog> FileLog { get; set; }
        public virtual DbSet<FileTracking> FileTracking { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FileLog>(entity =>
            {
                entity.Property(e => e.FileLogId).HasColumnName("FileLogID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateLastProcessed)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OriginalFileName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FileTracking>(entity =>
            {
                entity.Property(e => e.FileTrackingId).HasColumnName("FileTrackingID");

                entity.Property(e => e.AnalystNotesTimestamp).HasColumnType("datetime");

                entity.Property(e => e.AnalystNotesUserName).HasMaxLength(100);

                entity.Property(e => e.AssignedTo).HasMaxLength(100);

                entity.Property(e => e.DataProfileFileNameDirectory).HasMaxLength(100);

                entity.Property(e => e.DataProfileProcessedDatetime).HasColumnType("datetime");

                entity.Property(e => e.DataProfileStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FileLogId).HasColumnName("FileLogID");

                entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");

                entity.Property(e => e.LoaderFileNameDirectory).HasMaxLength(100);

                entity.Property(e => e.LoaderProcessedDatetime).HasColumnType("datetime");

                entity.Property(e => e.LoaderStatus).HasMaxLength(20);

                entity.Property(e => e.PreLoaderFileNameDirectory)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PreLoaderProcessedDatetime).HasColumnType("datetime");

                entity.Property(e => e.PreLoaderStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProcessLogId).HasColumnName("ProcessLogID");

                entity.HasOne(d => d.FileLog)
                    .WithMany(p => p.FileTracking)
                    .HasForeignKey(d => d.FileLogId)
                    .HasConstraintName("FK_FileTracking_FileLog");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => new { e.PrimaryPersonId, e.PersonId, e.FileTrackingId })
                    .HasName("UC_Person")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClientMemberId)
                    .HasColumnName("ClientMemberID")
                    .HasMaxLength(99);

                entity.Property(e => e.FileTrackingId).HasColumnName("FileTrackingID");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PrimaryPersonId).HasColumnName("PrimaryPersonID");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(20);

                entity.Property(e => e.SysEndTime).HasDefaultValueSql("(CONVERT([datetime2],'9999-12-31 23:59:59.9999999'))");

                entity.Property(e => e.SysStartTime).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.FileTracking)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.FileTrackingId)
                    .HasConstraintName("FK_Person_FileTracking");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
