

namespace Strenkoski_Final
{
    internal class Program
    {
        List<GroceryItem> GroceryList = new List<GroceryItem>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            bool quit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Count of Grocery Items: {0}", GroceryList.Count);
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[A]dd a new item");
                Console.WriteLine("[V]iew the grocery list");
                Console.WriteLine("[M]odify an item");
                Console.WriteLine("[R]emove items");
                Console.WriteLine("[C]lear the list");
                Console.WriteLine("[Q]uit");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        AddItem();
                        break;
                    case ConsoleKey.V:
                        ViewList();
                        break;
                    case ConsoleKey.M:
                        ModifyItems();
                        break;
                    case ConsoleKey.R:
                        RemoveItems();
                        break;
                    case ConsoleKey.C:
                        ClearList();
                        break;
                    case ConsoleKey.Q:
                        quit = true;
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (quit == false);
        }

        private void ClearList()
        {
            //Tell the user this is a destructive action
            //Confirm if they'd like to continue
            //If they do, clear the list

            Console.Clear();
            Console.WriteLine("WARNING! This is a destructive action, Are you sure you want to continue? [y/N]");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                //empty the list
                GroceryList.Clear();
                Console.WriteLine("The Grocery list is now empty.");
            }
            else
            {
                //tell the user it's cancelled
                Console.WriteLine("Action cancelled.");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        private void RemoveItems()
        {
            int currentItem = 0;
            bool keepGoing = true;

            Console.Clear();
            if (GroceryList.Count == 0)
            {
                Console.WriteLine("The grocery list is now empty.");
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Viewing Item {0} of {1}", currentItem + 1, GroceryList.Count);
                    Console.WriteLine();
                    Console.WriteLine("[<]Previous | [>]Next | [R]emove a Item | [Esc] Back to Main Menu");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine();
                    GroceryList[currentItem].Display();

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.P:
                            currentItem = currentItem - 1;

                            if (currentItem < 0)
                            {
                                currentItem = currentItem + 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.N:
                            currentItem = currentItem + 1;

                            if (currentItem == GroceryList.Count)
                            {
                                currentItem = currentItem - 1;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("WARNING! This is a destructive action, Are you sure you want to continue? [y/N]");
                            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                            {
                                GroceryList.RemoveAt(currentItem);

                                if (GroceryList.Count == currentItem)
                                {
                                    currentItem = currentItem - 1;
                                }

                                if (GroceryList.Count == 0)
                                {
                                    Console.WriteLine("The list is empty");
                                    keepGoing = false;

                                }
                            }
                            else
                            {
                                //tell the user it's cancelled
                                Console.WriteLine("Action cancelled.");
                            }
                            break;
                        case ConsoleKey.Escape:
                            keepGoing = false;
                            break;
                    }
                } while (keepGoing == true);
            }


            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        private void ModifyItems()
        {
            int currentItem = 0;
            bool keepGoing = true;

            Console.Clear();
            if (GroceryList.Count == 0)
            {
                Console.WriteLine("The grocery list is empty.");
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Viewing Item {0} of {1}", currentItem + 1, GroceryList.Count);
                    Console.WriteLine();
                    Console.WriteLine("[<]Previous | [>]Next | [M]odify Item | [Esc] Back to Main Menu");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine();
                    GroceryList[currentItem].Display();

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.P:
                            currentItem = currentItem - 1;

                            if (currentItem < 0)
                            {
                                currentItem = currentItem + 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.N:
                            currentItem = currentItem + 1;

                            if (currentItem == GroceryList.Count)
                            {
                                currentItem = currentItem - 1;
                            }
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("WARNING! This is a destructive action, Are you sure you want to continue? [y/N]");
                            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                            {
                                GroceryList[currentItem].Setup();
                            }
                            else
                            {
                                //tell the user it's cancelled
                                Console.WriteLine("Action cancelled.");
                            }
                            break;
                        case ConsoleKey.Escape:
                            keepGoing = false;
                            break;
                    }
                } while (keepGoing == true);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        private void ViewList()
        {
            int currentItem = 0;
            bool keepGoing = true;

            //If there's no items in the list
            //Tell the user the grocery list is empty
            //Otherwise 
            //Let the user cycle through the items in the list

            Console.Clear();
            if (GroceryList.Count == 0)
            {
                Console.WriteLine("The grocery list is empty.");
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Viewing item {0} of {1}", currentItem + 1, GroceryList.Count);
                    Console.WriteLine();
                    Console.WriteLine("[<]Previous | [>]Next | [Esc] Back to Main Menu");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine();
                    GroceryList[currentItem].Display();

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.P:
                            currentItem = currentItem - 1;

                            if (currentItem < 0)
                            {
                                currentItem = currentItem + 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.N:
                            currentItem = currentItem + 1;

                            if (currentItem == GroceryList.Count)
                            {
                                currentItem = currentItem - 1;
                            }
                            break;
                        case ConsoleKey.Escape:
                            keepGoing = false;
                            break;
                    }
                } while (keepGoing == true);
            }


            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        private void AddItem()
        {
            GroceryItem tempGrocery;
            Console.Clear();

            tempGrocery = new GroceryItem();

            tempGrocery.Setup();
            tempGrocery.Display();

            Console.WriteLine("Add this item to the list? [y/N]");

            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                GroceryList.Add(tempGrocery);
                Console.WriteLine("The item {0} was added to the list.", tempGrocery.GetName());
                Console.WriteLine("The list currently has {0} item(s) in it.", GroceryList.Count);
            }
            else
            {
                Console.WriteLine("Action canceled");
            }

            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey(true);
        }
    }
}
