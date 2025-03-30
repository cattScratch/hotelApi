using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using hotelApi.Entities;

namespace hotelApi.Context;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barangay> Barangays { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=hotelDb;user=root;password=1234;sslmode=Required;allow user variables=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Barangay>(entity =>
        {
            entity.HasKey(e => e.BarangayId).HasName("PRIMARY");

            entity.ToTable("Barangay");

            entity.HasIndex(e => e.CityId, "Barangay_City_FK");

            entity.Property(e => e.BarangayName).HasMaxLength(100);
            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.PostalCode).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Barangays)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("Barangay_City_FK");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("City");

            entity.HasIndex(e => e.StateId, "City_State_FK");

            entity.Property(e => e.CityCode).HasMaxLength(100);
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.StateId).HasColumnName("stateId");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("City_State_FK");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("Country");

            entity.Property(e => e.CountryCode).HasMaxLength(100);
            entity.Property(e => e.CountryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PRIMARY");

            entity.ToTable("Hotel");

            entity.HasIndex(e => e.BarangayId, "Hotel_Barangay_FK");

            entity.Property(e => e.BarangayId).HasColumnName("barangayId");
            entity.Property(e => e.HotelCode).HasMaxLength(100);
            entity.Property(e => e.HotelDescription).HasMaxLength(100);
            entity.Property(e => e.HotelName).HasMaxLength(100);

            entity.HasOne(d => d.Barangay).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.BarangayId)
                .HasConstraintName("Hotel_Barangay_FK");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");

            entity.ToTable("State");

            entity.HasIndex(e => e.CountryId, "State_Country_FK");

            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.StateCode).HasMaxLength(100);
            entity.Property(e => e.StateName).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("State_Country_FK");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.HotelId, "Transaction_Hotel_FK");

            entity.Property(e => e.TransactionId).HasColumnName("transactionId");
            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("dateFrom");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("dateTo");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .HasColumnName("emailAddress");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.HotelCode)
                .HasMaxLength(100)
                .HasColumnName("hotelCode");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .HasColumnName("hotelName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phoneNumber");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("Transaction_Hotel_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
