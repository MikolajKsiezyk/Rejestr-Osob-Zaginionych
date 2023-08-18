using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RejOsobZaginionych.Models;

namespace RejOsobZaginionych.Controllers
{
    public class OsobyController : Controller
    {
        public ActionResult Index(string plec)
        {
            using (var context = new AppDbContext())
            {
                var osoby = context.Osoby.AsQueryable();

                if (!string.IsNullOrEmpty(plec))
                {
                    osoby = osoby.Where(o => o.Plec == plec);
                }

                return View(osoby.ToList());
            }
        }

        public ActionResult Seed()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Osoby.Any()) // Dodajemy osoby tylko wtedy, gdy tabela jest pusta.
                {
                    context.Osoby.Add(new Osoba { Imie = "Anna", Nazwisko = "Kowalska", DataZaginiecia = DateTime.Now.AddDays(-10), Plec = "Kobieta" });
                    context.Osoby.Add(new Osoba { Imie = "Jan", Nazwisko = "Nowak", DataZaginiecia = DateTime.Now.AddDays(-5), Plec = "Mezczyzna" });
                    context.Osoby.Add(new Osoba { Imie = "Piotr", Nazwisko = "Zieliński", DataZaginiecia = DateTime.Now.AddDays(-2), Plec = "Mezczyzna" });

                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        // Akcja do przetwarzania danych z formularza
        [HttpPost]
        public ActionResult Create(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    context.Osoby.Add(osoba);
                    context.SaveChanges();
                    return RedirectToAction("Index"); // przekierowanie do listy osób po pomyślnym dodaniu
                }
            }

            return View(osoba); // jeśli dane są nieprawidłowe, ponownie wyświetl formularz z przekazaną osobą
        }

        public ActionResult Edit(int id)
        {
            using (var context = new AppDbContext())
            {
                var osoba = context.Osoby.Find(id);

                if (osoba == null)
                {
                    return HttpNotFound();
                }

                return View(osoba);
            }
        }

        // Akcja do przetwarzania edytowanych danych
        [HttpPost]
        public ActionResult Edit(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    context.Entry(osoba).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index"); // przekierowanie do listy osób po pomyślnym edytowaniu
                }
            }

            return View(osoba); // jeśli dane są nieprawidłowe, ponownie wyświetl formularz z przekazaną osobą
        }
    }
}