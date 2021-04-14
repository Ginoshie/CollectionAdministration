using System;
using CollectionAdministration_WPF.Enums;

namespace CollectionAdministration_WPF.DTO
{
    public class CollectionCount
    {
        public int CollectionCountId { get; set; }

        public DateTime DtCountDate { get; set; }

        public string DayOfCountDate { get; set; }

        public ChurchCommunity ChurchCommunity { get; set; }

        public CollectionRound CollectionRound { get; set; }

        public string Description { get; set; }

        public CollectionCoins CollectionCoins { get; set; } = new CollectionCoins();
        
        public EuroBills EuroBills { get; set; } = new EuroBills();
        
        public string AmtEuroCoinsTotalValue { get; set; }
    }
}
