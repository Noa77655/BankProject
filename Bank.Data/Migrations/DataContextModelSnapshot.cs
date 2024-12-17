﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project;

#nullable disable

namespace Bank.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("project.Entitis.Banker", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("phonNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("bankers");
                });

            modelBuilder.Entity("project.Entitis.Customer", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TurnId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("phonNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("TurnId")
                        .IsUnique();

                    b.ToTable("customers");
                });

            modelBuilder.Entity("project.Entitis.Turn", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bankerid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("bankerid");

                    b.ToTable("turns");
                });

            modelBuilder.Entity("project.Entitis.Customer", b =>
                {
                    b.HasOne("project.Entitis.Turn", "Turn")
                        .WithOne("customer")
                        .HasForeignKey("project.Entitis.Customer", "TurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("project.Entitis.Turn", b =>
                {
                    b.HasOne("project.Entitis.Banker", "banker")
                        .WithMany("turns")
                        .HasForeignKey("bankerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("banker");
                });

            modelBuilder.Entity("project.Entitis.Banker", b =>
                {
                    b.Navigation("turns");
                });

            modelBuilder.Entity("project.Entitis.Turn", b =>
                {
                    b.Navigation("customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
