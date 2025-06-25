using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class deleteModel : PageModel
    {
		private readonly AppDbContext _db;
		public List<Category> CategoryList { get; set; }
		[BindProperty]
		public Category? Category { get; set; }
		public deleteModel(AppDbContext db)
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
			Category categoryFetch = _db.Categories.Find(Category.Id);
			if (categoryFetch == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(categoryFetch);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully.";
			return RedirectToPage("Index");
		}
	}
}
