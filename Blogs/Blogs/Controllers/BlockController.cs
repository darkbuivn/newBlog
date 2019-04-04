using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.Entities;
using Blog.Service.Interface;
using Blogs.ViewModels;

namespace Blogs.Controllers
{
    [Authorize]
	public class BlockController : Controller
	{
		private IBlockService _blockService;

        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        // GET: Block
        public ActionResult Index()
        {
            List<Block> model = _blockService.GetAll().ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] 
        public ActionResult Create(BlockViewModel model)
        {
            if(ModelState.IsValid)
            {
                Block block = new Block()
				{
					Name = model.Name,
					Content = model.Content,
					status = model.status
				};
			
                _blockService.Create(block);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Active(Guid id)
        {
            _blockService.Active(id);
            return RedirectToAction("Index");
        }

        public ActionResult Deactive(Guid id)
        {
            _blockService.Deactive(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            Block block = _blockService.GetById(id);
			BlockViewModel model = new BlockViewModel
			{
				Id = block.Id,
				Name = block.Name,
				Content = block.Content,
				status = block.status
			};
			return View(model);
        }

        [HttpPost]
        [ValidateInput(false)] 
        public ActionResult Edit(BlockViewModel model)
        {
            Block block = _blockService.GetById(model.Id);
            block.Name = model.Name;
            block.Content = model.Content;
            block.status = model.status;
            _blockService.Update(block);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Block block = _blockService.GetById(id);
            if (block != null)
                _blockService.Delete(block);
            return RedirectToAction("Index");
        }
    }
}