using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Data;

namespace app.Migrations
{
    [DbContext(typeof(HappyfaceDbContext))]
    partial class HappyfaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("WebApplication.Models.Smile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAddress");

                    b.Property<bool>("IsHappy");

                    b.Property<string>("Why");

                    b.HasKey("Id");

                    b.ToTable("Smiles");
                });
        }
    }
}
