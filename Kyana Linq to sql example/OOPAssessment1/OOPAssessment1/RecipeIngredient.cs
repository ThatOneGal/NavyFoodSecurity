using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessment1
{
    [Table]
    class RecipeIngredient
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "int identity")]
        public int ID { get; set; }

        [Column]
        public int recipeID { get; set; }

        [Column]
        public int ingredientID { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(int recipeID, int ingredientsID)
        {
            this.recipeID = recipeID;
            ingredientID = ingredientsID;

        }
    }
}
