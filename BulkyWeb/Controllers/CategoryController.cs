using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly AppDbContext _db;
		public CategoryController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Category> categoriesList = _db.Categories.ToList();
			return View(categoriesList);
		}
		public IActionResult Create()
		{
			return View();
		}
		// insert new category
		[HttpPost]
		public IActionResult Create(Category categoryModel)
		{
			//if (categoryModel.Name == "rohit")
			//	ModelState.AddModelError("","Rohit is not a valid category");
			if (ModelState.IsValid)
			{
				_db.Categories.Add(categoryModel);
				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully.";
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
		public IActionResult Edit(int id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			Category categoryFetch = _db.Categories.Find(id);
			if (categoryFetch == null)
			{
				return NotFound();
			}
			return View(categoryFetch);
		}

		[HttpPost]
		public IActionResult Edit(Category categoryModel)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(categoryModel);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully.";
				return RedirectToAction("Index", "Category");
			}
			return View();
		}

		public IActionResult Delete(int id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			Category categoryFetch = _db.Categories.Find(id);
			if (categoryFetch == null)
			{
				return NotFound();
			}
			return View(categoryFetch);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			Category categoryFetch = _db.Categories.Find(id);
			if(categoryFetch == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(categoryFetch);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully.";
			return RedirectToAction("Index", "Category");
		}
	}
}
