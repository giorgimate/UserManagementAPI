﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Persistence.Context;

#nullable disable

namespace UserManagement.Persistence.Migrations
{
    [DbContext(typeof(UserManagementContext))]
    [Migration("20240329113947_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserManagement.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Wallet")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("UserManagement.Domain.Transactions.Transactionn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfTransfer")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceiverCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("SenderCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("TransferredAmount")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverCustomerId");

                    b.HasIndex("SenderCustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("UserManagement.Domain.Transactions.Transactionn", b =>
                {
                    b.HasOne("UserManagement.Domain.Customers.Customer", "ReceiverCustomer")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ReceiverCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UserManagement.Domain.Customers.Customer", "SenderCustomer")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceiverCustomer");

                    b.Navigation("SenderCustomer");
                });

            modelBuilder.Entity("UserManagement.Domain.Customers.Customer", b =>
                {
                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
