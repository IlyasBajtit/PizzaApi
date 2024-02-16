using ApiBlazorPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiBlazorPizza.Services
{
    public class PanierService
    {
        private List<ArticlePanier> articles = new List<ArticlePanier>();

        public IReadOnlyList<ArticlePanier> Articles => articles;

        public void AjouterArticle(Pizza pizza, int quantite = 1)
        {
            var article = articles.FirstOrDefault(a => a.PizzaId == pizza.Id);
            if (article == null)
            {
                articles.Add(new ArticlePanier { PizzaId = pizza.Id, PizzaNom = pizza.Name, Prix = pizza.Price, Quantite = quantite });
            }
            else
            {
                article.Quantite += quantite;
            }
        }

        public void SupprimerArticle(int pizzaId)
        {
            var article = articles.FirstOrDefault(a => a.PizzaId == pizzaId);
            if (article != null)
            {
                articles.Remove(article);
            }
        }

        public decimal ObtenirTotal()
        {
            return articles.Sum(a => a.Prix * a.Quantite);
        }

        public void ViderPanier()
        {
            articles.Clear();
        }
    }
}