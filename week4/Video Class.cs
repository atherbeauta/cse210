// CSE210 W04 Foundation Program 1: Abstraction with YouTube Videos
// This class represents a YouTube video and holds a list of comments.

public class Video
{
    // Attributes (Member Variables)
    private string _title;
    private string _author;
    private int _lengthSeconds;
    
    // Composition: A list to hold Comment objects
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        
        // Initialize the list of comments
        _comments = new List<Comment>();
    }

    // Behavior: Adds a comment to the video's list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Behavior: Returns the total number of comments
    public int GetNumberOfComments()
    {
        // Returns the length of the internal list, meeting criterion 4
        return _comments.Count;
    }

    // Behavior: Displays all video information and then iterates through all comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine($"Video: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSeconds} seconds");
        Console.WriteLine($"Total Comments: {GetNumberOfComments()}");
        Console.WriteLine("----------------------------------------");
        
        // Iterate through the list of comments and display each one
        foreach (Comment comment in _comments)
        {
            comment.DisplayCommentDetails();
        }
        Console.WriteLine("========================================");
    }
}