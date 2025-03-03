using DSA_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

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
        new Item { Id = 7, Name = "Pen Set", Category = "Stationery", Price = 9.99m },
        new Item { Id = 8, Name = "Keyboard", Category = "Electronics", Price = 49.99m },
        new Item { Id = 9, Name = "Monitor", Category = "Electronics", Price = 199.99m },
        new Item { Id = 10, Name = "Desk Lamp", Category = "Furniture", Price = 39.99m },
        new Item { Id = 11, Name = "Stapler", Category = "Stationery", Price = 12.50m },
        new Item { Id = 12, Name = "Webcam", Category = "Electronics", Price = 89.99m },
        new Item { Id = 13, Name = "Bookshelf", Category = "Furniture", Price = 179.00m },
        new Item { Id = 14, Name = "Highlighters", Category = "Stationery", Price = 6.99m },
        new Item { Id = 15, Name = "Tablet", Category = "Electronics", Price = 349.99m },
        new Item { Id = 16, Name = "Filing Cabinet", Category = "Furniture", Price = 129.95m },
        new Item { Id = 17, Name = "Scissors", Category = "Stationery", Price = 8.49m },
        new Item { Id = 18, Name = "Router", Category = "Electronics", Price = 79.99m },
        new Item { Id = 19, Name = "Coffee Table", Category = "Furniture", Price = 89.99m },
        new Item { Id = 20, Name = "Tape Dispenser", Category = "Stationery", Price = 5.99m },
        new Item { Id = 21, Name = "External HDD", Category = "Electronics", Price = 69.99m },
        new Item { Id = 22, Name = "Armchair", Category = "Furniture", Price = 249.00m },
        new Item { Id = 23, Name = "Sticky Notes", Category = "Stationery", Price = 3.99m },
        new Item { Id = 24, Name = "Headphones", Category = "Electronics", Price = 149.99m },
        new Item { Id = 25, Name = "Sofa", Category = "Furniture", Price = 699.00m },
        new Item { Id = 26, Name = "Binder Clips", Category = "Stationery", Price = 2.99m },
        new Item { Id = 27, Name = "Printer", Category = "Electronics", Price = 129.99m },
        new Item { Id = 28, Name = "Bed Frame", Category = "Furniture", Price = 399.00m },
        new Item { Id = 29, Name = "Calculator", Category = "Stationery", Price = 19.99m },
        new Item { Id = 30, Name = "Smartwatch", Category = "Electronics", Price = 199.99m },
        new Item { Id = 31, Name = "Dining Table", Category = "Furniture", Price = 449.00m },
        new Item { Id = 32, Name = "Index Cards", Category = "Stationery", Price = 1.99m },
        new Item { Id = 33, Name = "USB Hub", Category = "Electronics", Price = 29.99m },
        new Item { Id = 34, Name = "Wardrobe", Category = "Furniture", Price = 299.00m },
        new Item { Id = 35, Name = "Paper Shredder", Category = "Stationery", Price = 89.99m },
        new Item { Id = 36, Name = "Microphone", Category = "Electronics", Price = 59.99m },
        new Item { Id = 37, Name = "Nightstand", Category = "Furniture", Price = 79.99m },
        new Item { Id = 38, Name = "Envelopes", Category = "Stationery", Price = 4.49m },
        new Item { Id = 39, Name = "Graphics Card", Category = "Electronics", Price = 499.99m },
        new Item { Id = 40, Name = "TV Stand", Category = "Furniture", Price = 149.99m },
        new Item { Id = 41, Name = "Whiteboard", Category = "Stationery", Price = 39.99m },
        new Item { Id = 42, Name = "SSD Drive", Category = "Electronics", Price = 89.99m },
        new Item { Id = 43, Name = "Bar Stool", Category = "Furniture", Price = 49.99m },
        new Item { Id = 44, Name = "Push Pins", Category = "Stationery", Price = 1.49m },
        new Item { Id = 45, Name = "Earbuds", Category = "Electronics", Price = 79.99m },
        new Item { Id = 46, Name = "Bookshelf", Category = "Furniture", Price = 129.99m },
        new Item { Id = 47, Name = "Label Maker", Category = "Stationery", Price = 34.99m },
        new Item { Id = 48, Name = "CPU Cooler", Category = "Electronics", Price = 69.99m },
        new Item { Id = 49, Name = "Futon", Category = "Furniture", Price = 199.99m },
        new Item { Id = 50, Name = "File Folders", Category = "Stationery", Price = 6.99m }

    };

        
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
                string sortChoice = Console.ReadLine(); 
                if (sortChoice == "4")
                    return;


                Console.WriteLine("\nChoose sorting algorithm:");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Quick Sort");
                Console.WriteLine("3. Merge Sort");
                Console.Write("Your choice: ");
                string algoChoice = Console.ReadLine();                    


                Item[] sortedItems = ListItems.ToArray();                  


                Comparison<Item> comparison = null;                     

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

                
                if (algoChoice == "1")
                {
                    Stopwatch stpwtch = Stopwatch.StartNew();
                    Sorting.BubbleSort(sortedItems, comparison);
                    stpwtch.Stop();
                    Console.WriteLine($"Bubble sort Execution time: {stpwtch.ElapsedMilliseconds} ms");
                }
                else if (algoChoice == "2")
                {
                    Stopwatch stpwtch = Stopwatch.StartNew();
                    Sorting.QuickSort(sortedItems, 0, sortedItems.Length - 1, comparison);
                    stpwtch.Stop();
                    Console.WriteLine($"QuickSort sort Execution time: {stpwtch.ElapsedMilliseconds} ms");
                }
                else if (algoChoice == "3")
                {
                    Stopwatch stpwtch = Stopwatch.StartNew();
                    Sorting.MergeSort(sortedItems, comparison);
                    stpwtch.Stop();
                    Console.WriteLine($"MergeSort sort Execution time: {stpwtch.ElapsedMilliseconds} ms");
                }
                else
                {
                    Console.WriteLine("Invalid sorting algorithm choice. Press any key...");
                    Console.ReadKey();
                    continue;
                }

                
                Console.WriteLine("\nID  Name                Category       Price");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in sortedItems)
                {
                    Console.WriteLine($"{item.Id,-3} {item.Name,-18} {item.Category,-12} {item.Price,10:C}");
                }

                
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
                   
                    return;
                }
            }
        }

        
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

        
        static void Checkout()
        {
            var cartItems = cart.GetAllItems();
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty! Press any key to return...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Ordered succesfully!.. Press any key to return to main menu...");
            cart.Clear();
            Console.ReadKey();
        }
    }
}




