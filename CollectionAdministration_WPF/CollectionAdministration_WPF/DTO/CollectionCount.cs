using System;
using CollectionAdministration_WPF.Enums;

namespace CollectionAdministration_WPF.DTO
{
    public class CollectionCount
    {
        #region Metadata
        public int CollectionCountId { get; set; }

        public DateTime DtCountDate { get; set; }

        public string DayOfCountDate { get; set; }

        public ChurchCommunity ChurchCommunity { get; set; }

        public CollectionRound CollectionRound { get; set; }

        public string Description { get; set; }
        #endregion

        #region Collection Coin
        public string AmtYellowCollectionCoin { get; set; }

        public string AmtGreenCollectionCoin { get; set; }

        public string AmtRedCollectionCoin { get; set; }

        public string AmtBlueCollectionCoin { get; set; }
        #endregion

        #region Euro Bill
        public string AmtFiveEuroBill { get; set; }

        public string AmtTenEuroBill { get; set; }

        public string AmtTwentyEuroBill { get; set; }

        public string AmtFiftyEuroBill { get; set; }

        public string AmtHundredEuroBill { get; set; }

        public string AmtTwoHundredEuroBill { get; set; }
        #endregion

        public string AmtEuroCoinsTotalValue { get; set; }
    }
}
