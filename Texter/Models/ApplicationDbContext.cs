using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Texter.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public ApplicationDbContext()
		{

		}

		public DbSet<Message> Messages { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=texterMessageApp;uid=root;pwd=root;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            base.OnModelCreating(builder);

			builder.Entity<MessageContact>()
			.HasKey(t => new { t.MessageId, t.ContactId });

			builder.Entity<MessageContact>()
				.HasOne(pt => pt.Message)
				.WithMany(p => p.MessageContacts)
				.HasForeignKey(pt => pt.MessageId);

			builder.Entity<MessageContact>()
				.HasOne(pt => pt.Contact)
				.WithMany(t => t.MessageContacts)
				.HasForeignKey(pt => pt.ContactId);

		    builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
                .HasMaxLength(255));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
                .HasMaxLength(255));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
                .HasMaxLength(255));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));
		}


	}
}
