using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Models
{
	[Table("Contacts")]
	public class Contact
	{
		[Key]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNo { get; set; }
		public int MessageId { get; set; }
		public virtual Message Message { get; set; }

	}
}

