using System;
using System.Threading;

public class BreathingActivity : Activity // Inheritance (Criteria 3)
{
    // Constructor (uses base class constructor)
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {
    }

    // Override the RunActivity method with specific breathing logic (Criteria 6)
    public override void RunActivity()
    {
        ShowStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Breathe In
            Console.Write("\nBreathe in...");
            ShowCountDown(4); // Countdown 4 seconds
            
            // Breathe Out
            Console.Write("\nBreathe out...");
            ShowCountDown(6); // Countdown 6 seconds

            // Check time remaining before the next cycle
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        ShowEndingMessage();
    }
}