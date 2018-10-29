using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.DAL
{
    public partial class MailSystemContext : DbContext
    {
        private readonly string _connectionString;
        public MailSystemContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public virtual DbSet<Letter> Letter { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Letter>(entity =>
            {

                entity.Property(e => e.Id).IsRequired().UseSqlServerIdentityColumn();
                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.LetterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LetterTheme).HasMaxLength(100);

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.LetterReciever)
                    .HasForeignKey(d => d.RecieverId)
                    .HasConstraintName("FK__Letter__Reciever__267ABA7A");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.LetterSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK__Letter__SenderId__25869641");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
