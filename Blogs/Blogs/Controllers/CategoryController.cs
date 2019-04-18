using AutoMapper;
using Blog.Entities;
using Blog.Service.Interface;
using Blogs.ViewModels;
using Blogs.ViewModels.ApiViewModel;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using static Common.Contant;

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
        public ApiViewModel<CategoryViewModel> Create(string categoryName)
        {
            ApiViewModel<CategoryViewModel> model;

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                model = new ApiViewModel<CategoryViewModel>()
                 {
                     ApiStatusCode = StatusCode.OK,
                     Data = Mapper.Map<CategoryViewModel>(_categoryService.Create(categoryName)),
                     ResponseMessage = string.Empty
                 };                
            }
            else
            {
                model = new ApiViewModel<CategoryViewModel>()
                {
                    ApiStatusCode = StatusCode.Dupplicate,
                    Data = null,
                    ResponseMessage = string.Format("{0} is {1}", ResponseMessageText.CATEGORY_NAME, ResponseMessageText.IS_DUPPLICATED)
                };
            }
            return model; 
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