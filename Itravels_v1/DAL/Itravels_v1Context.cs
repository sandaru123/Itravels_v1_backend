using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Itravels_v1.DAL
{
    public partial class Itravels_v1Context : DbContext
    {
        public Itravels_v1Context()
        {
        }

        public Itravels_v1Context(DbContextOptions<Itravels_v1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Baggage> Baggage { get; set; }
        public virtual DbSet<BoardingPass> BoardingPass { get; set; }
        public virtual DbSet<Inquiry> Inquiry { get; set; }
        public virtual DbSet<InquiryResult> InquiryResult { get; set; }
        public virtual DbSet<InquiryStatuses> InquiryStatuses { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<ThirdPartyContact> ThirdPartyContact { get; set; }
        public virtual DbSet<TravelHistory> TravelHistory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-K4NQ2IO;Initial Catalog=Itravels_v1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baggage>(entity =>
            {
                entity.Property(e => e.Rfid).HasColumnName("RFID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Baggage)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Baggage_User");
            });

            modelBuilder.Entity<BoardingPass>(entity =>
            {
                entity.HasKey(e => e.PassId);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlyingDate).HasColumnType("date");

                entity.Property(e => e.FromCountry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToCountry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BoardingPass)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardingPass_User");
            });

            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Baggage)
                    .WithMany(p => p.Inquiry)
                    .HasForeignKey(d => d.BaggageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inquiry_Baggage");

                entity.HasOne(d => d.InquiryReslut)
                    .WithMany(p => p.Inquiry)
                    .HasForeignKey(d => d.InquiryReslutId)
                    .HasConstraintName("FK_Inquiry_InquiryResult");

                entity.HasOne(d => d.InquiryStatus)
                    .WithMany(p => p.Inquiry)
                    .HasForeignKey(d => d.InquiryStatusId)
                    .HasConstraintName("FK_Inquiry_InquiryStatuses");
            });

            modelBuilder.Entity<InquiryResult>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InquiryStatuses>(entity =>
            {
                entity.HasKey(e => e.InquiryStatusId);

                entity.Property(e => e.InquiryStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LastCheckPoint)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Baggage)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.BaggageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Baggage");
            });

            modelBuilder.Entity<ThirdPartyContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ThirdPartyContact)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThirdPartyContact_User");
            });

            modelBuilder.Entity<TravelHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TravelDate).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TravelHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelHistory_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserRegNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
