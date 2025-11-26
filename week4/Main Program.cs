// CSE210 W04 Foundation Program 1: Abstraction with YouTube Videos
// Main program to demonstrate the Video and Comment classes.

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create 3-4 Video objects (Criterion 5)
        
        // --- Video 1: Programming Tutorial ---
        Video video1 = new Video("C# Basics for Beginners", "Code Master", 900);
        video1.AddComment(new Comment("Alex V.", "Great tutorial! Very clear explanations."));
        video1.AddComment(new Comment("Bia T.", "I wish the screen was a bit larger, but awesome content."));
        video1.AddComment(new Comment("Chuck H.", "Learned more in 15 minutes here than in a whole hour of class."));
        video1.AddComment(new Comment("Diana M.", "First time trying C# and this video helped a lot."));


        // --- Video 2: Travel Vlog ---
        Video video2 = new Video("Hiking the Alps in 4K", "Global Trekker", 1245);
        video2.AddComment(new Comment("Elise R.", "The drone shots are breathtaking! What camera did you use?"));
        video2.AddComment(new Comment("Finn P.", "So jealous! Adding this to my bucket list."));
        video2.AddComment(new Comment("Greg S.", "Did you see the ibex at 5:30? Amazing moment!"));

        // --- Video 3: Cooking Recipe ---
        Video video3 = new Video("Perfect Sourdough Bread Recipe", "Baker's Dozen", 650);
        video3.AddComment(new Comment("Holly K.", "Followed the instructions exactly and it turned out perfect!"));
        video3.AddComment(new Comment("Ian Z.", "Mine was a bit too sticky. Any tips?"));
        video3.AddComment(new Comment("Jasmine L.", "This is the best no-knead recipe I've found. Thank you!"));
        
        
        // 2. Put each video in a list (Criterion 5)
        List<Video> videoList = new List<Video>();
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        
        // 3. Iterate through the list of videos and display details (Criterion 6)
        Console.WriteLine("--- YouTube Video Analysis Report ---");
        
        foreach (Video video in videoList)
        {
            // The DisplayVideoDetails method handles all required output
            video.DisplayVideoDetails();
        }
        
        Console.WriteLine("\n--- End of Report ---");
    }
}