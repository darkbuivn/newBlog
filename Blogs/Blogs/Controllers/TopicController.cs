using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Service;
using PagedList;

namespace Blog.Controllers
{
    public class TopicController : Controller
    {
        private TopicService _topicService = new TopicService();

        public TopicController()
        {

        }

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: Topic
        public ActionResult Index(int? page)
        {
            List<Topic> model = _topicService.GetAllIncludeCategory();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));              
        }

        public ActionResult Browse(int? page, int categoryId = 0)
        {
            if (categoryId == 0)
                return RedirectToAction("Index");

            List<Topic> model = _topicService.GetAllWithCategoryIdIncludeCategory(categoryId);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id=0)
        {
            if (id == 0)
                return RedirectToAction("Index");
            else
            {
                Topic model = _topicService.GetByIdWithCategory(id);
                return View(model);
            }           
        }

        // GET: Topic/Create
        [Authorize(Roles="Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]       
        public ActionResult Create(Topic topic, int categoryId, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string UploadPath = "~/Images/";
                string fileName = String.Concat(DateTime.Now.ToString().GetHashCode(), upload.FileName);
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

        // GET: Topic/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Topic model = _topicService.GetByIdWithCategory(id);
            return View(model);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]  
        public ActionResult Edit(int categoryId,  Topic model, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string UploadPath = "~/Images/";
                string fileName = String.Concat(DateTime.Now.ToString().GetHashCode(), upload.FileName);
                var imagePath = Path.Combine(Server.MapPath(UploadPath), fileName);
                var imageUrl = Path.Combine(UploadPath, fileName);
                upload.SaveAs(imagePath);
                model.Image = fileName;
            }
            _topicService.Update(model);   
            return View(model);
        }

        // GET: Topic/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string keyword, int? page)
        {
            keyword = HttpUtility.HtmlEncode(keyword);

            if(keyword == null || keyword.Equals(""))
            {
                return RedirectToAction("Index");
            }

            List<Topic> result = _topicService.SearchResult(keyword);

            if (result.Count == 0)
                return RedirectToAction("Index");

            ViewBag.keyword = keyword;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));               
        }
    }
}
