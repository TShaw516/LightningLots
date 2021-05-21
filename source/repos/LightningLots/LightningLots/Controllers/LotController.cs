using LightningLots.Models.ViewModel;
using LightningLots.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightningLots.Controllers
{
    public class LotController : Controller
    {
        IRepository<Lot> lotRepo;

        public LotController(IRepository<Lot> lotRepo)
        {
            this.lotRepo = lotRepo;
        }

        [Authorize]
        public ViewResult Index()
        {
            var model = lotRepo.GetAll();
            return View(model);
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            var model = lotRepo.GetById(id);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Lot lot)
        {
            lotRepo.Create(lot);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public ViewResult Update(int id)
        {
            Lot model = lotRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Lot lot)
        {
            lotRepo.Update(lot);
            return RedirectToAction("Details", "Lot", new { id = lot.Id });
        }

        [HttpGet]
        [Authorize]
        public ViewResult Delete(int id)
        {
            Lot model = lotRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Lot lot)
        {
            lotRepo.Delete(lot);
            return RedirectToAction("Index", "Lot");
        }
    }
}
