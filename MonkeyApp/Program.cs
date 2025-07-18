using MonkeyApp;
using MonkeyApp.Models;

namespace MonkeyApp;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Monkey Console Application");
            Console.WriteLine("==========================");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            var userInput = Console.ReadLine();
            if (userInput == "4")
                break;

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("\nAll Monkeys:");
                    foreach (var monkey in MonkeyHelper.GetMonkeys())
                    {
                        var count = MonkeyHelper.MonkeyAccessCounts[monkey.Name];
                        Console.WriteLine($"- {monkey.Name} (Accessed: {count} times)");
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Enter monkey name: ");
                    var nameInput = Console.ReadLine();
                    var monkeyByName = MonkeyHelper.GetMonkeyByName(nameInput ?? string.Empty);
                    if (monkeyByName != null)
                    {
                        ShowMonkeyDetails(monkeyByName);
                        Console.WriteLine($"Accessed: {MonkeyHelper.MonkeyAccessCounts[monkeyByName.Name]} times");
                    }
                    else
                    {
                        Console.WriteLine("Monkey not found.");
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;
                case "3":
                    var randomMonkey = MonkeyHelper.GetRandomMonkey();
                    ShowMonkeyDetails(randomMonkey);
                    Console.WriteLine($"Accessed: {MonkeyHelper.MonkeyAccessCounts[randomMonkey.Name]} times");
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// Displays monkey details with ASCII art.
    /// </summary>
    /// <param name="monkey">The monkey to display.</param>
    static void ShowMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine(
            """
   .-***-.
  / .===. \
  \ 6 6 /
  ( \___/ )
___ooo__ooo___
""");
        Console.WriteLine($"Name: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population}");
        Console.WriteLine($"Details: {monkey.Details}");
        if (!string.IsNullOrEmpty(monkey.Image))
        {
            Console.WriteLine($"Image: {monkey.Image}");
        }
    }
}
