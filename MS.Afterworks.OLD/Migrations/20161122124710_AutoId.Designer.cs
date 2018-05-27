using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Data;

namespace app.Migrations
{
    [DbContext(typeof(HappyfaceDbContext))]
    [Migration("20161122124710_AutoId")]
    partial class AutoId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
