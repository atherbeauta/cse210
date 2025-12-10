from activity import Activity

# Criterion 1 & 3: Derived class for Swimming activity
class Swimming(Activity):
    """
    Represents a swimming activity. Unique attribute: number_of_laps.
    """
    
    # Constants for calculation (50 meters per lap converted to miles)
    # 50 meters = 0.0310686 miles (50 / 1609.34)
    _METERS_PER_LAP = 50
    _MILES_PER_METER = 0.000621371 # 1 meter = 0.000621371 miles
    _DISTANCE_PER_LAP_MILES = _METERS_PER_LAP * _MILES_PER_METER

    def __init__(self, date, length_minutes, number_of_laps):
        # Criterion 3: Inheritance - Call the base class constructor
        super().__init__(date, length_minutes)
        # Criterion 3: Unique attribute is NOT stored in the base class
        self._number_of_laps = number_of_laps
    
    # Criterion 4: Method overriding - Implementation of abstract methods
    def get_distance(self):
        """Calculates and returns the distance (in miles)."""
        # Distance (miles) = number_of_laps * distance_per_lap_miles
        return self._number_of_laps * self._DISTANCE_PER_LAP_MILES
    
    def get_speed(self):
        """Calculates and returns the speed (in mph)."""
        # Speed (mph) = Distance (miles) / Length (hours)
        if self._length_minutes == 0:
            return 0.0
        length_hours = self._length_minutes / 60
        return self.get_distance() / length_hours

    def get_pace(self):
        """Calculates and returns the pace (in min per mile)."""
        # Pace (min per mile) = Length (min) / Distance (miles)
        distance = self.get_distance()
        if distance == 0:
            return 0.0
        return self._length_minutes / distance