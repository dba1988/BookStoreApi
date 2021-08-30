using ProgrammingLangApi.Models;
using ProgrammingLangApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository accountRepository;

		public AccountController(IAccountRepository accountRepository)
		{
			this.accountRepository = accountRepository;
		}
		[HttpPost("signup")]
		public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
		{
			var result = await this.accountRepository.SignUp(signUpModel);
if (result.Succeeded)
			{
				return Ok(result.Succeeded);
			}
return Unauthorized();

		}
		//[HttpPost("signin")]
		//public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
		//{
			

		//}
	}
}
