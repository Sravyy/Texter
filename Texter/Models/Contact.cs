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
        public int ContactId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNo { get; set; }
    
        public virtual ICollection<MessageContact> MessageContacts { get; set; }

	}
}

