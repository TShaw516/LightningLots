using LightningLots.Models.ViewModel;
using LightningLots.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace LightningLots.Controllers
{
    public class LotController : Controller
    {
        IRepository<Lot> lotRepo;
        private readonly IWebHostEnvironment hostingEnvironment;

        public LotController(IRepository<Lot> lotRepo,
                             IWebHostEnvironment hostingEnvironment)
        {
            this.lotRepo = lotRepo;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(LotCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Attachment != null)
                {
                    uniqueFileName = ProcessUploadedFile(model);
                }

                Lot newLot = new Lot
                {
                    LotName = model.LotName,
                    CreationTimeStamp = model.CreationTimeStamp,
                    Weight = model.Weight,
                    AttachmentPath = uniqueFileName,
                    Reagents = model.Reagents
                };

                lotRepo.Create(newLot);
                return RedirectToAction("details", new { id = newLot.Id });
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Update(int id)
        {
            Lot model = lotRepo.GetById(id);
            LotUpdateViewModel lotUpdateViewModel = new LotUpdateViewModel
            {
                Id = model.Id,
                LotName = model.LotName,
                Weight = model.Weight,
                CreationTimeStamp = model.CreationTimeStamp,
                ExistingAttachmentPath = model.AttachmentPath,
                Reagents = model.Reagents
            };
            
            return View(lotUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(LotUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Attachment != null)
                {
                    Lot lot = lotRepo.GetById(model.Id);
                    lot.LotName = model.LotName;
                    lot.CreationTimeStamp = model.CreationTimeStamp;
                    lot.Reagents = model.Reagents;
                    lot.Weight = model.Weight;
                    if (model.Attachment != null)
                    {
                        if (model.ExistingAttachmentPath != null)
                        { 
                            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "coa", model.ExistingAttachmentPath);
                            System.IO.File.Delete(filePath);
                        }
                        lot.AttachmentPath = ProcessUploadedFile(model);
                    }

                    lotRepo.Update(lot);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        private string ProcessUploadedFile(LotCreateViewModel model)
        {
            string uniqueFileName;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "coa");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Attachment.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            model.Attachment.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
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
