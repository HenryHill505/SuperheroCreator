using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superhero
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Superhero newHero)
        {
            if (ModelState.IsValid)
            {
                db.Superhero.Add(newHero);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            Superhero hero = db.Superhero.Where(s => s.Id == Id).FirstOrDefault();
            db.Superhero.Remove(hero);
            db.SaveChanges();
            return View("List", db.Superhero.ToList());
        }

        public ActionResult Edit(int Id)
        {
            var hero = db.Superhero.Where(h => h.Id == Id).FirstOrDefault();
            return View(hero);
        }

        [HttpPost]
        public ActionResult Edit(Superhero hero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hero).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View("List", db.Superhero.ToList());
        }

        public ActionResult List()
        {
            return View(db.Superhero.ToList());
        }
    }
}