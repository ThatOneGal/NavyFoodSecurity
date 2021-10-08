using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessment1
{
    [Serializable]
    [Table]
    public class Recipe
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT IDENTITY")]
        public int ID { get; set; }

        [Column]
        public string recipeName { get; set; }

        [Column]
        public string recipeMethod { get; set; }

        [Column]
        public string recipePrepTime { get; set; }

        public bool isFavourite = false;

        public Recipe() { }

        public Recipe(string recipeName, string recipeMethod, string recipePrepTime, List<Ingredient> ing = null)
        {
            this.recipeName = recipeName;
            this.recipeMethod = recipeMethod;
            this.recipePrepTime = recipePrepTime;
            ingList = (ing == null) ? new List<Ingredient>() : ing; //null check or assign if not null
        }

        public Recipe(int id, string recipeName, string recipeMethod, string recipePrepTime, List<Ingredient> ing = null)
        {
            ID = id;
            this.recipeName = recipeName;
            this.recipeMethod = recipeMethod;
            this.recipePrepTime = recipePrepTime;
            ingList = (ing == null) ? new List<Ingredient>() : ing; //null check or assign if not null
        }

        public List<Ingredient> ingList { get; set; }

        public override string ToString()
        {
            return $"{recipeName}";
        }
    }
}
