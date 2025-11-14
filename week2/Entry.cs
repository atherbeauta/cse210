// Entry.cs
using System;

public class Entry
{
    // CRITICAL FIX: Member variables must be private (Encapsulation).
    // They are now accessed using the Public Properties defined below.
    private string _dateText;
    private string _timeText;    
    private string _promptText;
    private string _entryText;

    // Public Properties for accessing the private fields.
    public string DateText { get { return _dateText; } set { _dateText = value; } }
    public string TimeText { get { return _timeText; } set { _timeText = value; } }
    public string PromptText { get { return _promptText; } set { _promptText = value; } }
    public string EntryText { get { return _entryText; } set { _entryText = value; } }

    public void Display()
    {
        // Use the private fields directly inside the class
        Console.WriteLine($"\nDate: {_dateText} - Time: {_timeText}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine("------------------------------------------");
    }

    public string GetSaveString()
    {
        // Use the private fields directly inside the class
        return $"{_dateText}~|~{_timeText}~|~{_promptText}~|~{_entryText}";
    }
}