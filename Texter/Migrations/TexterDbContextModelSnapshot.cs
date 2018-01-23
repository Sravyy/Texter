using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Texter.Models;

namespace Texter.Migrations
{
    [DbContext(typeof(TexterDbContext))]
    partial class TexterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Texter.Models.Contact", b =>
                {
                    b.Property<string>("FirstName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastName");

                    b.Property<int>("MessageId");

                    b.Property<string>("PhoneNo");

                    b.HasKey("FirstName");

                    b.HasIndex("MessageId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Texter.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("ContactId");

                    b.Property<string>("From");

                    b.Property<string>("Status");

                    b.Property<string>("To");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Texter.Models.Contact", b =>
                {
                    b.HasOne("Texter.Models.Message", "Message")
                        .WithMany("Contacts")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
