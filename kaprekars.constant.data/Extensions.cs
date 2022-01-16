namespace kaprekars.constant.data
{
    public static class Extensions
    {
        public static int ToAscendingOrder(this int number)
        {
            return number.ToOrder();
        }

        public static int ToDescendingOrder(this int number)
        {
            return number.ToOrder(descending: true);
        }

        private static int ToOrder(
            this int number,
            bool descending = false)
        {
            var numberCharArray = number.ToString()
                .ToCharArray();

            var orderedNumber = descending == false
                ? numberCharArray.OrderBy(x => x)
                : numberCharArray.OrderByDescending(x => x);
            var orderedNumberStr = new string(orderedNumber.ToArray());

            return int.Parse(orderedNumberStr);
        }

        public static bool HasAtleastTwoUniqueDigits(this int number)
        {
            return number.ToString()
                .ToCharArray()
                .Distinct()
                .Count() >= 2;
        }
    }
}
