/*
 * This is my GitHub repository in case you can't access it through the word doc
* https://github.com/ST10398576/ST10398576_PROG6112_POE_Part2
*/

using ST10398576_PROG6112_POE_Part2; // Importing necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        //Opens the program
        List<Recipe> recipes = new List<Recipe>(); // List to store recipes

        while (true)
        {
            // Main menu for recipe application
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.WriteLine("\n Recipe Application \n"); // Display application title
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
            Console.WriteLine(" 1. Add a Recipe\n"); // Display options
            Console.WriteLine(" 2. Display Recipes\n");
            Console.WriteLine(" 3. Display a specific recipe's details\n");
            Console.WriteLine(" 4. Change the scale of the recipe\n");
            Console.WriteLine(" 5. Reset the scale of the recipe\n");
            Console.WriteLine(" 6. Clear the recipe\n");
            Console.WriteLine(" 7. Close Application\n");

            Console.Write("\n Enter the value of what you would like to do: ");
            string choice = Console.ReadLine(); // Get user input

            //Switch Case to choose what you would like to do in the Program.
            switch (choice)
            {
                //Switch Case to insert a recipe
                case "1":
                    AddRecipe(recipes); // Call method to add a recipe
                    break;

                //Switch Case to display the inserted recipes
                case "2":
                    RecipeDisplay(recipes); // Call method to display recipes
                    break;

                //Switch Case to display a specific recipe's ingredients
                case "3":
                    RecipeDisplayDetails(recipes); // Call method to display details of a specific recipe
                    break;

                //Switch Case to change the scale of a recipe
                case "4":
                    RecipeScale(recipes); // Call method to change the scale of a recipe
                    break;

                //Switch Case to reset the scale of a recipe
                case "5":
                    RecipeScaleReset(recipes); // Call method to reset the scale of a recipe
                    break;

                //Switch Case to clear a specific recipe
                case "6":
                    RecipeClear(recipes); // Call method to clear a specific recipe
                    break;

                //Switch Case to close the program
                case "7":
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                    Console.WriteLine("\n Closing Application"); // Display closing message
                    Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                    return; // Exit the program

                //If a value lower than 0 and higher than 6 is entered, display is message
                default:
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                    Console.Write("\n Invalid choice. Please enter a valid choice: "); // Display error message
                    Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                    break;
            }
        }
    }

    // Method to add a recipe
    static void AddRecipe(List<Recipe> recipes)
    {
        Recipe recipe = new Recipe(); // Create a new recipe instance

        Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
        Console.Write("\n Enter Recipe name: ");
        recipe.RecipeName = Console.ReadLine(); // Get recipe name from user

        Console.Write(" Enter the number of ingredients: ");
        int ingredient_No = Convert.ToInt32(Console.ReadLine()); // Get number of ingredients

        // Loop to input ingredient details
        for (int i = 0; i < ingredient_No; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Set text color to cyan
            Console.WriteLine($"\n Enter the details for ingredient {i + 1}:");

            Console.Write($" The name of ingredient {i + 1}: ");
            string ingredientName = Console.ReadLine(); // Get ingredient name

            // Get quantity, unit of measurement, calories, and food group for the ingredient
            Console.Write($" The quantity: ");
            double ingredientAmount = Convert.ToDouble(Console.ReadLine());
            Console.Write($" The unit of measurement: ");
            string ingredientMeasurement = Console.ReadLine();
            Console.Write($" The calories in this ingredient: ");
            double ingredientCalories = Convert.ToDouble(Console.ReadLine());
            Console.Write($" The food group the ingredient belongs to: ");
            string ingredientFoodGroup = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color

            // Add ingredient to the recipe
            recipe.addIngredient(ingredientName, ingredientAmount, ingredientMeasurement, ingredientCalories, ingredientFoodGroup);
        }

        Console.Write("\n Enter the number of steps for the user to follow: ");
        int steps_No = Convert.ToInt32(Console.ReadLine()); // Get number of steps

        // Loop to input step descriptions
        Console.WriteLine("\n Write a description for each step");
        for (int s = 0; s < steps_No; s++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to magenta
            Console.Write($"\n Step {s + 1}: ");
            recipe.addStep(Console.ReadLine()); // Get step description
        }

        recipe.calculateTotalCalories(); // Calculate total calories of the recipe

        // Display warning if total calories exceed 300
        if (recipe.TotalCalories > 300)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n Warning! Total calories of the recipe exceed 300!");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }

        recipes.Add(recipe); // Add recipe to the list
    }

    // Method to display all recipes
    static void RecipeDisplay(List<Recipe> recipes)
    {
        // If the recipe list is not empty, display the recipes
        if (recipes.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
            Console.WriteLine("\n List of recipes: ");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color

            // Display recipe names
            foreach (var recipe in recipes.OrderBy(r => r.RecipeName))
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
                Console.WriteLine($"\n -{recipe.RecipeName} ");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
            }
        }
        // Else there are no recipes to display
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n There is no recipe to display");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
    }

    // Method to display details of a specific recipe
    static void RecipeDisplayDetails(List<Recipe> recipes)
    {
        // If the recipe list is not empty, display the asked for recipe
        if (recipes.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.Write("\n Enter the name of the recipe you want to see: ");
            string recipeName = Console.ReadLine(); // Get recipe name from user

            // Search for the asked for recipe in the recipes list, ignoring the different casing
            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null) // If recipe not found
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine("\n Recipe not found");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                return;
            }

            recipe.recipeDisplay(); // Display recipe details
        }
        // Else there is no recipe to display
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n There is no recipe to display");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
    }

    // Method to change the scale of a recipe
    static void RecipeScale(List<Recipe> recipes)
    {
        // If the recipe list is not empty
        if (recipes.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.Write("\n Enter the name of the recipe you want to scale: ");
            string recipeName = Console.ReadLine(); // Get recipe name from user

            // Search for the recipe in the list
            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null) // If recipe not found
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine($"\n Recipe '{recipeName}' not found");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                return;
            }

            // Get scaling factor from user
            Console.Write("\n Enter the scaling factor (0.5, 2, 3): ");
            double scaleAmount;
            if (double.TryParse(Console.ReadLine(), out scaleAmount))
            {
                if (scaleAmount == 0.5 || scaleAmount == 2 || scaleAmount == 3) // Check if valid scaling factor
                {
                    recipe.recipeScale(scaleAmount); // Scale the recipe
                    Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
                    Console.WriteLine($"Recipe '{recipeName}' scaled by a factor of {scaleAmount} successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                    Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                    Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
            }
        }
        // If there are no recipes in the list
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n There are no recipes to scale.");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
    }

    // Method to reset the scale of a recipe
    static void RecipeScaleReset(List<Recipe> recipes)
    {
        // If the recipe list is not empty
        if (recipes.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.Write("\n Enter the name of the recipe you want to reset the scale of: ");
            string recipeName = Console.ReadLine(); // Get recipe name from user

            // Search for the recipe in the list
            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null) // If recipe not found
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine("\n Recipe with that name not found");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                return;
            }

            // Reset the scale of the recipe
            double scaleResetFactor = recipe.currentScaleAmount / recipe.ogScaleAmount;
            foreach (var ingredient in recipe.ingredients)
            {
                ingredient.IngredientAmount /= scaleResetFactor; // Reset ingredient amounts
            }

            recipe.recipeScaleReset(); // Reset recipe scale
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
            Console.WriteLine("Recipe scale successfully reset!");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
        // Else there is no recipe to reset the scale of
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n There is no recipe to reset the scale of");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
    }

    // Method to clear a specific recipe
    static void RecipeClear(List<Recipe> recipes)
    {
        // If the recipe list is not empty
        if (recipes.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.Write("\n Enter the name of the recipe you want to clear:");
            string recipeName = Console.ReadLine(); // Get recipe name from user

            // Search for the recipe in the list
            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null) // If recipe not found
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine("\n Recipe with that name not found");
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
                return;
            }

            recipes.Clear(); // Clear all recipes
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
            Console.WriteLine("\n Recipe successfully cleared!");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
        // Else there is no recipe to reset the scale of
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("\n There is no recipe to clear");
            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color
        }
    }
}

/*
 * This is my GitHub repository in case you can't access it through the word doc
* https://github.com/ST10398576/ST10398576_PROG6112_POE_Part2
*/
