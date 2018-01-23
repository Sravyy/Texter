//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Texter.Models
//{
//    public class TexterDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public TexterDbContext()
//        {
//        }

//		public DbSet<Message> Messages { get; set; }
//        public DbSet<Contact> Contacts { get; set; }

//		protected override void OnConfiguring(DbContextOptionsBuilder options)
//		{
//			options.UseMySql(@"Server=localhost;Port=8889;database=texterMessageApp;uid=root;pwd=root;");
//		}

//		public TexterDbContext(DbContextOptions<TexterDbContext> options)
//            : base(options)
//        {
//		}

//		protected override void OnModelCreating(ModelBuilder builder)
//		{
//			builder.Entity<MessageContact>()
//			.HasKey(t => new { t.MessageId, t.ContactId });

//			builder.Entity<MessageContact>()
//				.HasOne(pt => pt.Message)
//				.WithMany(p => p.MessageContacts)
//				.HasForeignKey(pt => pt.MessageId);

//			builder.Entity<MessageContact>()
//				.HasOne(pt => pt.Contact)
//				.WithMany(t => t.MessageContacts)
//				.HasForeignKey(pt => pt.ContactId);
//		}

//    }
//}
