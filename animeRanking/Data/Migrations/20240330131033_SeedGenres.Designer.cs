﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using animeRanking.Data;

#nullable disable

namespace animeRanking.Data.Migrations
{
    [DbContext(typeof(AnimeContext))]
    [Migration("20240330131033_SeedGenres")]
    partial class SeedGenres
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("animeRanking.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Ranking")
                        .HasColumnType("TEXT");

                    b.Property<string>("Season")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenreID");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("animeRanking.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("animeRanking.Anime", b =>
                {
                    b.HasOne("animeRanking.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
