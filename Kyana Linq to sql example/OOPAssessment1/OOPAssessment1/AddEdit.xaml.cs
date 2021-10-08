using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOPAssessment1
{
    /// <summary>
    /// Interaction logic for AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        RecipeContext context = new RecipeContext();
        public MainWindow mw = new MainWindow();
        public List<Ingredient> addIngList = new List<Ingredient>();

        Recipe recToEdit;
        public bool addBool;

        public string editQty;
        public string editMethod;
        public string editPrep;
        public string editName;

        public AddEdit(Recipe r = null)
        {
            InitializeComponent();

            mw.ingredients = context.GetAllIngredients();
            IngAddListView.ItemsSource = mw.ingredients;
            
            if (r !=null )
            {
                AddNameTB.Text = r.recipeName;
                AddPrepTB.Text = r.recipePrepTime;
                AddMethodTB.Text = r.recipeMethod;

                foreach(var i in r.ingList)
                {
                    addIngList.Add(i);
                }

                IngSubmitListView.ItemsSource = addIngList;
                recToEdit = r;
                addBool = false;
                
            }
            else if (r == null)
            {
                addBool = true;
            }
            
        }

        private void SubmitBTN_Click(object sender, RoutedEventArgs e)
        {
            if (AddMethodTB != null && AddNameTB != null && AddPrepTB != null && IngSubmitListView != null)
            {
                //if add button was selecetd
                if (addBool == true)
                {
                    string addName = AddNameTB.Text;
                    string addPrep = AddPrepTB.Text;
                    string addMethod = AddMethodTB.Text;
                    string addQty = AddQtyTB.Text;
                    Recipe newRecipe = new Recipe(addName, addPrep, addMethod);

                    newRecipe.ingList = addIngList;

                    context.recipes.InsertOnSubmit(newRecipe);
                    context.SubmitChanges();

                    context.Connect(newRecipe);
                }
                else if (addBool == false)
                //if edit button was selected
                {
                    editName = AddNameTB.Text;
                    editPrep = AddPrepTB.Text;
                    editMethod = AddMethodTB.Text;
                    editQty = AddQtyTB.Text;

                    Recipe rec = context.recipes.FirstOrDefault(recipe => recipe.ID == recToEdit.ID);

                    rec.recipeName = editName;
                    rec.recipePrepTime = editPrep;
                    rec.recipeMethod = editMethod;

                    rec.ingList = (List<Ingredient>)IngSubmitListView.ItemsSource;

                    context.Connect(rec);
                    context.SubmitChanges();
                }
            }
            else
            {
                MessageBox.Show("Enter content into every field!");
            }

            mw.RefreshData();
            Close();
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddIngBTN_Click(object sender, RoutedEventArgs e)
        {
            Ingredient selectedIng = (Ingredient)IngAddListView.SelectedItem;
            Ingredient IngCon = context.ingredients.FirstOrDefault(ing => ing.ID == selectedIng.ID);

            if (selectedIng == null) return;

            if (AddQtyTB.Text == "")
            {
                MessageBox.Show("Enter a quantity!");
            }
            else
            {
                string qty = AddQtyTB.Text;
                IngCon.ingredentQty = qty;

                addIngList.Add(IngCon);
                IngSubmitListView.ItemsSource = null;
                IngSubmitListView.ItemsSource = addIngList;

                AddQtyTB.Clear();
            }
        }

        private void RemIngBTN_Click(object sender, RoutedEventArgs e)
        {
            Ingredient selectedIng = (Ingredient)IngSubmitListView.SelectedItem;

            if (selectedIng == null) return;

            addIngList.Remove(selectedIng);
            IngSubmitListView.ItemsSource = null;
            IngSubmitListView.ItemsSource = addIngList;
        }
    }
}
