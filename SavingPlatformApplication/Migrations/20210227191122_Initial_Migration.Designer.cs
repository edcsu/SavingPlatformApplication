﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SavingPlatformApplication.Data;

namespace SavingPlatformApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210227191122_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Client");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Client");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Credit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<double>("FinancialResourceAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentPeriod")
                        .HasColumnType("datetime2");

                    b.Property<double>("PercentInterest")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Deposit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMadeByMember")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Member", b =>
                {
                    b.HasBaseType("SavingPlatformApplication.Data.Models.Client");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.SavingsGroup", b =>
                {
                    b.HasBaseType("SavingPlatformApplication.Data.Models.Client");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("MemberId");

                    b.HasDiscriminator().HasValue("SavingsGroup");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Client", b =>
                {
                    b.HasOne("SavingPlatformApplication.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Credit", b =>
                {
                    b.HasOne("SavingPlatformApplication.Data.Models.Client", "Client")
                        .WithMany("Credits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Deposit", b =>
                {
                    b.HasOne("SavingPlatformApplication.Data.Models.Client", "Client")
                        .WithMany("Deposits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Transaction", b =>
                {
                    b.HasOne("SavingPlatformApplication.Data.Models.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.SavingsGroup", b =>
                {
                    b.HasOne("SavingPlatformApplication.Data.Models.Member", null)
                        .WithMany("SavingsGroups")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Client", b =>
                {
                    b.Navigation("Credits");

                    b.Navigation("Deposits");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SavingPlatformApplication.Data.Models.Member", b =>
                {
                    b.Navigation("SavingsGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
