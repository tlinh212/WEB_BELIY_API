﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_BELIY_API.DATA;

namespace WEB_BELIY_API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230416152632_CreateTablePromotion")]
    partial class CreateTablePromotion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Category", b =>
                {
                    b.Property<int>("IDCat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDParent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDCat");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Customer", b =>
                {
                    b.Property<Guid>("IdCus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdCus");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.ImportBill", b =>
                {
                    b.Property<Guid>("IDImp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateImport")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDSupp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDWare")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("IDImp");

                    b.HasIndex("IDSupp");

                    b.HasIndex("IDWare");

                    b.ToTable("ImportBills");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Product", b =>
                {
                    b.Property<Guid>("IDPro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("IDCat")
                        .HasColumnType("int");

                    b.Property<Guid>("IDImp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NamePro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SaleRate")
                        .HasColumnType("float");

                    b.HasKey("IDPro");

                    b.HasIndex("IDCat");

                    b.HasIndex("IDImp");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Promotion", b =>
                {
                    b.Property<Guid>("IDPromotion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NamePromotion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDPromotion");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Supplier", b =>
                {
                    b.Property<Guid>("IDSupp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameSupp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDSupp");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.WareHouse", b =>
                {
                    b.Property<Guid>("IDWare")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWare")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDWare");

                    b.ToTable("WareHouses");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.ImportBill", b =>
                {
                    b.HasOne("WEB_BELIY_API.MODEL.Supplier", "Supplier")
                        .WithMany("ImportBills")
                        .HasForeignKey("IDSupp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB_BELIY_API.MODEL.WareHouse", "WareHouse")
                        .WithMany("ImportBills")
                        .HasForeignKey("IDWare")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Product", b =>
                {
                    b.HasOne("WEB_BELIY_API.MODEL.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IDCat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB_BELIY_API.MODEL.ImportBill", "ImportBill")
                        .WithMany("Products")
                        .HasForeignKey("IDImp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ImportBill");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.ImportBill", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.Supplier", b =>
                {
                    b.Navigation("ImportBills");
                });

            modelBuilder.Entity("WEB_BELIY_API.MODEL.WareHouse", b =>
                {
                    b.Navigation("ImportBills");
                });
#pragma warning restore 612, 618
        }
    }
}
