﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Contextt;

namespace WebAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200906192348_aviocompany")]
    partial class aviocompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.AvioCompany", b =>
                {
                    b.Property<int>("AvioCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvioCompanyId");

                    b.ToTable("aviocompanydb");
                });

            modelBuilder.Entity("WebAPI.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ascenddest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AvioCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Descenddest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationId");

                    b.HasIndex("AvioCompanyId");

                    b.ToTable("destinationdb");
                });

            modelBuilder.Entity("WebAPI.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Dtaascend")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dtadescend")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Ticketprice")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("WebAPI.Models.Friend", b =>
                {
                    b.Property<int>("MainUserId")
                        .HasColumnType("int");

                    b.Property<int>("FriendUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.HasKey("MainUserId", "FriendUserId");

                    b.HasIndex("FriendUserId");

                    b.ToTable("frienddb");
                });

            modelBuilder.Entity("WebAPI.Models.Stop", b =>
                {
                    b.Property<int>("StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopId");

                    b.HasIndex("FlightId");

                    b.ToTable("Stop");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("userdb");
                });

            modelBuilder.Entity("WebAPI.Models.Destination", b =>
                {
                    b.HasOne("WebAPI.Models.AvioCompany", null)
                        .WithMany("Destinations")
                        .HasForeignKey("AvioCompanyId");
                });

            modelBuilder.Entity("WebAPI.Models.Flight", b =>
                {
                    b.HasOne("WebAPI.Models.Destination", "Destination")
                        .WithMany("Flights")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Friend", b =>
                {
                    b.HasOne("WebAPI.Models.User", "FriendUser")
                        .WithMany("Friends")
                        .HasForeignKey("FriendUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "MainUser")
                        .WithMany("MainUserFriends")
                        .HasForeignKey("MainUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Stop", b =>
                {
                    b.HasOne("WebAPI.Models.Flight", "Flight")
                        .WithMany("Stops")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
