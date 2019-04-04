using AutoMapper;
using Blog.Entities;
using Blog.Service.Interface;
using Blogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category           
        public ActionResult Index()
        {
            List<CategoryViewModel> model = Mapper.Map<List<Category>, List<CategoryViewModel>>(_categoryService.GetAll().ToList());

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(string categoryname)
        {
            if (!string.IsNullOrWhiteSpace(categoryname))
            {
                _categoryService.Create(categoryname);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            CategoryViewModel category = Mapper.Map<Category, CategoryViewModel>(_categoryService.GetById(id));
            if (category != null)
            {
                return View(category);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeName(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                category.Name = HttpUtility.HtmlEncode(category.Name);
                _categoryService.Update(Mapper.Map<CategoryViewModel, Category>(category));
            }    
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            CategoryViewModel category = Mapper.Map<Category, CategoryViewModel>(_categoryService.GetById(id));
            return View(category);
        }

    }
}