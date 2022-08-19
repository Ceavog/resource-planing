﻿// <auto-generated />
using System;
using Backend.DAL_EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.DAL_EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.DataAccessLibrary.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicePointId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicePointId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicePointId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.MenuPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ServicePointId");

                    b.ToTable("MenuPositions");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("MyProperty")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderTypeId");

                    b.HasIndex("ServicePointId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.OrderPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ManuPositionId")
                        .HasColumnType("int");

                    b.Property<int>("MenuPositionId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuPositionId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.ServicePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ServicePoints");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicePointId")
                        .HasColumnType("int");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServicePointId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Category", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany("Categories")
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Client", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany("Clients")
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Delivery", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DataAccessLibrary.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Employee", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany("Employees")
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.MenuPosition", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany("MenuPositions")
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.Order", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DataAccessLibrary.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany("Orders")
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("OrderType");

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.OrderPosition", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.MenuPosition", "MenuPosition")
                        .WithMany()
                        .HasForeignKey("MenuPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DataAccessLibrary.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuPosition");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.User", b =>
                {
                    b.HasOne("Backend.DataAccessLibrary.ServicePoint", "ServicePoint")
                        .WithMany()
                        .HasForeignKey("ServicePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePoint");
                });

            modelBuilder.Entity("Backend.DataAccessLibrary.ServicePoint", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Clients");

                    b.Navigation("Employees");

                    b.Navigation("MenuPositions");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
