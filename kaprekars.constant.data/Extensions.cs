using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaprekars.constant.data
{
    public static class Extensions
    {
        private static int ToDescendingOrder(
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
    }
}
