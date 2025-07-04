using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
	public class editModel : PageModel
	{
		private readonly AppDbContext _db;
		public List<Category> CategoryList { get; set; }
		[BindProperty]
		public Category? Category { get; set; }
		public editModel(AppDbContext db)
		{
			_db = db;
		}
		public void OnGet(int id)
		{
			if (id != null && id != 0)
			{
				Category = _db.Categories.Find(id);
			}
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(Category);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully.";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
