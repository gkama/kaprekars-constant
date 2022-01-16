

namespace kaprekars.constant.data
{
    public class Routine
    {
        public int Number { get; set; }

        public readonly int Ascending;
        public readonly int Descending;
        public readonly int Result;
        public readonly string? Subtraction;

        public Routine(int number)
        {
            Number = number;

            // Calculations
            Ascending = Number.ToAscendingOrder();
            Descending = Number.ToDescendingOrder();
            Result = Ascending - Descending;
            Subtraction = $"{Ascending} - {Descending} = {Result}";
        }
    }
}
