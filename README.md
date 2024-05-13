# ST10398576_PROG6112_POE_Part2
# Recipe Application

This is a simple console-based recipe application that allows users to manage recipes. Users can add recipes, display them, view details of specific recipes, scale recipes, reset recipe scales, and clear recipes.

## Features

- **Add a Recipe**: Users can add a new recipe by providing the recipe name, ingredients, and steps.
- **Display Recipes**: Users can view a list of all added recipes.
- **Display a Specific Recipe's Details**: Users can view the details of a specific recipe, including ingredients, steps, and total calories.
- **Change the Scale of the Recipe**: Users can scale a recipe by a given factor.
- **Reset the Scale of the Recipe**: Users can reset the scale of a recipe back to its original scale.
- **Clear a Recipe**: Users can clear a specific recipe from the list.

## Instructions

1. **Main Menu**: When you run the application, you will see a main menu with options to perform various actions.
2. **Adding a Recipe**: Select option `1` to add a new recipe. Follow the prompts to input the recipe name, ingredients, and steps.
3. **Displaying Recipes**: Select option `2` to view all added recipes.
4. **Displaying Specific Recipe Details**: Select option `3` to view the details of a specific recipe. You will be prompted to enter the recipe name.
5. **Scaling a Recipe**: Select option `4` to scale a recipe. Enter the name of the recipe and the scaling factor.
6. **Resetting Recipe Scale**: Select option `5` to reset the scale of a recipe. Enter the name of the recipe.
7. **Clearing a Recipe**: Select option `6` to clear a specific recipe. Enter the name of the recipe.
8. **Closing the Application**: Select option `7` to close the application.

## Usage

- Ensure you have the required dependencies installed (such as .NET runtime).
- Run the `Program.cs` file in your preferred C# development environment or compile and execute the code using the .NET CLI.
- Follow the on-screen prompts to interact with the application.

## Notes

- The application uses colors to distinguish different sections of the user interface for better readability.
- Total calories exceeding 300 will trigger a warning message when adding a recipe.
