using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Models
{
	public class ProgrammingLangModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Please Provide The Titile")]
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
