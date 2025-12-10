from activity import Activity

# Criterion 1 & 3: Derived class for Cycling activity
class Cycling(Activity):
    """
    Represents a stationary cycling activity. Unique attribute: average_speed_mph.
    """

    def __init__(self, date, length_minutes, average_speed_mph):
        # Criterion 3: Inheritance - Call the base class constructor
        super().__init__(date, length_minutes)
        # Criterion 3: Unique attribute is NOT stored in the base class
        self._average_speed_mph = average_speed_mph

    # Criterion 4: Method overriding - Implementation of abstract methods
    def get_distance(self):
        """Calculates and returns the distance (in miles)."""
        # Distance (miles) = Speed (mph) * Length (hours)
        length_hours = self._length_minutes / 60
        return self._average_speed_mph * length_hours

    def get_speed(self):
        """Returns the stored average speed (in mph)."""
        return self._average_speed_mph

    def get_pace(self):
        """Calculates and returns the pace (in min per mile)."""
        # Pace (min per mile) = 60 / Speed (mph)
        speed = self.get_speed()
        if speed == 0:
            return 0.0
        return 60 / speed