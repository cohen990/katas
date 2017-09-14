namespace LeapYear
{
    public class Year
    {
        private readonly int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            return DivisibleBy(4) && !(DivisibleBy(100) && NotDivisibleBy(400));
        }

        private bool NotDivisibleBy(int divisor)
        {
            return _year % divisor != 0;
        }

        private bool DivisibleBy(int divisor)
        {
            return _year % divisor == 0;
        }
    }
}
