// CSE 210: Programming with Classes
// W03 Project: Scripture Memorizer Program

using System;
using System.Linq;
using System.Text.RegularExpressions; // Useful for splitting text into words

class Program
{
    static void Main(string[] args)
    {
        // CORE REQUIREMENT: Initialize and store the scripture.
        // We will use Proverbs 3:5-6, which requires the multiple-verse constructor.
        
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);

        // STRETCH CHALLENGE COMMENT:
        // Exceeding Requirements: The program automatically loads the scripture text and reference
        // internally, rather than requiring user input, simplifying the initial setup.

        string userInput = "";

        // Main program loop
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Functional Requirement: Clear the console screen
            Console.Clear();

            // Functional Requirement: Display the complete scripture (reference + text)
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Functional Requirement: Prompt the user
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            // Functional Requirement: Hide a few random words (3 words per turn is a good default)
            scripture.HideRandomWords(3);
        }

        // Final display when the program ends (either by 'quit' or all hidden)
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram ended. Well done!");
    }
}