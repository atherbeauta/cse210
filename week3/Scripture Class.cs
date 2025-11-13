using System;
using System.Collections.Generic;
using System.Linq;

// CLASS RESPONSIBILITY: Keeps track of both the reference and the text (as a list of Word objects).
// Can hide words and get the rendered display of the text.
public class Scripture
{
    // Design Requirement: Use private member variables (Encapsulation)
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // CONSTRUCTOR: Accepts a Reference object and the scripture text as a string.
    // Design Requirement: Encapsulate the logic of splitting the text into Word objects.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        
        // Use a simple split function to break the text into individual words
        string[] rawWords = text.Split(new char[] { ' ', ',', ';', '.', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string rawWord in rawWords)
        {
            Word newWord = new Word(rawWord);
            _words.Add(newWord);
        }
    }

    // BEHAVIOR: Hides a specified number of words that are not already hidden.
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // Find all words that are currently NOT hidden.
        List<Word> availableWords = _words.Where(w => !w.IsHidden()).ToList();

        // If there are no words left to hide, exit the method.
        if (availableWords.Count == 0)
        {
            return;
        }

        // Determine how many words to hide (don't hide more than are available)
        int wordsToHide = Math.Min(numberToHide, availableWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            // Pick a random index from the list of available words
            int randomIndex = random.Next(0, availableWords.Count);
            
            // Get the word to hide
            Word wordToHide = availableWords[randomIndex];
            
            // Encapsulation: Delegate the action of hiding to the Word object itself.
            wordToHide.Hide();

            // Remove the word from the available list so we don't hide it again in this loop
            availableWords.RemoveAt(randomIndex);
        }
    }

    // BEHAVIOR: Gets the full display text (Reference + Text with hidden words).
    public string GetDisplayText()
    {
        string fullReference = _reference.GetDisplayText();
        
        // Combine all the Word objects' display text (which includes underscores if hidden)
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));

        return $"{fullReference} {scriptureText}";
    }

    // BEHAVIOR: Checks if all words are hidden.
    public bool IsCompletelyHidden()
    {
        // Checks if ALL words satisfy the IsHidden() condition.
        // Returns true only if the count of visible words is zero.
        return _words.All(w => w.IsHidden());
    }
}