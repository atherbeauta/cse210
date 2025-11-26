// CSE210 W04 Foundation Program 1: Abstraction with YouTube Videos
// This class represents a single comment left on a YouTube video.

public class Comment
{
    // Attributes (Member Variables)
    private string _commenterName;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _commenterName = name;
        _text = text;
    }

    // Behavior: Method to display the comment details
    public void DisplayCommentDetails()
    {
        // Display the commenter's name and the comment text
        Console.WriteLine($"  - Commenter: {_commenterName}");
        Console.WriteLine($"    Text: {_text}");
    }
}