using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    // Private member variables for encapsulation (Criteria 2)
    protected string _name;
    protected string _description;
    protected int _duration; // In seconds

    // Constructor to initialize common attributes
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0; // Will be set by ShowStartingMessage
    }

    // Public method to get the name for the log (Exceeding requirement)
    public string GetName()
    {
        return _name;
    }

    // Common starting message logic (Criteria 5)
    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        // Prompt for duration
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();

        // Input validation loop
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number of seconds.");
            Console.Write("How long, in seconds, would you like for your session? ");
            input = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5); // Pause before starting the main activity
    }

    // Common ending message logic (Criteria 5)
    protected void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(5); // Pause

        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5); // Pause before returning to the main menu
    }

    // Common animation method (Criteria 9)
    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animation[i % animation.Count];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Backspace to erase the character

            i++;
        }
        // This ensures the spinner ends cleanly
        if (seconds > 0)
        {
            Console.Write(" ");
        }
    }

    // Common countdown method
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // \b is used to backspace and overwrite the previous number
            Console.Write(i);
            Thread.Sleep(1000);
            
            // Overwrite the number with spaces equal to the number of digits, then backspace again
            // For example, if i=10, it needs two spaces
            string spaces = new string(' ', i.ToString().Length);
            Console.Write("\b" + spaces + "\b"); 
        }
        Console.Write("\b \b"); // Final cleanup
    }
    
    // Virtual method to be overridden by derived classes (Polymorphism)
    public virtual void RunActivity()
    {
        // This method will be implemented in the derived classes
    }
}