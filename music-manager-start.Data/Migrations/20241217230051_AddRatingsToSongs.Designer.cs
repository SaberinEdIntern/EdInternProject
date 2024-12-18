﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using music_manager_starter.Data;

#nullable disable

namespace music_manager_starter.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20241217230051_AddRatingsToSongs")]
    partial class AddRatingsToSongs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("music_manager_starter.Data.Models.RatingEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte>("OneToFive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SongId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("RatingEvents");
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                            Album = "Spiritbox",
                            Artist = "Spiritbox",
                            Genre = "Metal",
                            Title = "Circle With Me"
                        },
                        new
                        {
                            Id = new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                            Album = "Canyon",
                            Artist = "Pony Bradshaw",
                            Genre = "Folk",
                            Title = "Notes on a River Town"
                        },
                        new
                        {
                            Id = new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                            Album = "Single",
                            Artist = "Morgan Allen",
                            Genre = "Country",
                            Title = "Flower Shops"
                        },
                        new
                        {
                            Id = new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                            Album = "I Love You.",
                            Artist = "The Neighbourhood",
                            Genre = "Alternative",
                            Title = "Sweater Weather"
                        },
                        new
                        {
                            Id = new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                            Album = "When We All Fall Asleep, Where Do We Go?",
                            Artist = "Billie Eilish",
                            Genre = "Pop",
                            Title = "When the Party's Over"
                        },
                        new
                        {
                            Id = new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                            Album = "The Great Escape",
                            Artist = "French Cassettes",
                            Genre = "Indie",
                            Title = "Utah"
                        },
                        new
                        {
                            Id = new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                            Album = "Twelve Carat Toothache",
                            Artist = "Post Malone",
                            Genre = "Hip Hop",
                            Title = "Something Real"
                        });
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.RatingEvent", b =>
                {
                    b.HasOne("music_manager_starter.Data.Models.Song", null)
                        .WithMany("Ratings")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Song", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
