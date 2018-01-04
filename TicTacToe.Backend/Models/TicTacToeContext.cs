using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TicTacToe.Backend.Models
{
    public partial class TicTacToeContext : DbContext
    {
        public virtual DbSet<TblGame> TblGame { get; set; }
        public virtual DbSet<TblMove> TblMove { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGame>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("tblGame");
            });

            modelBuilder.Entity<TblMove>(entity =>
            {
                entity.HasKey(e => e.MoveId);

                entity.ToTable("tblMove");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.TblMove)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_tblMove_tblGame");
            });
        }
    }
}
