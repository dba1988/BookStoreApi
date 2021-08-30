using ProgrammingLangApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Repository
{
	public interface IProgrammingLangRepo
	{
		 Task<List<ProgrammingLangModel>> GetAllBooks();
		Task<ProgrammingLangModel> GetBookById(int BookId);
		Task<int> AddBooK(ProgrammingLangModel bookModel);
		Task UpdateBooK(ProgrammingLangModel bookModel, int id);
		Task UpdateBooKPatch(JsonPatchDocument bookModel, int id);
		Task DeleteBooK(int id);
	}
}
