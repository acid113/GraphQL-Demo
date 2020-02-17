using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class CustomDataProfileDBContext : DbContext
    {
        public CustomDataProfileDBContext()
        {
            
        }

        public CustomDataProfileDBContext(DbContextOptions<CustomDataProfileDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalystNote> AnalystNote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalystNote>(entity =>
            {
                entity.Property(e => e.AnalystNotesHistoryID).HasColumnName("AnalystNotesHistoryID")
                    .IsRequired();
                entity.Property(e => e.FileLogID).HasColumnName("FileLogID")
                    .IsRequired();
                entity.Property(e => e.FileTrackingID).HasColumnName("FileTrackingID")
                    .IsRequired();
                entity.Property(e => e.ClientID).HasColumnName("ClientID");
                entity.Property(e => e.ClientEligibilityFilename).HasColumnName("ClientEligibilityFilename");
                entity.Property(e => e.SystemAssignedFilename).HasColumnName("SystemAssignedFilename");
                entity.Property(e => e.DateLastProcessed).HasColumnName("DateLastProcessed");
                entity.Property(e => e.InvalidRecords).HasColumnName("InvalidRecords")
                    .IsRequired();
                entity.Property(e => e.ValidRecords).HasColumnName("ValidRecords")
                    .IsRequired();
                entity.Property(e => e.BeingWorkedBy).HasColumnName("BeingWorkedBy");
                entity.Property(e => e.IsCompleted).HasColumnName("IsCompleted");
                entity.Property(e => e.AnalystNotes).HasColumnName("AnalystNotes");
                entity.Property(e => e.Analyst).HasColumnName("Analyst");
                entity.Property(e => e.AnalystNotesTimestamp).HasColumnName("AnalystNotesTimestamp")
                    .IsRequired();
            }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
