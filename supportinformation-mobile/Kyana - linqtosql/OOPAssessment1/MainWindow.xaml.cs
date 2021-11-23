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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPAssessment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecipeContext context = new RecipeContext();

        List<Recipe> recipes = new List<Recipe>();
        public List<Ingredient> ingredients = new List<Ingredient>();
        public Recipe editRec;
        List<Recipe> favList = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            recipes = context.GetAllRecipes();
            foreach (Recipe recipe in recipes)
            {
                RecipeListView.ItemsSource = recipes;

            }
        }

        public void RefreshData()
        {
            recipes = context.GetAllRecipes();
            RecipeListView.ItemsSource = null;
            RecipeListView.ItemsSource = recipes;
        }



        private void RecipeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipeListView.SelectedItem;

            if (selectedRecipe == null) return;

            PrepTB.Text = selectedRecipe.recipePrepTime;
            MethodTB.Text = selectedRecipe.recipeMethod;

            foreach (var i in selectedRecipe.ingList)
            {
                IngredientsLB.ItemsSource = selectedRecipe.ingList;
            }

            if (favList.Contains(selectedRecipe))
            {
                FavCheckBox.IsChecked = true;
            }
            else
            {
                FavCheckBox.IsChecked = false;
            }

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            

            AddEdit AEWindow = new AddEdit(null);
            AEWindow.Show();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipeListView.SelectedItem;
            
            if (selectedRecipe != null)
            {
                //editRec = selectedRecipe;
                AddEdit AEWindow = new AddEdit(selectedRecipe);
                AEWindow.Show();
            }
            else
            {
                MessageBox.Show("Select an item to edit.");
            }
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            var qry = (from r in recipes
                       where r.recipeName.ToLower().Contains(SearchTB.Text.ToLower())
                       || r.recipePrepTime.ToLower().Contains(SearchTB.Text.ToLower())
                       select r).ToList();

            RecipeListView.ItemsSource = qry;
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipeListView.SelectedItem;

            if (selectedRecipe != null)
            {
                var delRec = context.recipes.FirstOrDefault(r => r.ID == selectedRecipe.ID);
                context.recipes.DeleteOnSubmit(delRec);
                context.SubmitChanges();

                PrepTB.Clear();
                MethodTB.Clear();
                SearchTB.Clear();
                IngredientsLB.ItemsSource = null;

                RefreshData(); 
            }
            else
            {
                MessageBox.Show("Select a recipe to delete.");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void FavCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipeListView.SelectedItem;

            selectedRecipe.isFavourite = false;

            if (selectedRecipe.isFavourite)
            {
                favList.Remove(selectedRecipe);
            }
        }

        private void FavCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipeListView.SelectedItem;
            
            selectedRecipe.isFavourite = true;

            if (selectedRecipe.isFavourite && !favList.Contains(selectedRecipe))
            {
                favList.Add(selectedRecipe);
            }
        }

        private void FavBTN_Click(object sender, RoutedEventArgs e)
        {
            context.Serialise(favList);
            RecipeListView.ItemsSource = context.Deserialise();
        }
    }
}
