
/*
 * This is my GitHub repository in case you can't access it through the word doc
 * https://github.com/ST10398576/ST10398576_PROG6112_POE
 */

using ST10398576_PROG6112_POE_Part2;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

// Class to run the program
public class Program
{
    static void Main(string[] args)
    {
        //Opens the program
        List<Recipe> recipes = new List<Recipe>();

        while (true)
        {
            // Main menu for recipe application
            Console.WriteLine("\n Recipe Application \n");
            Console.WriteLine(" 1. Add a Recipe\n");
            Console.WriteLine(" 2. Display Recipes\n");
            Console.WriteLine(" 3. Display a specific recipe's details\n");
            Console.WriteLine(" 4. Change the scale of the recipe\n");
            Console.WriteLine(" 5. Reset the scale of the recipe\n");
            Console.WriteLine(" 6. Clear the recipe\n");
            Console.WriteLine(" 7. Close Application\n");


            Console.Write("\n Enter the value of what you would like to do: ");
            string choice = Console.ReadLine();
            //Switch Case to choose what you would like to do in the Program.
            switch (choice)
            {
                //Switch Case to insert a recipe
                case "1":
                    addRecipe(recipes);
                    break;

                //Switch Case to display the inserted recipes
                case "2":
                    recipeDisplay(recipes);
                    break;

                //Switch Case to display a specific recipe's ingredients
                case "3":
                    recipeDisplayDetails(recipes);
                    break;

                //Switch Case to change the scale of a recipe
                case "4":
                    recipeScale(recipes);
                    break;

                //Switch Case to reset the scale of a recipe
                case "5":
                    recipeScaleReset(recipes);
                    break;

                //Switch Case to clear a specific recipe
                case "6":
                    recipeClear(recipes);
                    break;

                //Switch Case to close the program
                case "7":
                    Console.WriteLine("\n Closing Application",Console.ForegroundColor=ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                
                //If a value lower than 0 and higher than 6 is entered, display is message
                default:
                    Console.Write("\n Invalid choice. Please enter a valid choice: ", Console.ForegroundColor);
                    break;

            }
        }
    }

    static void addRecipe(List<Recipe> recipes)
    {
        Recipe recipe = new Recipe();

        Console.Write("\n Enter Recipe name: ");
        recipe.RecipeName = Console.ReadLine();

        Console.Write(" Enter the number of ingredients: ");
        int ingredient_No = Convert.ToInt32(Console.ReadLine());


        for (int i = 0; i < ingredient_No; i++)
        {
            Console.WriteLine($"\n Enter the details for ingredient {i + 1}:");

            Console.Write($" The name of ingredient {i + 1}: ");
            string ingredientName = Console.ReadLine();

            Console.Write($" The quantity: ");
            double ingredientAmount = Convert.ToDouble(Console.ReadLine());

            Console.Write($" The unit of measurement: ");
            string ingredientMeasurement = Console.ReadLine();

            Console.Write($" The calories in this ingredient: ");
            double ingredientCalories = Convert.ToDouble(Console.ReadLine());

            Console.Write($" The food group the ingredient belongs to: ");
            string ingredientFoodGroup = Console.ReadLine();

            recipe.addIngredient(ingredientName, ingredientAmount, ingredientMeasurement, ingredientCalories, ingredientFoodGroup);

        }

        Console.Write("\n Enter the number of steps for the user to follow: ");
        int steps_No = Convert.ToInt32(Console.ReadLine());

        //Initialize array for steps and input step descriptions
        Console.WriteLine("\n Write a description for each step");

        for (int s = 0; s < steps_No; s++)
        {
            Console.Write($"\n Step {s + 1}: ");
            recipe.addStep(Console.ReadLine());
        }

        recipe.calculateTotalCalories();
        if (recipe.TotalCalories > 300)
        {
            Console.WriteLine("\n Warning! Total calories of the recipe exceed 300!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        recipes.Add(recipe);
    }

    static void recipeDisplay(List<Recipe> recipes)
    {
        //If the recipe is not empty, display the recipe
        if (recipes.Count > 0)
        {
            //Display ingredients
            Console.WriteLine("\n List of recipes: ");
            foreach (var recipe in recipes.OrderBy(r => r.RecipeName))
            {
                Console.WriteLine(recipe.RecipeName);
            }

        }
        //Else there is no recipe to display
        else
        {
            Console.WriteLine("\n There is no recipe to display", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        }

    }

    static void recipeDisplayDetails(List<Recipe> recipes)
    {
        //If the recipe is not empty, display the asked for recipe
        if (recipes.Count > 0)
        {
            //Asks the user which recipe they want to see
            Console.WriteLine("\n Enter the name of the recipe you want to see: ");
            string recipeName = Console.ReadLine();

            //Searches for the asked for recipe in the recipes list, ignoring the different casing
            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null) 
            { 
                Console.WriteLine("\n Recipe not found", Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            recipe.recipeDisplay();

        }
        //Else there is no recipe to display
        else
        {
            Console.WriteLine("\n There is no recipe to display", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        }
    }

    static void recipeScale(List<Recipe> recipes)
    {
        //If the recipe is not empty, change the scale of the recipe
        if (recipes.Count > 0)
        {
            // Select the recipe you want to scale
            Console.Write("\n Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if(recipe == null)
            {
                Console.WriteLine("\n Recipe not found", Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Console.Write("\n Enter the scaling factor(0.5, 2, 3): "); 
            double scaleAmount = Convert.ToDouble(Console.ReadLine());

            recipe.recipeScale(scaleAmount);
            Console.WriteLine("\n Recipe successfully scaled!");

        }
        //Else there is no recipe to scale
        else
        {
            Console.WriteLine("\n There is no recipe to scale", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        }
    }

    static void recipeScaleReset(List<Recipe> recipes)
    {
        //If the recipe is not empty, reset the scale of the recipe
        if (recipes.Count > 0)
        {
            // Select the recipe you want to reset the scale of
            Console.Write("\n Enter the name of the recipe you want to reset the scale of:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("\n Recipe with that name not found");
                return;
            }

            recipe.recipeScaleReset();
            Console.WriteLine("Recipe scale successfully reset!");

        }
        //Else there is no recipe to reset the scale of
        else
        {
            Console.WriteLine("\n There is no recipe to reset the scale of");
            return;
        }
    }

    static void recipeClear(List<Recipe> recipes)
    {
        //If the recipe is not empty, reset the scale of the recipe
        if (recipes.Count > 0)
        {
            // Select the recipe you want to reset the scale of
            Console.Write("Enter the name of the recipe you want to clear:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("\n Recipe with that name not found");
                return;
            }

            recipes.Clear();
            Console.WriteLine("Recipe successfully cleared!");

        }
        //Else there is no recipe to reset the scale of
        else
        {
            Console.WriteLine("\n There is no recipe to clear");
            return;
        }
    }
}

/*
 * This is my GitHub repository in case you can't access it through the word doc
 * https://github.com/ST10398576/ST10398576_PROG6112_POE
 */