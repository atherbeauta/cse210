// Entry.cs
using System;

public class Entry
{
    public string _dateText;
    public string _timeText;    
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"\nDate: {_dateText} - Time: {_timeText}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine("------------------------------------------");
    }

    public string GetSaveString()
    {
        return $"{_dateText}~|~{_timeText}~|~{_promptText}~|~{_entryText}";
    }
}