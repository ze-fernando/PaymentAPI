﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentAPI.Context;

#nullable disable

namespace PaymentAPI.Migrations
{
    [DbContext(typeof(PaymentContext))]
    [Migration("20231108001045_0001")]
    partial class _0001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("PaymentAPI.Models.Payble", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("DatePayment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Payble");
                });

            modelBuilder.Entity("PaymentAPI.Models.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("CardNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cvv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Validation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PaymentAPI.Models.Transactions", b =>
                {
                    b.HasOne("PaymentAPI.Models.Payble", "Payble")
                        .WithOne("Transaction")
                        .HasForeignKey("PaymentAPI.Models.Transactions", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payble");
                });

            modelBuilder.Entity("PaymentAPI.Models.Payble", b =>
                {
                    b.Navigation("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
