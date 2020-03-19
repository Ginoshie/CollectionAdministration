using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CollectionAdministration_WPF
{
    public class CollectionAdministrationViewModel : INotifyPropertyChanged
    {
        private DateTime dtCountDate;

        private ChurchCommunity churchCommunity;

        private CollectionRound collectionRound;

        private string description;

        private int amtYellowCollectionCoin;

        private double amtYellowCollectionCoinsTotalValue;

        private int amtGreenCollectionCoin;

        private double amtGreenCollectionCoinTotalValue;

        private int amtRedCollectionCoin;

        private double amtRedCollectionCoinTotalValue;

        private int amtBlueCollectionCoin;

        private double amtBlueCollectionCoinTotalValue;

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

        private double amtCurrencryTotalValue;

        private int amtCoinsTotalValue;

        public CollectionAdministrationViewModel()
        {
            DtCountDate = DateTime.Today;

            SaveCountResult = new CommandHandler(() => ExecuteSaveCountResultFlow());
        }

        public DateTime DtCountDate { get => dtCountDate; set => dtCountDate = value; }

        public ChurchCommunity ChurchCommunity { get => churchCommunity; set => churchCommunity = value; }

        public CollectionRound CollectionRound { get => collectionRound; set => collectionRound = value; }

        public string Description { get => description; set => description = value; }

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

        public double AmtYellowCollectionCoinsTotalValue
        {
            get => amtYellowCollectionCoinsTotalValue;

            private set
            {
                if (amtYellowCollectionCoinsTotalValue == value)
                {
                    return;
                }

                amtYellowCollectionCoinsTotalValue = value;

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

                UpdateCurrencyTotalValue(Currency.FiveEuroBill);
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

                UpdateCurrencyTotalValue(Currency.TenEuroBill);
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

                UpdateCurrencyTotalValue(Currency.TwentyEuroBill);
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

                UpdateCurrencyTotalValue(Currency.FiftyEuroBill);
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

                UpdateCurrencyTotalValue(Currency.HundredEuroBill);
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

                UpdateCurrencyTotalValue(Currency.TwoHundredEuroBill);
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

        public int AmtTotalValueCoins { get => amtCoinsTotalValue; set => amtCoinsTotalValue = value; }

        private void UpdateCollectionCoinTotalValue(CollectionCoin collectionCoin)
        {
            switch (collectionCoin)
            {
                case CollectionCoin.YellowCollectionCoin:
                    AmtYellowCollectionCoinsTotalValue = collectionCoin.CalculateTotalValue(AmtYellowCollectionCoin);
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
        }


        private void UpdateCurrencyTotalValue(Currency currency)
        {
            switch (currency)
            {
                case Currency.FiveEuroBill:
                    AmtFiveEuroBillTotalValue = currency.CalculateTotalValue(AmtFiveEuroBill);
                    break;
                case Currency.TenEuroBill:
                    AmtTenEuroBillTotalValue = currency.CalculateTotalValue(AmtTenEuroBill);
                    break;
                case Currency.TwentyEuroBill:
                    AmtTwentyEuroBillTotalValue = currency.CalculateTotalValue(AmtTwentyEuroBill);
                    break;
                case Currency.FiftyEuroBill:
                    AmtFiftyEuroBillTotalValue = currency.CalculateTotalValue(AmtFiftyEuroBill);
                    break;
                case Currency.HundredEuroBill:
                    AmtHundredEuroBillTotalValue = currency.CalculateTotalValue(AmtHundredEuroBill);
                    break;
                case Currency.TwoHundredEuroBill:
                    AmtTwoHundredEuroBillTotalValue = currency.CalculateTotalValue(AmtTwoHundredEuroBill);
                    break;
                default: throw new InvalidEnumArgumentException(nameof(currency));
            }
        }

        public ICommand SaveCountResult { get; set; }

        private void ExecuteSaveCountResultFlow()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
