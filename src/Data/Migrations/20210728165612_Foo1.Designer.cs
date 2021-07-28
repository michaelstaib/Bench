﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars;

namespace Data.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    [Migration("20210728165612_Foo1")]
    partial class Foo1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeopleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmsId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("FilmPerson");
                });

            modelBuilder.Entity("FilmProducer", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProducersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmsId", "ProducersId");

                    b.HasIndex("ProducersId");

                    b.ToTable("FilmProducer");
                });

            modelBuilder.Entity("StarWars.Climate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PlanetId");

                    b.ToTable("Climates");
                });

            modelBuilder.Entity("StarWars.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("StarWars.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("TEXT");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("EpisodeId")
                        .IsUnique();

                    b.HasIndex("PlanetId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Films");
                });

            modelBuilder.Entity("StarWars.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthYear")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("TEXT");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HomeworldId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Mass")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("SkinColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HomeworldId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SpeciesId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("StarWars.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Diameter")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gravity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrbitalPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Population")
                        .HasColumnType("REAL");

                    b.Property<int?>("RotationPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("SurfaceWater")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("StarWars.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("StarWars.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("StarWars.Terrain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PlanetId");

                    b.ToTable("Terrains");
                });

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.HasOne("StarWars.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmProducer", b =>
                {
                    b.HasOne("StarWars.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Producer", null)
                        .WithMany()
                        .HasForeignKey("ProducersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWars.Climate", b =>
                {
                    b.HasOne("StarWars.Planet", null)
                        .WithMany("Climates")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("StarWars.Film", b =>
                {
                    b.HasOne("StarWars.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Planet", null)
                        .WithMany("Films")
                        .HasForeignKey("PlanetId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("StarWars.Person", b =>
                {
                    b.HasOne("StarWars.Planet", "Homeworld")
                        .WithMany("Residents")
                        .HasForeignKey("HomeworldId");

                    b.HasOne("StarWars.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId");

                    b.Navigation("Homeworld");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("StarWars.Terrain", b =>
                {
                    b.HasOne("StarWars.Planet", null)
                        .WithMany("Terrains")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("StarWars.Planet", b =>
                {
                    b.Navigation("Climates");

                    b.Navigation("Films");

                    b.Navigation("Residents");

                    b.Navigation("Terrains");
                });
#pragma warning restore 612, 618
        }
    }
}
