using AutoMapper;
using Blog.Entities;
using Blog.Service.Business;
using Blog.Service.Interface;
using Blogs.ViewModels;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Controllers
{
    public class PostController : Controller
    {
        private ITopicService _topicService;
        // GET: Topic
        public PostController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: Topic
        public ActionResult Index(int? pageSize, int? page)
        {
            int rows = pageSize ?? Common.Contant.Configuration.POST_PER_PAGE;
            int pageNumber = page ?? Common.Contant.Configuration.FIRST_NUMBER;
            TopicsSearchResult model = _topicService.GetAll(rows, pageNumber);

            return View(model);
        }

        public ActionResult Browse(int? page, int categoryId = 0)
        {
            //if (categoryId == 0)
            //    return RedirectToAction("Index");

            //List<Topic> model = _topicService.GetAllWithCategoryIdIncludeCategory(categoryId);

            //int pageSize = 10;
            //int pageNumber = (page ?? 1);
            //return View(model.ToPagedList(pageNumber, pageSize));
            return View();
        }

        // GET: Topic/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null || id.Equals(Guid.Empty))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TopicViewModel model = Mapper.Map<Topic, TopicViewModel>(_topicService.GetById(id));
                if (model == null)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        // GET: Topic/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [Authorize]
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Topic topic, Guid categoryId, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string UploadPath = "~/Images/";
                string fileName = string.Concat(DateTime.Now.ToString().GetHashCode(), upload.FileName);
                var imagePath = Path.Combine(Server.MapPath(UploadPath), fileName);
                var imageUrl = Path.Combine(UploadPath, fileName);
                upload.SaveAs(imagePath);
                topic.Image = fileName;
            }
            topic.CreatedDate = DateTime.Now;
            topic.CategoryId = categoryId;
            _topicService.Create(topic);
            return RedirectToAction("Index");
        }

        //// GET: Topic/Edit/5
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Edit(Guid id)
        //{
        //    Topic model = _topicService.GetById(id);
        //    return View(model);
        //}

        //// POST: Topic/Edit/5
        //[HttpPost]
        //[Authorize(Roles = "Administrator")]
        //[AcceptVerbs(HttpVerbs.Post)]
        //[ValidateInput(false)]
        //public ActionResult Edit(int categoryId, Topic model, HttpPostedFileBase upload)
        //{
        //    if (upload != null)
        //    {
        //        string UploadPath = "~/Images/";
        //        string fileName = String.Concat(DateTime.Now.ToString().GetHashCode(), upload.FileName);
        //        var imagePath = Path.Combine(Server.MapPath(UploadPath), fileName);
        //        var imageUrl = Path.Combine(UploadPath, fileName);
        //        upload.SaveAs(imagePath);
        //        model.Image = fileName;
        //    }
        //    _topicService.Update(model);
        //    return View(model);
        //}

        //// GET: Topic/Delete/5
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Topic/Delete/5
        //[HttpPost]
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Search(string keyword, int? page)
        //{
        //    keyword = HttpUtility.HtmlEncode(keyword);

        //    if (keyword == null || keyword.Equals(""))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    List<Topic> result = _topicService.Search(keyword).ToList();

        //    if (result.Count == 0)
        //        return RedirectToAction("Index");

        //    ViewBag.keyword = keyword;
        //    int pageSize = 8;
        //    int pageNumber = (page ?? 1);
        //    return View();
        //}
    }
}