using AutoMapper;
using ProgrammingLangApi.Data;
using ProgrammingLangApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Helper
{
	public class ApplicationMapper: Profile
	{
		public ApplicationMapper()
		{
			CreateMap<ProgrammingLangs,ProgrammingLangModel>().ReverseMap();
		}
	}
}
