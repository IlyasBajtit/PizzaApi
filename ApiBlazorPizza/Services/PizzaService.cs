using ApiBlazorPizza.Models;
using System.Collections.Generic;
using System.Linq;
using ApiBlazorPizza.Data;

namespace ApiBlazorPizza.Services
{
    public class PizzaService
    {
        // Récupérer toutes les pizzas depuis FakeDb
        public IReadOnlyList<Pizza> GetPizzas() => FakeDb.Pizzas;

        public void AddPizza(Pizza pizza)
        {
            FakeDb.Pizzas.Add(pizza);
        }

        // Récupérer une pizza par son ID depuis FakeDb
        public Pizza GetPizzaById(int id) => FakeDb.Pizzas.FirstOrDefault(p => p.Id == id);

        // Mettre à jour une pizza dans FakeDb
        public void UpdatePizza(Pizza updatedPizza)
        {
            var pizzaIndex = FakeDb.Pizzas.FindIndex(p => p.Id == updatedPizza.Id);
            if (pizzaIndex != -1)
            {
                FakeDb.Pizzas[pizzaIndex] = updatedPizza;
            }
            else
            {
                throw new KeyNotFoundException("Pizza not found");
            }
        }

        // Supprimer une pizza de FakeDb
        public void DeletePizza(int id)
        {
            var pizza = FakeDb.Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                FakeDb.Pizzas.Remove(pizza);
            }
        }
    }
}
