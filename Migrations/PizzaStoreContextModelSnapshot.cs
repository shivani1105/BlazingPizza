﻿// <auto-generated />
using System;
using BlazingPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazingPizza.Migrations
{
    [DbContext(typeof(PizzaStoreContext))]
    partial class PizzaStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("BlazingPizza.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BlazingPizza.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlazingPizza.Model.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SpecialId");

                    b.ToTable("ActualPizzas");
                });

            modelBuilder.Entity("BlazingPizza.Model.PizzaSpecial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FixedSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("BlazingPizza.Model.PizzaTopping", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToppingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzaId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaTopping");
                });

            modelBuilder.Entity("BlazingPizza.Model.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("BlazingPizza.Model.Order", b =>
                {
                    b.HasOne("BlazingPizza.Model.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");
                });

            modelBuilder.Entity("BlazingPizza.Model.Pizza", b =>
                {
                    b.HasOne("BlazingPizza.Model.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazingPizza.Model.PizzaSpecial", "Special")
                        .WithMany()
                        .HasForeignKey("SpecialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Special");
                });

            modelBuilder.Entity("BlazingPizza.Model.PizzaTopping", b =>
                {
                    b.HasOne("BlazingPizza.Model.Pizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazingPizza.Model.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("BlazingPizza.Model.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("BlazingPizza.Model.Pizza", b =>
                {
                    b.Navigation("Toppings");
                });
#pragma warning restore 612, 618
        }
    }
}
