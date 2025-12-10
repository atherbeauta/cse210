from activity import Activity

# Criterion 1 & 3: Derived class for Running activity
class Running(Activity):
    """
    Represents a running activity. Unique attribute: distance_miles.
    """
    
    def __init__(self, date, length_minutes, distance_miles):
        # Criterion 3: Inheritance - Call the base class constructor
        super().__init__(date, length_minutes)
        # Criterion 3: Unique attribute is NOT stored in the base class
        self._distance_miles = distance_miles
        
    # Criterion 4: Method overriding - Implementation of abstract methods
    def get_distance(self):
        """Returns the stored distance in miles."""
        return self._distance_miles

    def get_speed(self):
        """Calculates and returns the speed (in mph)."""
        # Speed (mph) = Distance (miles) / Length (hours)
        if self._length_minutes == 0:
            return 0.0
        length_hours = self._length_minutes / 60
        return self._distance_miles / length_hours

    def get_pace(self):
        """Calculates and returns the pace (in min per mile)."""
        # Pace (min per mile) = Length (min) / Distance (miles)
        if self._distance_miles == 0:
            return 0.0
        return self._length_minutes / self._distance_miles