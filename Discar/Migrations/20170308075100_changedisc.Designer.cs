using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Discar.Models;

namespace Discar.Migrations
{
    [DbContext(typeof(DiscContext))]
    [Migration("20170308075100_changedisc")]
    partial class changedisc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Discar.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Discar.Models.Disc", b =>
                {
                    b.Property<int>("DiscId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<string>("DiscName");

                    b.Property<float>("Fade");

                    b.Property<float>("Glide");

                    b.Property<string>("Plastic");

                    b.Property<float>("Price");

                    b.Property<float>("Speed");

                    b.Property<float>("Stability");

                    b.Property<string>("Url");

                    b.HasKey("DiscId");

                    b.HasIndex("BrandId");

                    b.ToTable("Discs");
                });

            modelBuilder.Entity("Discar.Models.Disc", b =>
                {
                    b.HasOne("Discar.Models.Brand", "Brand")
                        .WithMany("Discs")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
