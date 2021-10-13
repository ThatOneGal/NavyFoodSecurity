using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace OOPAssessment1
{
    class RecipeContext : DataContext, ISerialisation
    {
        public Table<Recipe> recipes;
        public Table<Ingredient> ingredients;
        public Table<RecipeIngredient> recipeIngredients;

        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeDB2;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public RecipeContext() : base(connectionString)
        {
            InitialiseData();
        }

        private void InitialiseData()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
            else
            {
                return;
            }
            
            //add items to database.
            List<Recipe> recipeList = new List<Recipe>()
            {
                new Recipe("Spaghetti", "cook it", "6 hours"),
                new Recipe("Cake", "bake it", "4 months"),
                new Recipe("Glass of Milk", "pour it", "2 seconds"),
                new Recipe("Apple", "grow it", "1 year"),
            };
            recipes.InsertAllOnSubmit(recipeList);

            List<Ingredient> ingredientList = new List<Ingredient>()
            {
                new Ingredient("egg", "1"),
                new Ingredient("milk", "1 cups"),
                new Ingredient("water", "2 litres")
            };
            ingredients.InsertAllOnSubmit(ingredientList);

            List<RecipeIngredient> riList = new List<RecipeIngredient>()
            {
                new RecipeIngredient(1,1),
                new RecipeIngredient(1,3),
                new RecipeIngredient(2,1),
                new RecipeIngredient(3,2),
                new RecipeIngredient(4,3),
            };
            recipeIngredients.InsertAllOnSubmit(riList);
            SubmitChanges();
        }

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipeList = new List<Recipe>();
            var results = from r in recipes
                          orderby r.recipeName
                          select r;

            foreach (var item in results)
            {
                if (recipeList.FirstOrDefault(rec => rec.ID == item.ID) != null) continue;
                recipeList.Add(new Recipe(item.ID, item.recipeName, item.recipeMethod, item.recipePrepTime, JoinIngredients(item)));
            }

            return recipeList;
        }

        public List<Ingredient> GetAllIngredients()
        {
            var ings = from i in ingredients select i;
            return ings.ToList();
        }

        public List<Ingredient> JoinIngredients(Recipe r)
        {
            var ing = from i in ingredients
                      join recing in recipeIngredients on i.ID equals recing.ingredientID
                      where recing.recipeID == r.ID
                      select i;

            return ing.ToList();
        }

        public bool AddRecipes(Recipe r)
        {
            //add record for recipe
            recipes.InsertOnSubmit(r);
            SubmitChanges();
            Recipe insertedRecipes = recipes.FirstOrDefault(recipes => recipes.recipeName == r.recipeName);

            List<RecipeIngredient> joinRecords = new List<RecipeIngredient>();

            //check if ingredient exists and add if not
            foreach (var ing in r.ingList)
            {
                if (ingredients.FirstOrDefault(ingr => ingr.ID == ing.ID) == null)
                {
                    ingredients.InsertOnSubmit(ing);
                }

                joinRecords.Add(new RecipeIngredient(insertedRecipes.ID, ing.ID));
            }

            //add record for join table
            recipeIngredients.InsertAllOnSubmit(joinRecords);
            SubmitChanges();
            return true;
        }

        public void Connect(Recipe re)
        {
            //clear list
            var x = from r in recipeIngredients
                    where r.recipeID == re.ID
                    select r;

            x.ToList();

            foreach (var r in x)
            {
                recipeIngredients.DeleteOnSubmit(r);
            }

            List<RecipeIngredient> joinRecords = new List<RecipeIngredient>();

            foreach (var i in re.ingList)
            {
                if (ingredients.FirstOrDefault(ingr => ingr.ID == i.ID) == null)
                {
                    ingredients.InsertOnSubmit(i);
                }

                joinRecords.Add(new RecipeIngredient(re.ID, i.ID));
            }
            recipeIngredients.InsertAllOnSubmit(joinRecords);
            SubmitChanges();
        }

        public void Serialise(List<Recipe> fav)
        {
            Stream stream = File.Open("Favourite Recipes", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, fav);
            stream.Close();
            return;
        }

        public List<Recipe> Deserialise()
        {
            List<Recipe> favs = new List<Recipe>();
            BinaryFormatter bformatter = new BinaryFormatter();
            Stream stream = File.Open("Favourite Recipes", FileMode.Open);
            favs = (List<Recipe>)bformatter.Deserialize(stream);
            stream.Close();
            return favs;
        }
    }
}
