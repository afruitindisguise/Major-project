﻿// <auto-generated />
using Major_Project.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Major_project.Migrations
{
    [DbContext(typeof(PlayerDbContext))]
    [Migration("20240424171815_newer")]
    partial class newer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemPlayer", b =>
                {
                    b.Property<int>("itemsId")
                        .HasColumnType("int");

                    b.Property<int>("playersId")
                        .HasColumnType("int");

                    b.HasKey("itemsId", "playersId");

                    b.HasIndex("playersId");

                    b.ToTable("ItemPlayer");
                });

            modelBuilder.Entity("Major_Project.models.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AR")
                        .HasColumnType("float");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("MP")
                        .HasColumnType("int");

                    b.Property<int>("location")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("Major_Project.models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Major_Project.models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DataId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Major_Project.models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ScoreAmount")
                        .HasColumnType("int");

                    b.Property<string>("Scores")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("PlayerScore", b =>
                {
                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("ScoresId")
                        .HasColumnType("int");

                    b.HasKey("PlayersId", "ScoresId");

                    b.HasIndex("ScoresId");

                    b.ToTable("PlayerScore");
                });

            modelBuilder.Entity("ItemPlayer", b =>
                {
                    b.HasOne("Major_Project.models.Item", null)
                        .WithMany()
                        .HasForeignKey("itemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("playersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Major_Project.models.Player", b =>
                {
                    b.HasOne("Major_Project.models.Data", "Data")
                        .WithMany("Players")
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Data");
                });

            modelBuilder.Entity("PlayerScore", b =>
                {
                    b.HasOne("Major_Project.models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Major_Project.models.Score", null)
                        .WithMany()
                        .HasForeignKey("ScoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Major_Project.models.Data", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
