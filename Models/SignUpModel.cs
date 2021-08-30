using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Models
{
	public class SignUpModel
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[Compare("ConfimPassword")]
		public string Password { get; set; }
		[Required]
		public string ConfimPassword { get; set; }

	}
}
