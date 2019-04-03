using Blog.Service.Interface;
using Blogs.ViewModels;
using System.Web.Mvc;
using AutoMapper;
using Blog.Entities;

namespace Blogs.Controllers
{
    public class HomeController : Controller
    {
        private ITopicService _topicService;
        private ICategoryService _categoryService;

        public HomeController()
        {

        }
        public HomeController(ITopicService topicService, ICategoryService categoryService)
        {
            _topicService = topicService;
            _categoryService = categoryService;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = Common.Contant.PageTitle.HOME_PAGE;

            TopicViewModel model;
            Topic topic = _topicService.GetNewest();
            if (topic != null)
            {
                model = Mapper.Map<Topic, TopicViewModel>(topic);
                model.Category = Mapper.Map<Category, CategoryViewModel>(_categoryService.GetById(model.CategoryId));
                ViewBag.MoreTopics = _topicService.GetMore(model.Id);                
            }
            else
            {
                model = new TopicViewModel();
                model.Category = new CategoryViewModel();
            }
            return View(model);
        }
    }
}