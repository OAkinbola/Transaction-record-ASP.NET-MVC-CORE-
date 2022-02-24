﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionsRecordFile.Models;

namespace TransactionsRecordFile.Migrations
{
    [DbContext(typeof(TransactionRecord))]
    [Migration("20211009183412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionsRecordFile.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyAddress = " 123 Google Way",
                            CompanyName = "Google",
                            Ticker = "GOOG"
                        },
                        new
                        {
                            CompanyId = 2,
                            CompanyAddress = "423 Bill Gate Drive",
                            CompanyName = "Microsoft",
                            Ticker = "MSFT"
                        });
                });

            modelBuilder.Entity("TransactionsRecordFile.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("SharePrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("TransactionTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            CompanyId = 1,
                            Quantity = 100,
                            SharePrice = 12.244999999999999,
                            TransactionTypeId = "B"
                        },
                        new
                        {
                            TransactionId = 2,
                            CompanyId = 2,
                            Quantity = 100,
                            SharePrice = 2701.7600000000002,
                            TransactionTypeId = "S"
                        });
                });

            modelBuilder.Entity("TransactionsRecordFile.Models.TransactionType", b =>
                {
                    b.Property<string>("TransactionTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeId = "S",
                            Fee = 5.9900000000000002,
                            Name = "Sell"
                        },
                        new
                        {
                            TransactionTypeId = "B",
                            Fee = 5.4000000000000004,
                            Name = "Buy"
                        });
                });

            modelBuilder.Entity("TransactionsRecordFile.Models.Transaction", b =>
                {
                    b.HasOne("TransactionsRecordFile.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionsRecordFile.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("TransactionType");
                });
#pragma warning restore 612, 618
        }
    }
}
