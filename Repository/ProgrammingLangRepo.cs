using AutoMapper;
using ProgrammingLangApi.Data;
using ProgrammingLangApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLangApi.Repository
{
	public class ProgrammingLangRepo : IProgrammingLangRepo
	{
		private readonly ProgrammingLangContext _context;
		private readonly IMapper _mapper;

		public ProgrammingLangRepo(ProgrammingLangContext context,IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<ProgrammingLangModel>> GetAllBooks()
		{
			//convert books to book model manually for now 
			//var recoreds =await _context.Books.Select(x=>new BookModel() {
			//	Id=x.Id,
			//	Title = x.Title,
			//	Description = x.Description
			//}).ToListAsync();
			//return recoreds;

			// use auto mapper
			var books = await _context.Books.ToListAsync();
			return _mapper.Map<List<ProgrammingLangModel>>(books);
		}
		public async Task<ProgrammingLangModel> GetBookById(int BookId)
		{
			//convert books to book model manually for now 
			//var recoreds = await _context.Books.Where(x=>x.Id.Equals(BookId)).Select(x => new BookModel()
			//{
			//	Id = x.Id,
			//	Title = x.Title,
			//	Description = x.Description
			//}).FirstOrDefaultAsync();
			//return recoreds;

			// map object using auto mapper
			var book = await _context.Books.FindAsync(BookId);
			return _mapper.Map<ProgrammingLangModel>(book);	
		}
		public async Task<int> AddBooK(ProgrammingLangModel bookModel)
		{
			var book = new ProgrammingLangs()
			{
				Title = bookModel.Title,
				Description = bookModel.Description
			};
			 _context.Books.Add(book);
			await _context.SaveChangesAsync();
			return book.Id;

		}
		public async Task UpdateBooK(ProgrammingLangModel bookModel,int id)
		{
			//var book =await _context.Books.FindAsync(id);
			//if(book != null)
			//{
			//	book.Title = bookModel.Title;
			//	book.Description = bookModel.Description;
			//	await _context.SaveChangesAsync();
			//};
			var book = new ProgrammingLangs()
			{
				Id = id,
				Title = bookModel.Title,
				Description = bookModel.Description
			};
			_context.Books.Update(book);
			await _context.SaveChangesAsync();
			

		}
		public async Task DeleteBooK(int id)
		{
			var book = new ProgrammingLangs()
			{
				Id=id
			};
			_context.Books.Remove(book);
			await _context.SaveChangesAsync();

		}

		public async Task UpdateBooKPatch(JsonPatchDocument bookModel, int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				bookModel.ApplyTo(book);
				await _context.SaveChangesAsync();
			};
		}
	}
}
