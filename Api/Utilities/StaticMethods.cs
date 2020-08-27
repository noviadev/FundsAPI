using System;

namespace Api.Utilities
{
    public class StaticMethods
    {
        public static decimal RoundNumbers(decimal number)
        {
            var result = Math.Round(number, 2);

            return result;
        }

    }
}
