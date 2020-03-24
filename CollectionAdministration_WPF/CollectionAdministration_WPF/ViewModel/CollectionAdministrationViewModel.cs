using CollectionAdministration_WPF.Currency;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CollectionAdministration_WPF
{
    public class CollectionAdministrationViewModel : INotifyPropertyChanged
    {
        #region Fields

        #region Metadata
        private DateTime dtCountDate;

        private string dayOfCountDate;

        private ChurchCommunity churchCommunity;

        private CollectionRound collectionRound;

        private string description;
        #endregion

        #region Collection Coin
        private int amtYellowCollectionCoin;

        private double amtYellowCollectionCoinTotalValue;

        private int amtGreenCollectionCoin;

        private double amtGreenCollectionCoinTotalValue;

        private int amtRedCollectionCoin;

        private double amtRedCollectionCoinTotalValue;

        private int amtBlueCollectionCoin;

        private double amtBlueCollectionCoinTotalValue;

        private double amtCollectionCoinsTotalValue;
        #endregion

        #region Euro Bill
        private int amtFiveEuroBill;

        private double amtFiveEuroBillTotalValue;

        private int amtTenEuroBill;

        private double amtTenEuroBillTotalValue;

        private int amtTwentyEuroBill;

        private double amtTwentyEuroBillTotalValue;

        private int amtFiftyEuroBill;

        private double amtFiftyEuroBillTotalValue;

        private int amtHundredEuroBill;

        private double amtHundredEuroBillTotalValue;

        private int amtTwoHundredEuroBill;

        private double amtTwoHundredEuroBillTotalValue;

        private double amtEuroBillsTotalValue;
        #endregion

        private double amtEuroCoinsTotalValue;

        private double amtCollectionTotalValue;
        #endregion

        public CollectionAdministrationViewModel()
        {
            DtCountDate = DateTime.Today;

            SetDefaultDescription();

            SaveCountResult = new CommandHandler(() => ExecuteSaveCountResultFlow());
        }

        #region Properties

        #region Metadata
        public DateTime DtCountDate
        {
            get => dtCountDate;
            set
            {
                if (dtCountDate == value)
                {
                    return;
                }

                dtCountDate = value;

                UpdateDayOfCountDate();
            }
        }

        public string DayOfCountDate
        {
            get => dayOfCountDate;

            private set
            {
                if (dayOfCountDate == value)
                {
                    return;
                }

                dayOfCountDate = value;

                OnPropertyChanged();
            }
    }

        public ChurchCommunity ChurchCommunity { get => churchCommunity; set => churchCommunity = value; }

        public CollectionRound CollectionRound
        {
            get => collectionRound;

            set
            {
                if (collectionRound == value)
                {
                    return;
                }

                collectionRound = value;

                SetDefaultDescription();
            }
        }

        public string Description
        {
            get => description;

            set
            {
                if (description == value)
                {
                    return;
                }

                description = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Collection Coin
        public int AmtYellowCollectionCoin
        {
            get => amtYellowCollectionCoin;

            set
            {
                if (amtYellowCollectionCoin == value)
                {
                    return;
                }

                amtYellowCollectionCoin = value;

                UpdateCollectionCoinTotalValue(CollectionCoin.YellowCollectionCoin);
            }
        }

        public double AmtYellowCollectionCoinTotalValue
        {
            get => amtYellowCollectionCoinTotalValue;

            private set
            {
                if (amtYellowCollectionCoinTotalValue == value)
                {
                    return;
                }

                amtYellowCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtGreenCollectionCoin
        {
            get => amtGreenCollectionCoin;

            set
            {
                if (amtGreenCollectionCoin == value)
                {
                    return;
                }

                amtGreenCollectionCoin = value;

                UpdateCollectionCoinTotalValue(CollectionCoin.GreenCollectionCoin);
            }
        }

        public double AmtGreenCollectionCoinTotalValue
        {
            get => amtGreenCollectionCoinTotalValue;

            private set
            {
                if (amtGreenCollectionCoinTotalValue == value)
                {
                    return;
                }

                amtGreenCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtRedCollectionCoin
        {
            get => amtRedCollectionCoin;

            set
            {
                if (amtRedCollectionCoin == value)
                {
                    return;
                }

                amtRedCollectionCoin = value;

                UpdateCollectionCoinTotalValue(CollectionCoin.RedCollectionCoin);
            }
        }

        public double AmtRedCollectionCoinTotalValue
        {
            get => amtRedCollectionCoinTotalValue;

            private set
            {
                if (amtRedCollectionCoinTotalValue == value)
                {
                    return;
                }

                amtRedCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtBlueCollectionCoin
        {
            get => amtBlueCollectionCoin;

            set
            {
                if (amtBlueCollectionCoin == value)
                {
                    return;
                }

                amtBlueCollectionCoin = value;

                UpdateCollectionCoinTotalValue(CollectionCoin.BlueCollectionCoin);
            }
        }

        public double AmtBlueCollectionCoinTotalValue
        {
            get => amtBlueCollectionCoinTotalValue;

            private set
            {
                if (amtBlueCollectionCoinTotalValue == value)
                {
                    return;
                }

                amtBlueCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtCollectionCoinsTotalValue
        {
            get => amtCollectionCoinsTotalValue;

            set
            {
                if(amtCollectionCoinsTotalValue == value)
                {
                    return;
                }

                amtCollectionCoinsTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion
        
        #region Euro Bill
        public int AmtFiveEuroBill
        {
            get => amtFiveEuroBill;

            set
            {
                if (amtFiveEuroBill == value)
                {
                    return;
                }

                amtFiveEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.FiveEuroBill);
            }
        }

        public double AmtFiveEuroBillTotalValue
        {
            get => amtFiveEuroBillTotalValue;

            private set
            {
                if (amtFiveEuroBillTotalValue == value)
                {
                    return;
                }

                amtFiveEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtTenEuroBill
        {
            get => amtTenEuroBill;

            set
            {
                if (amtTenEuroBill == value)
                {
                    return;
                }

                amtTenEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.TenEuroBill);
            }
        }

        public double AmtTenEuroBillTotalValue
        {
            get => amtTenEuroBillTotalValue;

            private set
            {
                if (amtTenEuroBillTotalValue == value)
                {
                    return;
                }

                amtTenEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtTwentyEuroBill
        {
            get => amtTwentyEuroBill;

            set
            {
                if (amtTwentyEuroBill == value)
                {
                    return;
                }

                amtTwentyEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.TwentyEuroBill);
            }
        }

        public double AmtTwentyEuroBillTotalValue
        {
            get => amtTwentyEuroBillTotalValue;

            private set
            {
                if (amtTenEuroBillTotalValue == value)
                {
                    return;
                }

                amtTwentyEuroBillTotalValue = value;
                
                OnPropertyChanged();
            }
        }
        
        public int AmtFiftyEuroBill
        {
            get => amtFiftyEuroBill;

            set
            {
                if (amtFiftyEuroBill == value)
                {
                    return;
                }

                amtFiftyEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.FiftyEuroBill);
            }
        }

        public double AmtFiftyEuroBillTotalValue
        {
            get => amtFiftyEuroBillTotalValue;

            private set
            {
                if (amtFiftyEuroBillTotalValue == value)
                {
                    return;
                }

                amtFiftyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtHundredEuroBill
        {
            get => amtHundredEuroBill;

            set
            {
                if (amtHundredEuroBill == value)
                {
                    return;
                }

                amtHundredEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.HundredEuroBill);
            }
        }

        public double AmtHundredEuroBillTotalValue
        {
            get => amtHundredEuroBillTotalValue;

            set
            {
                if (amtHundredEuroBillTotalValue == value)
                {
                    return;
                }

                amtHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public int AmtTwoHundredEuroBill
        {
            get => amtTwoHundredEuroBill;

            set
            {
                if (amtTwoHundredEuroBill == value)
                {
                    return;
                }

                amtTwoHundredEuroBill = value;

                UpdateEuroBillTotalValue(EuroBill.TwoHundredEuroBill);
            }
        }

        public double AmtTwoHundredEuroBillTotalValue
        {
            get => amtTwoHundredEuroBillTotalValue;

            private set
            {
                if (amtTwoHundredEuroBillTotalValue == value)
                {
                    return;
                }

                amtTwoHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtEuroBillsTotalValue
        {
            get => amtEuroBillsTotalValue;
            set
            {
                if(amtEuroBillsTotalValue == value)
                {
                    return;
                }

                amtEuroBillsTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion
        
        public double AmtEuroCoinsTotalValue
        {
            get => amtEuroCoinsTotalValue;

            set
            {
                if (amtEuroCoinsTotalValue == value)
                {
                    return;
                }

                amtEuroCoinsTotalValue = value;

                UpdateCollectionTotalValue();
            }
        }

        public double AmtCollectionTotalValue
        {
            get => amtCollectionTotalValue;

            set
            {
                if(amtCollectionTotalValue == value)
                {
                    return;
                }

                amtCollectionTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Update textbox text methods

        #region Update TotalValue methods
        private void UpdateCollectionCoinTotalValue(CollectionCoin collectionCoin)
        {
            switch (collectionCoin)
            {
                case CollectionCoin.YellowCollectionCoin:
                    AmtYellowCollectionCoinTotalValue = collectionCoin.CalculateTotalValue(AmtYellowCollectionCoin);
                    break;
                case CollectionCoin.GreenCollectionCoin:
                    AmtGreenCollectionCoinTotalValue = collectionCoin.CalculateTotalValue(AmtGreenCollectionCoin);
                    break;
                case CollectionCoin.RedCollectionCoin:
                    AmtRedCollectionCoinTotalValue = collectionCoin.CalculateTotalValue(AmtRedCollectionCoin);
                    break;
                case CollectionCoin.BlueCollectionCoin:
                    AmtBlueCollectionCoinTotalValue = collectionCoin.CalculateTotalValue(AmtBlueCollectionCoin);
                    break;
                default: throw new InvalidEnumArgumentException(nameof(collectionCoin));
            }

            UpdateCollectionCoinsTotalValue();

            UpdateCollectionTotalValue();
        }

        private void UpdateEuroBillTotalValue(EuroBill euroBill)
        {
            switch (euroBill)
            {
                case EuroBill.FiveEuroBill:
                    AmtFiveEuroBillTotalValue = euroBill.CalculateTotalValue(AmtFiveEuroBill);
                    break;
                case EuroBill.TenEuroBill:
                    AmtTenEuroBillTotalValue = euroBill.CalculateTotalValue(AmtTenEuroBill);
                    break;
                case EuroBill.TwentyEuroBill:
                    AmtTwentyEuroBillTotalValue = euroBill.CalculateTotalValue(AmtTwentyEuroBill);
                    break;
                case EuroBill.FiftyEuroBill:
                    AmtFiftyEuroBillTotalValue = euroBill.CalculateTotalValue(AmtFiftyEuroBill);
                    break;
                case EuroBill.HundredEuroBill:
                    AmtHundredEuroBillTotalValue = euroBill.CalculateTotalValue(AmtHundredEuroBill);
                    break;
                case EuroBill.TwoHundredEuroBill:
                    AmtTwoHundredEuroBillTotalValue = euroBill.CalculateTotalValue(AmtTwoHundredEuroBill);
                    break;
                default: throw new InvalidEnumArgumentException(nameof(euroBill));
            }

            UpdateEuroBillsTotalValue();

            UpdateCollectionTotalValue();
        }

        private void UpdateCollectionCoinsTotalValue()
        {
            AmtCollectionCoinsTotalValue = SumCollectionCoinTotalValues();
        }

        private void UpdateEuroBillsTotalValue()
        {
            AmtEuroBillsTotalValue = SumEuroBillTotalValues();
        }

        private void UpdateCollectionTotalValue()
        {
            AmtCollectionTotalValue = 
                AmtCollectionCoinsTotalValue + 
                AmtEuroBillsTotalValue + 
                AmtEuroCoinsTotalValue
            ;
        }
        
        private double SumCollectionCoinTotalValues()
        {
            return 
                AmtYellowCollectionCoinTotalValue + 
                AmtGreenCollectionCoinTotalValue + 
                AmtRedCollectionCoinTotalValue + 
                AmtBlueCollectionCoinTotalValue
            ;
        }

        private double SumEuroBillTotalValues()
        {
            return
                AmtFiveEuroBillTotalValue +
                AmtTenEuroBillTotalValue +
                AmtTwentyEuroBillTotalValue +
                AmtFiftyEuroBillTotalValue +
                AmtHundredEuroBillTotalValue +
                AmtTwoHundredEuroBillTotalValue
            ;
        }
        #endregion

        public void UpdateDayOfCountDate()
        {
            string unformattedDayOfCountDate = DateTimeFormatInfo.CurrentInfo.GetDayName(dtCountDate.DayOfWeek).ToString();

            string capitalizedFirstCharDayOfCountDate = unformattedDayOfCountDate.Remove(0, 1).Insert(0, unformattedDayOfCountDate.Substring(0, 1).ToUpper());

            DayOfCountDate = capitalizedFirstCharDayOfCountDate;
        }

        public void SetDefaultDescription()
        {
            switch (CollectionRound)
            {
                case CollectionRound.first:
                    Description = CollectionRoundDescription.CollectionRound_One.GetDescription();
                    break;
                case CollectionRound.second:
                    Description = CollectionRoundDescription.CollectionRound_Two.GetDescription();
                    break;
                case CollectionRound.third:
                    Description = CollectionRoundDescription.CollectionRound_Three.GetDescription();
                    break;
                default:
                    Description = null;
                    break;
            }
        }

        #endregion
        public ICommand SaveCountResult { get; set; }

        private void ExecuteSaveCountResultFlow()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
