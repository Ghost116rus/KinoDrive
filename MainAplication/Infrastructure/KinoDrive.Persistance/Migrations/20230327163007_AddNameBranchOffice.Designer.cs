﻿// <auto-generated />
using System;
using KinoDrive.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    [DbContext(typeof(KinoDriveDbContext))]
    [Migration("20230327163007_AddNameBranchOffice")]
    partial class AddNameBranchOffice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("ActorsId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("ActorFilm");
                });

            modelBuilder.Entity("FilmFilmDirector", b =>
                {
                    b.Property<int>("FilmDirectorsId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("FilmDirectorsId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("FilmFilmDirector");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("FilmGenre");
                });

            modelBuilder.Entity("KinoDrive.Domain.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("KinoDrive.Domain.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlaceNumber")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeanceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SeanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("KinoDrive.Domain.BranchOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BranchOffices");
                });

            modelBuilder.Entity("KinoDrive.Domain.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("NumOfPlacesInRow")
                        .HasColumnType("int");

                    b.Property<int>("NumOfRow")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OfficeId", "Name")
                        .IsUnique();

                    b.ToTable("CinemaHalls");
                });

            modelBuilder.Entity("KinoDrive.Domain.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchOfficeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchOfficeId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("KinoDrive.Domain.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("RatingOnImdb")
                        .HasColumnType("int");

                    b.Property<float>("RatingOnKinopoisk")
                        .HasColumnType("real");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Films");

                    b.HasCheckConstraint("ReleaseYear", "ReleaseYear LIKE '[1,2][0,8,9][0-9][0-9]'");
                });

            modelBuilder.Entity("KinoDrive.Domain.FilmDirector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BornCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmDirectors");
                });

            modelBuilder.Entity("KinoDrive.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("KinoDrive.Domain.Review", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("UserId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("KinoDrive.Domain.Seance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BasicCost")
                        .HasColumnType("int");

                    b.Property<int>("CinemaHallId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SeanceStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaHallId");

                    b.HasIndex("FilmId");

                    b.HasIndex("Id");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("KinoDrive.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.HasOne("KinoDrive.Domain.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmFilmDirector", b =>
                {
                    b.HasOne("KinoDrive.Domain.FilmDirector", null)
                        .WithMany()
                        .HasForeignKey("FilmDirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.HasOne("KinoDrive.Domain.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinoDrive.Domain.Booking", b =>
                {
                    b.HasOne("KinoDrive.Domain.Seance", "Seance")
                        .WithMany("Bookings")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KinoDrive.Domain.CinemaHall", b =>
                {
                    b.HasOne("KinoDrive.Domain.BranchOffice", "Office")
                        .WithMany("CinemaHalls")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("KinoDrive.Domain.Complaint", b =>
                {
                    b.HasOne("KinoDrive.Domain.BranchOffice", "BranchOffice")
                        .WithMany("Complaintes")
                        .HasForeignKey("BranchOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.User", "User")
                        .WithMany("Complaintes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchOffice");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KinoDrive.Domain.Review", b =>
                {
                    b.HasOne("KinoDrive.Domain.Film", "Film")
                        .WithMany("Reviews")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KinoDrive.Domain.Seance", b =>
                {
                    b.HasOne("KinoDrive.Domain.CinemaHall", "CinemaHall")
                        .WithMany("Seances")
                        .HasForeignKey("CinemaHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinoDrive.Domain.Film", "Film")
                        .WithMany("Seances")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("KinoDrive.Domain.BranchOffice", b =>
                {
                    b.Navigation("CinemaHalls");

                    b.Navigation("Complaintes");
                });

            modelBuilder.Entity("KinoDrive.Domain.CinemaHall", b =>
                {
                    b.Navigation("Seances");
                });

            modelBuilder.Entity("KinoDrive.Domain.Film", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Seances");
                });

            modelBuilder.Entity("KinoDrive.Domain.Seance", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("KinoDrive.Domain.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Complaintes");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}