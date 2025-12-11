from abc import ABC, abstractmethod

# Criterion 1: Abstraction - Base class for all activities
class Activity(ABC):
    """
    Base class representing any physical activity.
    It contains shared attributes (date, length) and defines abstract methods for calculation.
    """

    def __init__(self, date, length_minutes):
        # Criterion 2: Encapsulation - Protected member variables
        self._date = date
        self._length_minutes = length_minutes

    def get_length_minutes(self):
        """Returns the length of the activity in minutes."""
        return self._length_minutes
    
    # Criterion 4: Abstract methods to be overridden (Polymorphism)
    @abstractmethod
    def get_distance(self):
        """Calculates and returns the distance covered (in miles)."""
        pass

    @abstractmethod
    def get_speed(self):
        """Calculates and returns the speed (in mph)."""
        pass

    @abstractmethod
    def get_pace(self):
        """Calculates and returns the pace (in minutes per mile)."""
        pass

    # Criterion 5: Polymorphism - Single GetSummary method in the base class 
    # that uses the virtual methods implemented by derived classes.
    def get_summary(self):
        """
        Generates a formatted summary string.
        Format: "03 Nov 2022 Running (30 min): Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile"
        """
        
        # Get the name of the derived class (e.g., "Running")
        activity_type = self.__class__.__name__

        # Calls the specific overridden methods
        distance = self.get_distance()
        speed = self.get_speed()
        pace = self.get_pace()

        # Format the summary string using miles/mph/min per mile
        summary = (
            f"{self._date} {activity_type} ({self._length_minutes} min): "
            f"Distance {distance:.1f} miles, Speed {speed:.1f} mph, "
            f"Pace: {pace:.1f} min per mile"
        )
        return summary