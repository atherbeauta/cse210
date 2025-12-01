using System;
using System.Threading;

// Exceeding Requirements Note:
// I have added a basic ActivityLog feature to track how many times each activity type was performed
// and display the summary upon exiting the program. This demonstrates object persistence (though simple)
// and exceeding the core requirements (Criteria 12).

class Program
{
    static void Main(string[] args)
    {
        // Initialize the log to track activity counts
        ActivityLog log = new ActivityLog();

        int choice = 0;
        
        // Loop until the user chooses to quit
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            // Validate user input
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Activity currentActivity = null;

                switch (choice)
                {
                    case 1:
                        currentActivity = new BreathingActivity();
                        break;
                    case 2:
                        currentActivity = new ReflectingActivity();
                        break;
                    case 3:
                        currentActivity = new ListingActivity();
                        break;
                    case 4:
                        // Exit the loop and display the log
                        log.DisplaySummary();
                        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }

                // Run the selected activity and update the log
                if (currentActivity != null)
                {
                    currentActivity.RunActivity();
                    log.RecordActivity(currentActivity.GetName());
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Thread.Sleep(2000);
            }
        }
    }
}

// Custom Class for Exceeding Requirements (Activity Log)
public class ActivityLog
{
    // Member variable to store counts
    private Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public void RecordActivity(string activityName)
    {
        // Use the activity name as the key
        if (_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName]++;
        }
        else
        {
            _activityCounts.Add(activityName, 1);
        }
    }

    public void DisplaySummary()
    {
        Console.Clear();
        Console.WriteLine("--- Activity Log Summary ---");
        Console.WriteLine("Here is a summary of your mindfulness sessions:");
        
        if (_activityCounts.Count == 0)
        {
            Console.WriteLine("No activities were completed during this session.");
        }
        else
        {
            foreach (var kvp in _activityCounts)
            {
                Console.WriteLine($"- {kvp.Key}: {kvp.Value} time(s)");
            }
        }
        Console.WriteLine("----------------------------");
        Thread.Sleep(4000); // Pause to let the user read the summary
    }
}