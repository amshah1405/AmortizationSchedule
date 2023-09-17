﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MortgageCalculatorDBContext))]
    [Migration("20230917190230_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entity.MonthlyPaymentDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("monthlyInterest")
                        .HasColumnType("float");

                    b.Property<double>("monthlyPayment")
                        .HasColumnType("float");

                    b.Property<int>("mortageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("principalAmt")
                        .HasColumnType("float");

                    b.Property<double>("remainingBalance")
                        .HasColumnType("float");

                    b.Property<double>("totalInterest")
                        .HasColumnType("float");

                    b.Property<double>("totalPaid")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("mortageId");

                    b.ToTable("MonthlyPaymentDetails");
                });

            modelBuilder.Entity("DataLayer.Entity.MortgageDetail", b =>
                {
                    b.Property<int>("mortgageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("mortgageID"));

                    b.Property<double>("annualInterestRate")
                        .HasColumnType("float");

                    b.Property<double>("loanAmount")
                        .HasColumnType("float");

                    b.Property<int>("loanTerm")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("mortgageID");

                    b.ToTable("MortgageDetail");
                });

            modelBuilder.Entity("DataLayer.Entity.MonthlyPaymentDetail", b =>
                {
                    b.HasOne("DataLayer.Entity.MortgageDetail", "mortgageDetail")
                        .WithMany("mortagePaymentDetails")
                        .HasForeignKey("mortageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mortgageDetail");
                });

            modelBuilder.Entity("DataLayer.Entity.MortgageDetail", b =>
                {
                    b.Navigation("mortagePaymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}