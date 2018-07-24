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
            return List();
        }

        public ActionResult List()
        {
            return View(db.Superhero.ToList());
        }
    }
}