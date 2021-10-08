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
    public class Ingredient
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "int identity")]
        public int ID { get; set; }

        [Column]
        public string ingredientName { get; set; }

        [Column]
        public string ingredentQty { get; set; }

        public Ingredient() { }

        public Ingredient(string ingredientName, string ingredientQty)
        {
            this.ingredientName = ingredientName;
            ingredentQty = ingredientQty;
        }

         List<Recipe> RecList { get; set; }

        public override string ToString()
        {
            return $"{ingredientName}, {ingredentQty}";
        }
    }
}
