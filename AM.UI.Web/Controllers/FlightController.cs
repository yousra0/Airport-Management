﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;
        public FlightController(IServiceFlight sf,IServicePlane sp)
        {
            this.sf = sf;  
            this.sp = sp;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(sf.GetMany());
            else
              return  View(sf.GetMany(f => f.FlightDate.Equals(dateDepart)));
        }

        public ActionResult Sort()
        { 
            return View(sf.SortFlights()); 
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(sf.GetById(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.lsPlanes = new SelectList(sp.GetMany(),"PlaneId","Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection,IFormFile airlineIMG)
        {
            try
            {
                
                if (airlineIMG != null)
                {
                    //sauvegarder le nom du fichier dans la collection
                    collection.AirlineLogo = airlineIMG.FileName;
                    //sauvegarder l'image daqns le dossier uploads
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", airlineIMG.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    airlineIMG.CopyTo(stream);
                    
                }

                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.lsPlanes = new SelectList(sp.GetMany(), "PlaneId", "Information");

            return View(sf.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                sf.Update(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                sf.Delete(sf.GetById(id));
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
