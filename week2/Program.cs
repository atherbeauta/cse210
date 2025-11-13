// Program.cs
using System;
using System.Collections.Generic;

/*
* I exceeded the core requirements by adding the entry TIME feature.
* Each entry is now stored with the exact Date and Time.
* This feature required modifying the Entry.cs and Journal.cs classes 
* to handle _timeText in the writing method, display, and save format.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from file");
            Console.WriteLine("4. Save the journal to file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.WriteNewEntry();
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    myJournal.LoadJournalFromFile();
                    break;
                case "4":
                    myJournal.SaveJournalToFile();
                    break;
                case "5":
                    Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}