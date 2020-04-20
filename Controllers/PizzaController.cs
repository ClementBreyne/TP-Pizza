using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPizza.BO;
using TpPizza.Models;
using TpPizza.Utils;

namespace TpPizza.Controllers
{
    public class PizzaController : Controller
    {
        public List<Pate> lstPate = FakeDbPizza.Instance.pates;
        public List<Ingredient> lstIngredient = FakeDbPizza.Instance.ingredient;
        public static List<Pizza> lstPizza = new List<Pizza>();
        
        // GET: Pizza
        public ActionResult Index()
        {
            return View(lstPizza);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();
            foreach (var pate in lstPate)
            {
                vm.Pates.Add(new Pate { Id = pate.Id, Nom = pate.Nom });
            }
            foreach (var ingredient in lstIngredient)
            {
                vm.Ingredients.Add(new Ingredient { Id = ingredient.Id, Nom = ingredient.Nom });
            }
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel p)
        {
            try
            {
                if (p != null)
                {
                    PizzaViewModel PizzaAdd = new PizzaViewModel();
                    PizzaAdd.Pizza.Pate = lstPate.FirstOrDefault(x => x.Id == p.IdPates);
                    foreach (var ingredient in p.Ingredients)
                    {
                        PizzaAdd.Pizza.Ingredients.Add(ingredient);
                    }
                    lstPizza.Add(PizzaAdd.Pizza);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza vm = lstPizza.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                Pizza pizzaEdit = vm.Pizza;
                pizzaEdit.Nom = vm.Pizza.Nom;
                pizzaEdit.Pate = vm.Pizza.Pate;
                pizzaEdit.Ingredients = vm.Pizza.Ingredients;

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza PizzaDelete = lstPizza.FirstOrDefault(x => x.Id == id);
            return View(PizzaDelete);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        { 
            try
            {
                Pizza PizzaDelete = lstPizza.FirstOrDefault(x => x.Id == id);
                if(PizzaDelete!=null)
                {
                    lstPizza.Remove(PizzaDelete);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
