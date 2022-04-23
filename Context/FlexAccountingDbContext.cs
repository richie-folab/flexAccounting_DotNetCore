using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FlexAccounting.Models;

namespace FlexAccounting.Context
{
    public partial class FlexAccountingDbContext : DbContext
    {
        public FlexAccountingDbContext()
        {
        }

        public FlexAccountingDbContext(DbContextOptions<FlexAccountingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<TranCode> TranCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasIndex(e => e.Name, "AK_Name")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVE')");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasIndex(e => e.HeaderId, "Entries_FKIndex1");

                entity.HasIndex(e => e.TranCode, "Entries_FKIndex2");

                entity.Property(e => e.AccountingId)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AcctNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DrCr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IncludeIf)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TranCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Header)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.HeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entries__HeaderI__18EBB532");

                entity.HasOne(d => d.TranCodeNavigation)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.TranCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entries__TranCod__19DFD96B");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId, "Header_FKIndex1");

                entity.Property(e => e.AccountingId)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CoreBankingRef)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Narration)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Headers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Headers__Applica__151B244E");
            });

            modelBuilder.Entity<TranCode>(entity =>
            {
                entity.HasKey(e => e.TranCode1)
                    .HasName("PK__TranCode__D9937B36431386B5");

                entity.Property(e => e.TranCode1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TranCode");

                entity.Property(e => e.CoreBankingRvslTc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CoreBankingRvslTC");

                entity.Property(e => e.CoreBankingTc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CoreBankingTC");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
