using CollectionAdministration_WPF.Currency;
using System.ComponentModel;

namespace CollectionAdministration_WPF
{
    public static class CollectionCoinTotalValueCalculator
    {
        public static double CalculateTotalValue(this CollectionCoin collectionCoin, string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                return intValue * GetFactor(collectionCoin);
            }

            return 0;
        }

        private static double GetFactor(CollectionCoin collectionCoin)
        {
            switch (collectionCoin)
            {
                case CollectionCoin.YellowCollectionCoin:
                    return 0.5;
                case CollectionCoin.GreenCollectionCoin:
                    return 0.75;
                case CollectionCoin.RedCollectionCoin:
                    return 1;
                case CollectionCoin.BlueCollectionCoin:
                    return 5;
                default: throw new InvalidEnumArgumentException(nameof(collectionCoin));
            }
        }
    }
}
