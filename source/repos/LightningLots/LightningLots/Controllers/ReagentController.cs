using LightningLots.Models.ViewModel;
using LightningLots.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace LightningLots.Controllers
{
    public class ReagentController : Controller
    {
        IRepository<Reagent> reagentRepo;

        public ReagentController(IRepository<Reagent> reagentRepo)
        {
            this.reagentRepo = reagentRepo;
        }

        [Authorize]
        public ViewResult Index()
        {
            var model = reagentRepo.GetAll();
            return View(model);
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            var model = reagentRepo.GetById(id);
            var updatedDate = model.ReceiptTimeStamp;
            if (updatedDate.AddDays(10) <= DateTime.Now)
            {
                model.IsQuarantineComplete = true;
            }
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
        public IActionResult Create(Reagent reagent)
        {
            ViewBag.LotId = reagent.LotId;
            if (ModelState.IsValid)
            {
                reagentRepo.Create(reagent);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public ViewResult Update(int id)
        {
            Reagent model = reagentRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(Reagent reagent)
        {
            reagentRepo.Update(reagent);
            return RedirectToAction("Details", "Reagent", new { id = reagent.Id });
        }

        [HttpGet]
        [Authorize]
        public ViewResult Delete(int id)
        {
            Reagent model = reagentRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Reagent reagent)
        {
            reagentRepo.Delete(reagent);
            return RedirectToAction("Index", "Reagent");
        }
    }
}
