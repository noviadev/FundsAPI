using System;

namespace Api.Utilities {
    public class RoundToTwo : IMathsUtilities {
        public decimal RoundAmount(decimal value) {
            return Math.Round(value, 2);
        }
    }
    public class RoundBankers: IMathsUtilities {

        public decimal RoundAmount(decimal value) {
            return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
