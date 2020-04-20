using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpPizza.BO;

namespace TpPizza.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; } = new List<Ingredient>();
        public List<Pate> Pates { get; } = new List<Pate>();
        public int IdPates { get; set; }
        public int IdIngredient { get; set; }
    }
}