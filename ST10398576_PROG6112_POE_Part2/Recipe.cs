/*
 * This is my GitHub repository in case you can't access it through the word doc
 * https://github.com/ST10398576/ST10398576_PROG6112_POE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10398576_PROG6112_POE_Part2
{

    public class Ingredient
    {
        public string IngredientName { get; set; }
        public double IngredientAmount { get; set; }
        public string IngredientMeasurement { get; set; }
        public double IngredientCalories { get; set; }
        public string IngredientFoodGroup { get; set; }

    }

    // Class to represent a recipe
    public class Recipe
    {
        private List<Ingredient> ingredients;
        private List<string> steps;
        private double ogScaleAmount;
        private double currentScaleAmount;

        public string RecipeName { get; set; }
        public double TotalCalories { get; private set; }

        //Constructor to initialize arrays for ingredients and steps
        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        //Method to add a ingredient to the recipe
        public void addIngredient(string ingredientName, double ingredientAmount, string ingredientMeasurement, double ingredientCalories, string ingredientFoodGroup)
        {
            ingredients.Add(new Ingredient
            {
                IngredientName = ingredientName,
                IngredientAmount = ingredientAmount,
                IngredientMeasurement = ingredientMeasurement,
                IngredientCalories = ingredientCalories,
                IngredientFoodGroup = ingredientFoodGroup
            });
        }

        //Method to add a step to the recipe
        public void addStep(string step)
        {
            steps.Add(step);
        }

        public void calculateTotalCalories()
        {
            TotalCalories = ingredients.Sum(ingredient => ingredient.IngredientCalories * ingredient.IngredientAmount);
        }


        //Method to write the details of the recipe
        public void recipeDisplay()
        {
            Console.Write($" Recipe: {RecipeName} ");

            Console.Write(" Ingredients: ");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"-{ingredient.IngredientAmount} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} ({ingredient.IngredientCalories} calories - {ingredient.IngredientFoodGroup})");
            }
            Console.WriteLine("Steps: ");
            foreach (var step in steps)
            {
                Console.WriteLine($"- {step}");
            }
            Console.WriteLine($"Total Calories: {TotalCalories}");
        }

        //Method to change the scale of the recipe
        public void recipeScale(double scaleAmount)
        {
            // Change scale of a recipe
            currentScaleAmount *= scaleAmount;
            calculateTotalCalories();

        }

        //Method to change the scale of the recipe
        public void recipeScaleReset()
        {
            // Reset the scale of a recipe
            currentScaleAmount = ogScaleAmount;
            calculateTotalCalories();

        }

    }
}

/*
 * This is my GitHub repository in case you can't access it through the word doc
* https://github.com/ST10398576/ST10398576_PROG6112_POE
*/
