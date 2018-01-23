using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Texter.Models;

namespace Texter.Migrations
{
    [DbContext(typeof(TexterDbContext))]
    [Migration("20180123191903_AddContactIdToMessage")]
    partial class AddContactIdToMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Texter.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNo");

                    b.HasKey("ContactId");

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

            modelBuilder.Entity("Texter.Models.MessageContact", b =>
                {
                    b.Property<int>("MessageId");

                    b.Property<int>("ContactId");

                    b.HasKey("MessageId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("MessageContact");
                });

            modelBuilder.Entity("Texter.Models.MessageContact", b =>
                {
                    b.HasOne("Texter.Models.Contact", "Contact")
                        .WithMany("MessageContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Texter.Models.Message", "Message")
                        .WithMany("MessageContacts")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
