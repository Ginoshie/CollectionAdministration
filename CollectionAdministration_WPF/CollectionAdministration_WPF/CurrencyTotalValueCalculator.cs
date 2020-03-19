using System.ComponentModel;

namespace CollectionAdministration_WPF
{
    public static class CurrencyTotalValueCalculator
    {
        public static double CalculateTotalValue(this Currency currency, int value)
        {
            return value * GetFactor(currency);
        }

        private static double GetFactor(Currency currency)
        {
            switch (currency)
            {
                case Currency.FiveEuroBill:
                    return 5;
                case Currency.TenEuroBill:
                    return 10;
                case Currency.TwentyEuroBill:
                    return 20;
                case Currency.FiftyEuroBill:
                    return 50;
                case Currency.HundredEuroBill:
                    return 100;
                case Currency.TwoHundredEuroBill:
                    return 200;
                default: throw new InvalidEnumArgumentException(nameof(currency));
            }
        }
    }
}
