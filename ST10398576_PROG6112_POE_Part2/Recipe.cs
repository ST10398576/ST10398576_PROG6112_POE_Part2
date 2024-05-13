/*
 * This is my GitHub repository in case you can't access it through the word doc
 * https://github.com/ST10398576/ST10398576_PROG6112_POE_Part2
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10398576_PROG6112_POE_Part2
{
    // Class to represent an ingredient
    public class Ingredient
    {
        // Properties to store ingredient details
        public string IngredientName { get; set; }
        public double IngredientAmount { get; set; }
        public string IngredientMeasurement { get; set; }
        public double IngredientCalories { get; set; }
        public string IngredientFoodGroup { get; set; }
    }

    // Class to represent a recipe
    public class Recipe
    {
        // Lists to store ingredients and steps of the recipe
        public List<Ingredient> ingredients;
        public List<string> steps;

        // Properties to store original and current scale amounts
        public double ogScaleAmount;
        public double currentScaleAmount;

        // Properties to store recipe name and total calories
        public string RecipeName { get; set; }
        public double TotalCalories { get; private set; }

        // Constructor to initialize arrays for ingredients and steps
        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void addIngredient(string ingredientName, double ingredientAmount, string ingredientMeasurement, double ingredientCalories, string ingredientFoodGroup)
        {
            // Create a new Ingredient object and add it to the list
            ingredients.Add(new Ingredient
            {
                IngredientName = ingredientName,
                IngredientAmount = ingredientAmount,
                IngredientMeasurement = ingredientMeasurement,
                IngredientCalories = ingredientCalories,
                IngredientFoodGroup = ingredientFoodGroup
            });
        }

        // Method to add a step to the recipe
        public void addStep(string step)
        {
            steps.Add(step);
        }

        // Method to calculate the total calories of the recipe
        public void calculateTotalCalories()
        {
            // Sum up the calories of all ingredients considering their amounts
            TotalCalories = ingredients.Sum(ingredient => ingredient.IngredientCalories * ingredient.IngredientAmount);
        }

        // Method to display the details of the recipe
        public void recipeDisplay()
        {
            Console.WriteLine($"\n Recipe: {RecipeName} ");

            // Display ingredients
            Console.WriteLine(" Ingredients: ");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($" - {ingredient.IngredientAmount} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} ({ingredient.IngredientCalories} calories - {ingredient.IngredientFoodGroup})");
            }

            // Display steps
            Console.WriteLine(" Steps: ");
            foreach (var step in steps)
            {
                Console.WriteLine($" - {step}");
            }

            // Display total calories and a warning if they exceed 300
            Console.WriteLine($" Total Calories: {TotalCalories}");
            if (TotalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Warning! Total calories of the recipe exceed 300!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        // Method to change the scale of the recipe
        public void recipeScale(double scaleAmount)
        {
            // Update the current scale amount
            currentScaleAmount *= scaleAmount;

            // Adjust ingredient amounts based on the scaling factor
            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientAmount *= scaleAmount;
            }

            // Recalculate total calories
            calculateTotalCalories();
        }

        // Method to reset the scale of the recipe
        public void recipeScaleReset()
        {
            // Reset the current scale amount to the original scale amount
            currentScaleAmount = ogScaleAmount;

            // Adjust ingredient amounts back to the original scale
            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientAmount = ingredient.IngredientAmount / currentScaleAmount;
            }

            // Recalculate total calories
            calculateTotalCalories();
        }
    }
}
/*
 * This is my GitHub repository in case you can't access it through the word doc
 * https://github.com/ST10398576/ST10398576_PROG6112_POE_Part2
 */
