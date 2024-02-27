﻿// <auto-generated />
using System;
using CookieApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CookieApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CookieApi.Models.Accessory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Benchmark")
                        .HasColumnType("integer")
                        .HasColumnName("benchmark");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uuid")
                        .HasColumnName("rating_id");

                    b.Property<int>("VotesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("votes_count");

                    b.HasKey("Id")
                        .HasName("pk_accessories");

                    b.HasIndex("RatingId")
                        .IsUnique()
                        .HasDatabaseName("ix_accessories_rating_id");

                    b.ToTable("accessories", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Accessory");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CookieApi.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("BenchmarkPlace")
                        .HasColumnType("integer")
                        .HasColumnName("benchmark_place");

                    b.Property<int>("VotesPlace")
                        .HasColumnType("integer")
                        .HasColumnName("votes_place");

                    b.HasKey("Id")
                        .HasName("pk_ratings");

                    b.ToTable("ratings", (string)null);
                });

            modelBuilder.Entity("CookieApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("user")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("baba17a6-d265-418d-8975-936e89ecc752"),
                            Nickname = "defaultUser",
                            PasswordHash = "N88fRfSdIMEsrcOa3iuM4MwqikwH9JzDHQXWfQAPW1BtqdcO+dXpwBTufghVG1Rjy/o4ucJgYsbRdEYT+pvQJz0+BJhSYu2G+Gf3W0UzegMRDMgdOP5C/Of3wKk3F5QYBKJ+4ryKjFN9QsoJzCQpsd+zQqFr0COdGtBqc2TAVzE=",
                            PasswordSalt = "y9ssvBIp643GnKgThlsGyg==",
                            Role = "user"
                        },
                        new
                        {
                            Id = new Guid("6d5815f0-36a4-4a8d-a914-2631cad2b46f"),
                            Nickname = "defaultAdmin",
                            PasswordHash = "HjTeJSbhG88kPT1FXDFFIsNxq17CwRZkrC7kv9iT25xvgN7PKKQea6GRRgk1qCs+cpkmNpYalrWfdOjG/xysEgX9WuqUMM5dW66Fs/DU+edR9WpW+aVrwbFsq7fglsuAlcbvoPyi+wiUp7lhweorDG7juz2VxAE2TdwoIEZ53q0=",
                            PasswordSalt = "GPmPNNV1q0rF7+WkDgPTJQ==",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("CookieApi.Models.Cpu", b =>
                {
                    b.HasBaseType("CookieApi.Models.Accessory");

                    b.Property<int>("CoresCount")
                        .HasColumnType("integer")
                        .HasColumnName("cores_count");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("manufacturer");

                    b.Property<int>("MaximumFrequency")
                        .HasColumnType("integer")
                        .HasColumnName("maximum_frequency");

                    b.Property<int>("MinimumFrequency")
                        .HasColumnType("integer")
                        .HasColumnName("minimum_frequency");

                    b.Property<int>("NanometersCount")
                        .HasColumnType("integer")
                        .HasColumnName("nanometers_count");

                    b.Property<int>("ThreadsCount")
                        .HasColumnType("integer")
                        .HasColumnName("threads_count");

                    b.Property<int>("VideoMemoryCount")
                        .HasColumnType("integer")
                        .HasColumnName("video_memory_count");

                    b.HasDiscriminator().HasValue("Cpu");
                });

            modelBuilder.Entity("CookieApi.Models.Ram", b =>
                {
                    b.HasBaseType("CookieApi.Models.Accessory");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("manufacturer");

                    b.Property<int>("Memory")
                        .HasColumnType("integer")
                        .HasColumnName("memory");

                    b.Property<int>("MemoryFrequency")
                        .HasColumnType("integer")
                        .HasColumnName("memory_frequency");

                    b.Property<string>("Timings")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("timings");

                    b.HasDiscriminator().HasValue("Ram");
                });

            modelBuilder.Entity("CookieApi.Models.Accessory", b =>
                {
                    b.HasOne("CookieApi.Models.Rating", "Rating")
                        .WithOne()
                        .HasForeignKey("CookieApi.Models.Accessory", "RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_accessories_ratings_rating_id");

                    b.Navigation("Rating");
                });
#pragma warning restore 612, 618
        }
    }
}
