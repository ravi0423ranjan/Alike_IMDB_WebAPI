﻿// <auto-generated />
using System;
using IMDB.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMDB.Migrations
{
    [DbContext(typeof(IMDB_DbContext))]
    partial class IMDB_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IMDB.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Actor_DOB")
                        .HasColumnType("datetime2");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            ActorGender = "Male",
                            ActorName = "VBN",
                            Actor_DOB = new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ActorId = 2,
                            ActorGender = "Female",
                            ActorName = "SDF",
                            Actor_DOB = new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IMDB.Models.ActorMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorMovies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            ActorId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            ActorId = 2
                        });
                });

            modelBuilder.Entity("IMDB.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Movie_ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            MovieName = "BJKM",
                            Movie_ReleaseDate = new DateTime(2021, 9, 11, 6, 38, 21, 303, DateTimeKind.Local).AddTicks(6185),
                            ProducerId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            MovieName = "YUIO",
                            Movie_ReleaseDate = new DateTime(2020, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProducerId = 2
                        });
                });

            modelBuilder.Entity("IMDB.Models.Producer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProducerGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer_CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Producer_DOB")
                        .HasColumnType("datetime2");

                    b.HasKey("ProducerId");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            ProducerId = 1,
                            ProducerGender = "Male",
                            ProducerName = "Sam",
                            Producer_CompanyName = "DF Productions",
                            Producer_DOB = new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProducerId = 2,
                            ProducerGender = "Female",
                            ProducerName = "Jennifer",
                            Producer_CompanyName = "KL Productions",
                            Producer_DOB = new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IMDB.Models.ActorMovie", b =>
                {
                    b.HasOne("IMDB.Models.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMDB.Models.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("IMDB.Models.Movie", b =>
                {
                    b.HasOne("IMDB.Models.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("IMDB.Models.Actor", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("IMDB.Models.Movie", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("IMDB.Models.Producer", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
