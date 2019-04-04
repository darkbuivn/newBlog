using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Service;

namespace Blog.Controllers
{
    [Authorize(Roles = "Administrator")]   
    public class CategoryController : Controller
    {
        private CategoryService _categoryService = new CategoryService();

        // Contructors
        public CategoryController()
        {

        }
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category           
        public ActionResult Index()
        {
            List<Category> model = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(string categoryname)
        {
            if(categoryname!="")
            {
                _categoryService.Create(categoryname);                
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(int id)
        {
            Category category = _categoryService.GetById(id);
            if (category!= null)
            {
                return View(category);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeName(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Name = HttpUtility.HtmlEncode(category.Name);
                _categoryService.Update(category);                
            }
            return RedirectToAction("Index");
        }
    }    
}