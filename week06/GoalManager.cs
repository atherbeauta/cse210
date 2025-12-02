// CLASS RESPONSIBILITY: Manages the collection of Goal objects and the user's score.
// Encapsulation and Abstraction are key here.
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq; // Needed for List.FindIndex

public class GoalManager
{
    // Encapsulation: Private member variables for the core application state.
    private List<Goal> _goals;
    private int _score;

    // Constructor: Initializes the state.
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // BEHAVIOR: Displays the current score.
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score} points.\n");
    }

    // BEHAVIOR: Displays the main menu.
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }

    // BEHAVIOR: Handles the creation of a new goal based on user input.
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus value for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("\nInvalid goal type.");
                break;
        }
        Console.WriteLine($"Goal '{name}' created successfully.");
    }

    // BEHAVIOR: Lists all goals with their status and details.
    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals currently listed. Please create one first.");
            return;
        }

        Console.WriteLine("\nThe Goals are:");
        // Abstraction: Calls GetStringRepresentation() without knowing the internal state logic of each Goal type.
        for (int i = 0; i < _goals.Count; i++)
        {
            // Use the index + 1 for user-friendly display numbering.
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
        Console.WriteLine();
    }

    // BEHAVIOR: Handles the recording of an event, which triggers Polymorphism.
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record events for. Please create one first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        // Display the list, but only showing the basic name for selection clarity.
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= _goals.Count)
        {
            // The user input is 1-based, so convert to 0-based index.
            Goal goalToRecord = _goals[choiceIndex - 1];

            // Polymorphism: Calling RecordEvent() executes the method specific to Simple, Eternal, or Checklist Goal.
            int pointsGained = goalToRecord.RecordEvent();
            
            // Update the score based on the polymorphic return value.
            _score += pointsGained;
            
            // Check for level up after scoring points (Exceeds Requirement)
            CheckLevelUp();

            if (pointsGained > 0)
            {
                Console.WriteLine($"\nCongratulations! You have earned {pointsGained} points.");
            }
            // Display the new total score.
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("\nInvalid selection.");
        }
    }

    // BEHAVIOR: Saves the goals and score to a text file.
    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            // 1. Save the score on the first line.
            output.WriteLine(_score);

            // 2. Save each goal using its specific serialization format.
            // Abstraction: Each goal is responsible for providing its own save string.
            foreach (Goal goal in _goals)
            {
                // Polymorphism: GetDetailsString() provides the serialization format specific to the derived class.
                output.WriteLine(goal.GetDetailsString());
            }
        }
        Console.WriteLine($"Goals successfully saved to {filename}.");
    }

    // BEHAVIOR: Loads the goals and score from a text file.
    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename of the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("\nError: File not found.");
            return;
        }

        // Clear existing goals before loading new ones.
        _goals.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);

            // 1. Load the score from the first line.
            if (lines.Length > 0)
            {
                if (int.TryParse(lines[0], out int loadedScore))
                {
                    _score = loadedScore;
                }
                else
                {
                    Console.WriteLine("Warning: Could not read score from file. Setting score to 0.");
                    _score = 0;
                }
            }
            
            // 2. Load the goals from the rest of the lines.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                
                // Parts: [0]Type | [1]Name | [2]Description | [3]Points | [4]State/Bonus | [5]Target | [6]Completed
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        // SimpleGoal|Name|Description|Points|isComplete
                        bool isComplete = bool.Parse(parts[4]);
                        // Use the new loading constructor.
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                        break;
                    
                    case "EternalGoal":
                        // EternalGoal|Name|Description|Points (No extra state needed)
                        _goals.Add(new EternalGoal(name, description, points));
                        break;
                        
                    case "ChecklistGoal":
                        // ChecklistGoal|Name|Description|Points|Bonus|Target|AmountCompleted
                        int bonus = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        
                        // Use the overload constructor for loading.
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                        break;
                }
            }
            Console.WriteLine($"\nGoals successfully loaded from {filename}. Total score: {_score}");
        }
        catch (Exception ex)
        {
            // Good practice: Catch exceptions during file operations (Exceeds Requirement)
            Console.WriteLine($"\nAn error occurred while loading the file: {ex.Message}");
            Console.WriteLine("The goals list has been cleared to prevent corruption.");
            _goals.Clear(); // Clear any partially loaded data
            _score = 0; // Reset score
        }
    }
    
    // EXCEEDS REQUIREMENTS: Added a leveling system.
    public void CheckLevelUp()
    {
        // Simple leveling system: level up every 1000 points.
        int currentLevel = _score / 1000;
        
        // This is a very simple check, a more robust system would track the previous level.
        if (_score > 0 && _score % 1000 == 0)
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine($"*** CONGRATULATIONS! You reached Level {currentLevel}! ***");
            Console.WriteLine("**************************************************");
        }
    }
}