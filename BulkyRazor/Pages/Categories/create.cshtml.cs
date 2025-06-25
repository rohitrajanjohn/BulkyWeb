using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class createModel : PageModel
    {
		private readonly AppDbContext _db;
		[BindProperty]
		public Category Category { get; set; }
		public createModel(AppDbContext db)
		{
			_db = db;
		}
		public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
			_db.Categories.Add(Category);
			_db.SaveChanges();
			TempData["success"] = "Category Created Successfully.";
			return RedirectToPage("Index");
		}
    }
}
