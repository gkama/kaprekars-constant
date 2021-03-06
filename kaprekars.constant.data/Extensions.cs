namespace kaprekars.constant.data
{
    public static class Extensions
    {
        public static string ToAscendingOrder(this string number)
        {
            return number.ToOrder();
        }

        public static string ToDescendingOrder(this string number)
        {
            return number.ToOrder(descending: true);
        }

        private static string ToOrder(
            this string number,
            bool descending = false)
        {
            var numberCharArray = number.ToString()
                .ToCharArray();

            var orderedNumber = descending == false
                ? numberCharArray.OrderBy(x => x)
                : numberCharArray.OrderByDescending(x => x);
            var orderedNumberStr = new string(orderedNumber.ToArray());

            return orderedNumberStr;
        }

        public static bool HasAtleastTwoUniqueDigits(this string number)
        {
            return number.ToString()
                .ToCharArray()
                .Distinct()
                .Count() >= 2;
        }
    }
}
