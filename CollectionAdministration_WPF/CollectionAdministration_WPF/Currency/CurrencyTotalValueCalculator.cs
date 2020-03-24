using System.ComponentModel;

namespace CollectionAdministration_WPF.Currency
{
    public static class CurrencyTotalValueCalculator
    {
        public static double CalculateTotalValue(this EuroBill currency, int value)
        {
            return value * GetFactor(currency);
        }

        private static double GetFactor(EuroBill currency)
        {
            switch (currency)
            {
                case EuroBill.FiveEuroBill:
                    return 5;
                case EuroBill.TenEuroBill:
                    return 10;
                case EuroBill.TwentyEuroBill:
                    return 20;
                case EuroBill.FiftyEuroBill:
                    return 50;
                case EuroBill.HundredEuroBill:
                    return 100;
                case EuroBill.TwoHundredEuroBill:
                    return 200;
                default: throw new InvalidEnumArgumentException(nameof(currency));
            }
        }
    }
}
