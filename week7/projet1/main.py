from running import Running
from swimming import Swimming
from cycling import Cycling

def main():
    """
    Main program to demonstrate polymorphism and inheritance.
    Creates activity objects, puts them in a list, and calls the summary method.
    (Criterion 6: Functionality)
    """
    print("--- Exercise Tracking Report ---")

    # 1. Create instances of each type of activity
    
    # Running: 30 minutes, 3.0 miles
    running_activity = Running("15 Dec 2025", 30, 3.0) 
    
    # Swimming: 45 minutes, 20 laps (50m pool -> ~0.62 miles)
    swimming_activity = Swimming("16 Dec 2025", 45, 20)
    
    # Cycling: 60 minutes, 15.0 mph average speed
    cycling_activity = Cycling("17 Dec 2025", 60, 15.0) 

    # 2. Put each of these activities in the same list
    # The list is implicitly a list of the base class type (Activity)
    activities = [
        running_activity,
        swimming_activity,
        cycling_activity,
    ]

    print(f"\nTotal Activities Logged: {len(activities)}\n")

    # 3. Iterate through this list and call the GetSummary method
    for activity in activities:
        # Polymorphism in action: 
        # The same GetSummary method calls the correct GetDistance, GetSpeed, 
        # and GetPace methods defined in the specific derived class.
        summary = activity.get_summary()
        print(summary)
        
    print("\n------------------------------")


if __name__ == "__main__":
    main()