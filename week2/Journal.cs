// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I accomplished today that I'm proud of?",
    };

    public void WriteNewEntry()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, _prompts.Count);
        string randomPrompt = _prompts[index];

        Console.WriteLine($"\n{randomPrompt}");
        Console.Write(">> ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._promptText = randomPrompt;
        newEntry._entryText = response;
        newEntry._dateText = DateTime.Now.ToShortDateString();
        newEntry._timeText = DateTime.Now.ToShortTimeString(); 

        _entries.Add(newEntry);
        Console.WriteLine("Entry successfully saved.");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is empty. Write a new entry first!");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("--- End of Journal ---");
    }

    public void SaveJournalToFile()
    {
        Console.Write("\nEnter the filename to save (e.g., myjournal.txt): ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveString());
            }
        }
        Console.WriteLine($"Journal successfully saved to {filename}.");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("\nEnter the filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("\nError: File not found.");
            return;
        }

        _entries.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            string[] separator = new string[] { "~|~" };

            foreach (string line in lines)
            {
                string[] parts = line.Split(separator, StringSplitOptions.None);

                if (parts.Length >= 4) 
                {
                    Entry loadedEntry = new Entry
                    {
                        _dateText = parts[0],
                        _timeText = parts[1], 
                        _promptText = parts[2],
                        _entryText = parts[3]
                    };
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine($"\nJournal successfully loaded from {filename}. Total entries: {_entries.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while loading the file: {ex.Message}");
        }
    }
}