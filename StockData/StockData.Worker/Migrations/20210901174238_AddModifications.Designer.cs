﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockData.Stock.Contexts;

namespace StockData.Worker.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20210901174238_AddModifications")]
    partial class AddModifications
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockData.Stock.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TradeCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockData.Stock.Entities.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Change")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosePrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("High")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastTradingPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Low")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YesterdayClosePrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("StockData.Stock.Entities.StockPrice", b =>
                {
                    b.HasOne("StockData.Stock.Entities.Company", "Company")
                        .WithMany("StockPrices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StockData.Stock.Entities.Company", b =>
                {
                    b.Navigation("StockPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
