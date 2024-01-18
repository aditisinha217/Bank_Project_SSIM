using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankProjectSSMS.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AditiSbAccount> AditiSbAccounts { get; set; }

    public virtual DbSet<AditiSbTransaction> AditiSbTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AditiSbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__AditiSbA__BE2ACD6ED6695FE1");

            entity.ToTable("AditiSbAccount");

            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AditiSbTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__AditiSbT__55433A6BFD81E18E");

            entity.ToTable("AditiSbTransaction");

            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.AditiSbTransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__AditiSbTr__Accou__6D6238AF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
