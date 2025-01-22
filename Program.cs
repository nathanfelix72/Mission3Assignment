using Mission3Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        // initalize variables and list of objects
        bool game = true;
        List<FoodItem> foodItems = new List<FoodItem>();

        while (game == true)
        {
            // display menu
            Console.WriteLine("What would you like to do? Enter a number");
            Console.WriteLine("1. Add a food item to the list (or update quantity)");
            Console.WriteLine("2. Delete a food item from the list.");
            Console.WriteLine("3. Display the list of food items.");
            Console.WriteLine("4. Exit the program.");

            string user_choice = Console.ReadLine();

            // if the user wants to add a food item or update quantity
            if (user_choice == "1")
            { 
                int additionalQuantity;

                // ask for the name of the food item
                Console.WriteLine();
                Console.WriteLine("Enter the name of the food item: ");
                string foodItemName = Console.ReadLine();

                var existingFoodItem = foodItems.FirstOrDefault(item => item.name == foodItemName);

                // if the food item already exists, update the quantity
                if (existingFoodItem != null)
                {
                    Console.WriteLine($"You already have {foodItemName} in your inventory.");
                    Console.WriteLine($"Current quantity: {existingFoodItem.quantity}");
                    Console.WriteLine("Enter the quantity to add or subtract: ");
                    do
                    {
                        // check if the input is a number
                        if (int.TryParse(Console.ReadLine(), out additionalQuantity))
                        {
                            // check if the quantity is valid to subtract
                            if (existingFoodItem.quantity + additionalQuantity >= 0)
                            {
                                existingFoodItem.quantity += additionalQuantity;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You are trying to subtract too much.");
                                Console.WriteLine("Enter the quantity to add or subtract: ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }
                    } while (true);
                }
                else
                {
                    int quantity;

                    // ask for the category of the food item
                    Console.WriteLine("Enter the category of the food item: ");
                    string category = Console.ReadLine();

                    // ask for the quantity of the food item
                    do
                    {
                        Console.WriteLine("Enter the quantity of the food item: ");

                        // check if the input is a number
                        if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Quantity must be a non-negative number.");
                        }
                    } while (true);

                    // ask for the expiration date of the food item
                    Console.WriteLine("Enter the expiration date of the food item: ");
                    string expirationDate = Console.ReadLine();

                    // create a new food item object and add it to the list
                    FoodItem newFoodItem = new FoodItem(foodItemName, category, quantity, expirationDate);
                    
                    foodItems.Add(newFoodItem);
                }
                Console.WriteLine();
            }
            // if the user wants to delete a food item
            else if (user_choice == "2")
            {
                Console.WriteLine();
                Console.WriteLine("What food item would you like to delete?");
                Console.WriteLine("(" + string.Join(", ", foodItems.Select(f => f.name)) + ")"); // display all current food items
                string foodItemName = Console.ReadLine();

                // check if the food item exists in the list
                var itemToRemove = foodItems.FirstOrDefault(item => item.name == foodItemName);
                if (itemToRemove != null)
                {
                    foodItems.Remove(itemToRemove);
                    Console.WriteLine($"Removed {foodItemName}.");
                }
                else
                {
                    Console.WriteLine("Food item not found.");
                }
                Console.WriteLine();
            }
            // if the user wants to display the list of food items
            else if (user_choice == "3")
            {
                Console.WriteLine();
                // run through each food item and print them out
                foreach (FoodItem foodItem in foodItems)
                {
                    Console.WriteLine(foodItem);
                }
                Console.WriteLine();
            }
            // if the user wants to exit the program
            else if (user_choice == "4")
            {
                game = false;
            }
            // if the user enters an invalid input
            else
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
                Console.WriteLine();
            }
        }
    }
}