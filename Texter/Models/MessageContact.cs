using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Models
{
    
    public class MessageContact
    {
		public int MessageId { get; set; }
		public Message Message { get; set; }

		public int ContactId { get; set; }
		public Contact Contact { get; set; }
    }
}
