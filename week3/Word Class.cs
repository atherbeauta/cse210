// CLASS RESPONSIBILITY: Keeps track of a single word and whether it is shown or hidden.
public class Word
{
    // Design Requirement: Use private member variables (Encapsulation)
    private string _text;
    private bool _isHidden = false; // By default, the word is visible

    // CONSTRUCTOR
    public Word(string text)
    {
        _text = text;
    }

    // BEHAVIOR: Sets the word to be hidden.
    public void Hide()
    {
        _isHidden = true;
    }

    // BEHAVIOR: Sets the word to be shown (useful for stretching).
    public void Show()
    {
        _isHidden = false;
    }

    // BEHAVIOR: Checks if the word is currently hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // BEHAVIOR: Gets the display text (the word or underscores).
    // Encapsulation: The Word object decides how it should look based on its internal state.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Hiding a word means replacing it with underscores matching its length.
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}