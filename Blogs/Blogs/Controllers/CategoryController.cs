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

        public CategoryController()
        {
        }

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }        

        // GET: Category           
        public ActionResult Index()
        {
            IEnumerable<Category> topics = _categoryService.GetAll();

            var map = Mapper.Instance;            

            List<CategoryViewModel> model = new List<CategoryViewModel>();
            foreach(var item in topics)
            {
                model.Add(map.Map<CategoryViewModel>(item));
            }     

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                _categoryService.Create(categoryName);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            CategoryViewModel category = Mapper.Map<CategoryViewModel>(_categoryService.GetById(id));
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
                _categoryService.Update(Mapper.Map<Category>(category));
            }    
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            CategoryViewModel category = Mapper.Map<CategoryViewModel>(_categoryService.GetById(id));
            return View(category);
        }

    }
}