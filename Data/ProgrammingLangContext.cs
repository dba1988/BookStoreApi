using ProgrammingLangApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Data
{
	public class ProgrammingLangContext : IdentityDbContext<ApplicationUser>
	{
		public ProgrammingLangContext(DbContextOptions<ProgrammingLangContext> options) : base(options) {}
		public DbSet<ProgrammingLangs> Books { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	//optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=Ture");
		//	base.OnConfiguring(optionsBuilder);
		//}
	}
}
