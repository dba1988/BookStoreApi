using ProgrammingLangApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Repository
{
	public interface IAccountRepository
	{
		Task<IdentityResult> SignUp(SignUpModel signUpModel);
	}
}
