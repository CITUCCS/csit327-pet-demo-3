﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pets.Contexts;

#nullable disable

namespace Pets.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230515061841_Pet.AddOneToOne")]
    partial class PetAddOneToOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pets.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Pets.Models.PetDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("PetDetails");
                });

            modelBuilder.Entity("Pets.Models.PetDetails", b =>
                {
                    b.HasOne("Pets.Models.Pet", "Pet")
                        .WithOne("Details")
                        .HasForeignKey("Pets.Models.PetDetails", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Pets.Models.Pet", b =>
                {
                    b.Navigation("Details")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
