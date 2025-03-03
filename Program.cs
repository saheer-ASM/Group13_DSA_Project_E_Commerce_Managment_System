using DSA_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSA_Project
{
    class Program
    {

        static List<Item> ListItems = new List<Item>
    {
        new Item { Id = 1, Name = "Laptop", Category = "Electronics", Price = 450.00m },
        new Item { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25.99m },
        new Item { Id = 3, Name = "Office Chair", Category = "Furniture", Price = 299.99m },
        new Item { Id = 4, Name = "Notebook", Category = "Stationery", Price = 4.99m },
        new Item { Id = 5, Name = "Smartphone", Category = "Electronics", Price = 799.99m },
        new Item { Id = 6, Name = "Desk", Category = "Furniture", Price = 149.99m },
        new Item { Id = 7, Name = "Pen Set", Category = "Stationery", Price = 9.99m }

    };

        // Shopping cart instance.
        static ShoppingCart cart = new ShoppingCart();

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== E-COMMERCE ORDER MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Browse Items");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BrowseItems();
                        break;
                    case "2":
                        ViewCart();
                        break;
                    case "3":
                        Checkout();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Browse items with sorting and add-to-cart options.
        static void BrowseItems()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sort items by:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Category");
                Console.WriteLine("3. Price");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose sorting criterion: ");
                string sortChoice = Console.ReadLine(); //getting choice for sorting name or category or price
                if (sortChoice == "4")
                    return;


                Console.WriteLine("\nChoose sorting algorithm:");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Quick Sort");
                Console.WriteLine("3. Merge Sort");
                Console.Write("Your choice: ");
                string algoChoice = Console.ReadLine();                     //getting sorting algorithm for sorting


                Item[] sortedItems = ListItems.ToArray();                  // Create an array copy of the items list.


                Comparison<Item> comparison = null;                     // Choose the correct comparison method.

                if (sortChoice == "1")
                    comparison = Sorting.CompareByName;
                else if (sortChoice == "2")
                    comparison = Sorting.CompareByCategory;
                else if (sortChoice == "3")
                    comparison = Sorting.CompareByPrice;
                else
                {
                    Console.WriteLine("Invalid sorting criterion. Press any key...");
                    Console.ReadKey();
                    continue;
                }

                // Apply the chosen sorting algorithm.
                if (algoChoice == "1")
                {
                    Sorting.BubbleSort(sortedItems, comparison);
                }
                else if (algoChoice == "2")
                {
                    Sorting.QuickSort(sortedItems, 0, sortedItems.Length - 1, comparison);
                }
                else if (algoChoice == "3")
                {
                    Sorting.MergeSort(sortedItems, comparison);
                }
                else
                {
                    Console.WriteLine("Invalid sorting algorithm choice. Press any key...");
                    Console.ReadKey();
                    continue;
                }

                // Display the sorted items.
                Console.WriteLine("\nID  Name                Category       Price");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in sortedItems)
                {
                    Console.WriteLine($"{item.Id,-3} {item.Name,-18} {item.Category,-12} {item.Price,10:C}");
                }

                // Add to cart flow.
                Console.Write("\nEnter item ID to add to cart (0 to go back): ");
                if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
                {
                    var selectedItem = sortedItems.FirstOrDefault(x => x.Id == id);
                    if (selectedItem != null)
                    {
                        Console.Write("Enter quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                        {
                            cart.AddItem(new ShoppingCartItem { Product = selectedItem, Quantity = qty });
                            Console.WriteLine("Item added to cart! Press any key...");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity! Press any key...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item ID not found! Press any key...");
                    }
                    Console.ReadKey();
                }
                else
                {
                    // Return to main menu.
                    return;
                }
            }
        }

        // View items in the shopping cart.
        static void ViewCart()
        {
            Console.Clear();
            var cartItems = cart.GetAllItems();
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty!");
            }
            else
            {
                Console.WriteLine("Items in your cart:");
                Console.WriteLine("Product              Quantity     Price       Total");
                Console.WriteLine("-------------------------------------------------------------");
                decimal grandTotal = 0;
                foreach (var ci in cartItems)
                {
                    decimal total = ci.Product.Price * ci.Quantity;
                    Console.WriteLine($"{ci.Product.Name,-20} {ci.Quantity,-10} {ci.Product.Price,10:C} {total,12:C}");
                    grandTotal += total;
                }
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"Grand Total: {grandTotal,40:C}");
            }
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        // Checkout: save the order details to a file and clear the cart.
        static void Checkout()
        {
            var cartItems = cart.GetAllItems();
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty! Press any key to return...");
                Console.ReadKey();
                return;
            }

            string filename = $"Order_{DateTime.Now:yyyyMMddHHmmss}.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"Order Date: {DateTime.Now}");
                writer.WriteLine("Items Purchased:");
                foreach (var ci in cartItems)
                {
                    writer.WriteLine($"{ci.Product.Name} x{ci.Quantity} @ {ci.Product.Price:C}");
                }
                writer.WriteLine("\nThank you for your purchase!");
            }

            Console.WriteLine($"Order saved to {filename}. Press any key to return to main menu...");
            cart.Clear();
            Console.ReadKey();
        }
    }
}




