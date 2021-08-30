using ProgrammingLangApi.Models;
using ProgrammingLangApi.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProgrammingLangController : ControllerBase
	{
		private readonly IProgrammingLangRepo _bookRepository;

		public ProgrammingLangController(IProgrammingLangRepo bookRepository)
		{
			_bookRepository = bookRepository;
		}
		[HttpGet("")]
		public async Task<IActionResult> GetAllBooks()
		{
			var books =await _bookRepository.GetAllBooks();
			return Ok(books);

		}
		[HttpGet("{bookId}")]
		public async Task<IActionResult> GetBookById([FromRoute]int bookId)
		{
			var book = await _bookRepository.GetBookById(bookId);
			if(book == null) return NotFound();
			return Ok(book);

		}
		[HttpPost("")]
		public async Task<IActionResult> AddBook([FromBody] ProgrammingLangModel bookModel)
		{
			var id = await _bookRepository.AddBooK(bookModel);
			return CreatedAtAction(nameof(GetBookById), new { bookId = id, controller = "Books" },id);

		}
		[HttpPut("{bookId}")]
		public async Task<IActionResult> UpdateBook([FromBody] ProgrammingLangModel bookModel,[FromRoute] int bookId)
		{
			 await _bookRepository.UpdateBooK(bookModel,bookId);
			return Ok();

		}
		[HttpPatch("{bookId}")]
		public async Task<IActionResult> UpdateBookByPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int bookId)
		{
			// body
			// [
			//{
			//	"operationType": 0,
			//	"path": "title",
			//	"op": "repalce","value": "Python"
		  
			//  }
			//]
			await _bookRepository.UpdateBooKPatch(bookModel, bookId);
			return Ok();

		}
		[HttpDelete("{bookId}")]
		public async Task<IActionResult> DeleteBookById( [FromRoute] int bookId)
		{
			await _bookRepository.DeleteBooK(bookId);
			return Ok();

		}
	}
}
