using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // List to store the history of games
        List<string> history = new List<string>();
        
        // Random object to generate random numbers
        Random random = new Random();
        
        // Boolean flag to control the main loop
        bool exit = false;

        // Main loop that keeps running until 'exit' is true
        while (!exit)
        {
            // Display the menu options
            DisplayMenu();
            
            // Read the user's choice, handle potential null value
            string choice = Console.ReadLine() ?? string.Empty;

            // Switch statement to handle the user's choice
            switch (choice)
            {
                case "1":
                    // Generate an addition problem
                    GenerateProblem(history, random, "+");
                    break;
                case "2":
                    // Generate a subtraction problem
                    GenerateProblem(history, random, "-");
                    break;
                case "3":
                    // Generate a multiplication problem
                    GenerateProblem(history, random, "*");
                    break;
                case "4":
                    // Generate a division problem
                    GenerateDivisionProblem(history, random);
                    break;
                case "5":
                    // Display the history of games
                    DisplayHistory(history);
                    break;
                case "6":
                    // Set the exit flag to true to end the loop
                    exit = true;
                    break;
                default:
                    // Handle invalid options
                    Console.WriteLine("Invalid option. Please choose a number between 1 and 6.");
                    break;
            }
        }
    }

    // Method to display the menu options
    static void DisplayMenu()
    {
        Console.WriteLine("\nMath Game Menu");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. View History");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option (1-6): ");
    }

    // Method to generate and handle addition, subtraction, and multiplication problems
    static void GenerateProblem(List<string> history, Random random, string operation)
    {
        // Generate two random numbers
        int a = random.Next(0, 101);
        int b = random.Next(0, 101);
        int answer = 0;

        // Determine the correct answer based on the operation
        switch (operation)
        {
            case "+":
                answer = a + b;
                break;
            case "-":
                answer = a - b;
                break;
            case "*":
                // Limit the range for multiplication to make it manageable
                a = random.Next(0, 13);
                b = random.Next(0, 13);
                answer = a * b;
                break;
        }

        // Ask the user for the answer to the generated problem
        Console.Write($"What is {a} {operation} {b}? ");
        
        // Read and parse the user's answer
        if (int.TryParse(Console.ReadLine(), out int userAnswer))
        {
            // Determine if the user's answer is correct
            string result = userAnswer == answer ? "Correct" : $"Wrong! The correct answer is {answer}.";
            Console.WriteLine(result);

            // Add the problem and result to the history
            history.Add($"{a} {operation} {b} = {userAnswer} ({result})");
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    // Method to generate and handle division problems
    static void GenerateDivisionProblem(List<string> history, Random random)
    {
        // Generate two random numbers for division
        int b = random.Next(1, 11);
        int c = random.Next(0, 11);
        int a = b * c;

        // Ask the user for the answer to the generated division problem
        Console.Write($"What is {a} / {b}? ");
        
        // Read and parse the user's answer
        if (int.TryParse(Console.ReadLine(), out int userAnswer))
        {
            // Determine if the user's answer is correct
            string result = userAnswer == c ? "Correct" : $"Wrong! The correct answer is {c}.";
            Console.WriteLine(result);

            // Add the problem and result to the history
            history.Add($"{a} / {b} = {userAnswer} ({result})");
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    // Method to display the history of games
    static void DisplayHistory(List<string> history)
    {
        Console.WriteLine("\nGame History:");
        // Iterate through the history list and print each entry
        foreach (string game in history)
        {
            Console.WriteLine(game);
        }
    }
}