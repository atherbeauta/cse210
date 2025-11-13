// CLASS RESPONSIBILITY: Keeps track of the book, chapter, and verse information.
public class Reference
{
    // Design Requirement: Use private member variables (Encapsulation)
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // Used for verse ranges (e.g., 5-6)

    // CONSTRUCTOR 1 (Single Verse): Handles cases like "John 3:16"
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // 0 indicates a single verse
    }

    // CONSTRUCTOR 2 (Verse Range): Handles cases like "Proverbs 3:5-6"
    // Design Requirement: Provide multiple constructors.
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // BEHAVIOR: Gets the formatted display text of the reference.
    // Encapsulation: The Reference class owns the logic of how to format its data.
    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            // Format for single verse: "Book Chapter:Verse" (e.g., "John 3:16")
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            // Format for verse range: "Book Chapter:Verse-EndVerse" (e.g., "Proverbs 3:5-6")
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}