using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CollectionAdministration_WPF.Calculators;
using CollectionAdministration_WPF.DTO;
using CollectionAdministration_WPF.Enums;
using CollectionAdministration_WPF.Extensions;
using CollectionAdministration_WPF.States.AppStates;
using Interfaces.States;

namespace CollectionAdministration_WPF.ViewModel
{
    public class CollectionAdministrationViewModel : INotifyPropertyChanged
    {
        #region Fields

        #region Metadata
        private int collectionCountId;

        private DateTime dtCountDate;

        private string dayOfCountDate;

        private ChurchCommunity churchCommunity;

        private CollectionRound collectionRound;

        private string description;
        #endregion

        #region Collection Coin
        private string amtYellowCollectionCoin;

        private double amtYellowCollectionCoinTotalValue;

        private string amtGreenCollectionCoin;

        private double amtGreenCollectionCoinTotalValue;

        private string amtRedCollectionCoin;

        private double amtRedCollectionCoinTotalValue;

        private string amtBlueCollectionCoin;

        private double amtBlueCollectionCoinTotalValue;

        private double amtCollectionCoinsTotalValue;
        #endregion

        #region Euro Bill
        private string amtFiveEuroBill;

        private double amtFiveEuroBillTotalValue;

        private string amtTenEuroBill;

        private double amtTenEuroBillTotalValue;

        private string amtTwentyEuroBill;

        private double amtTwentyEuroBillTotalValue;

        private string amtFiftyEuroBill;

        private double amtFiftyEuroBillTotalValue;

        private string amtHundredEuroBill;

        private double amtHundredEuroBillTotalValue;

        private string amtTwoHundredEuroBill;

        private double amtTwoHundredEuroBillTotalValue;

        private double amtEuroBillsTotalValue;
        #endregion

        private string amtEuroCoinsTotalValue;

        private double amtCollectionTotalValue;

        private List<CollectionCount> collectionCounts;

        private IAppStates appState;
        #endregion

        public CollectionAdministrationViewModel()
        {
            DtCountDate = DateTime.Today;

            SetDefaultDescription();
            
            AppState = new CurrentCountSelected();

            GetCounts = new CommandHandler(ExecuteLoadCountsFlow);

            LoadSelectedCountForViewing = new CommandHandler(ExecuteSetSelectedRowAsCurrentCount);

            SaveCount = new CommandHandler(ExecuteSaveCountFlow);

            DeleteCount = new CommandHandler(ExecuteDeleteCountFlow);
        }

        #region Properties

        #region Metadata
        public int CollectionCountId
        {
            get => collectionCountId;
            set
            {
                if (collectionCountId == value)
                {
                    return;
                }

                collectionCountId = value;
            }
        }

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

        public ChurchCommunity ChurchCommunity
        {
            get => churchCommunity;
            set => churchCommunity = value;
        }

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
        public string AmtYellowCollectionCoin
        {
            get => amtYellowCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value?.Trim();

                if (amtYellowCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtYellowCollectionCoin = "0";
                }

                amtYellowCollectionCoin = trimmedValue;

                OnPropertyChanged();

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

        public string AmtGreenCollectionCoin
        {
            get => amtGreenCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtGreenCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtGreenCollectionCoin = "0";
                }

                amtGreenCollectionCoin = trimmedValue;

                OnPropertyChanged();

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

        public string AmtRedCollectionCoin
        {
            get => amtRedCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtRedCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtRedCollectionCoin = "0";
                }

                amtRedCollectionCoin = trimmedValue;

                OnPropertyChanged();

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

        public string AmtBlueCollectionCoin
        {
            get => amtBlueCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtBlueCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtBlueCollectionCoin = "0";
                }

                amtBlueCollectionCoin = trimmedValue;

                OnPropertyChanged();

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
                if (amtCollectionCoinsTotalValue == value)
                {
                    return;
                }

                amtCollectionCoinsTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Euro Bill
        public string AmtFiveEuroBill
        {
            get => amtFiveEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtFiveEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtFiveEuroBill = "0";
                }

                amtFiveEuroBill = trimmedValue;

                OnPropertyChanged();

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

        public string AmtTenEuroBill
        {
            get => amtTenEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtTenEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtTenEuroBill = "0";
                }

                amtTenEuroBill = trimmedValue;

                OnPropertyChanged();

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

        public string AmtTwentyEuroBill
        {
            get => amtTwentyEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtTwentyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtTwentyEuroBill = "0";
                }

                amtTwentyEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TwentyEuroBill);
            }
        }

        public double AmtTwentyEuroBillTotalValue
        {
            get => amtTwentyEuroBillTotalValue;

            private set
            {
                if (amtTwentyEuroBillTotalValue == value)
                {
                    return;
                }

                amtTwentyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtFiftyEuroBill
        {
            get => amtFiftyEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtFiftyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtFiftyEuroBill = "0";
                }

                amtFiftyEuroBill = trimmedValue;

                OnPropertyChanged();

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

        public string AmtHundredEuroBill
        {
            get => amtHundredEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtHundredEuroBill = "0";
                }

                amtHundredEuroBill = trimmedValue;

                OnPropertyChanged();

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

        public string AmtTwoHundredEuroBill
        {
            get => amtTwoHundredEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtTwoHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtTwoHundredEuroBill = "0";
                }

                amtTwoHundredEuroBill = trimmedValue;

                OnPropertyChanged();

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
                if (amtEuroBillsTotalValue == value)
                {
                    return;
                }

                amtEuroBillsTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion

        public string AmtEuroCoinsTotalValue
        {
            get => amtEuroCoinsTotalValue ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (amtEuroCoinsTotalValue == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    amtEuroCoinsTotalValue = "0";
                }
                else
                {
                    amtEuroCoinsTotalValue = FormatUserInputPositiveDouble(value);
                }

                OnPropertyChanged();

                UpdateCollectionTotalValue();
            }
        }

        public double AmtCollectionTotalValue
        {
            get => amtCollectionTotalValue;

            set
            {
                if (amtCollectionTotalValue == value)
                {
                    return;
                }

                amtCollectionTotalValue = value;

                OnPropertyChanged();
            }
        }

        public CollectionCount CountSelectedInDataGrid { get; set; }

        public List<CollectionCount> CollectionCounts
        {
            get => collectionCounts;

            set
            {
                if(collectionCounts == value)
                {
                    return;
                }

                collectionCounts = value;

                OnPropertyChanged();

                OnPropertyChanged(nameof(DataGridVisibility));
            }
        }

        public Visibility DataGridVisibility
        {
            get
            {
                if (CollectionCounts == null || 
                    CollectionCounts.Count == 0)
                {
                    return Visibility.Hidden;
                }

                return Visibility.Visible;
            }
        }

        public IAppStates AppState
        {
            get => appState;

            private set
            {
                appState = value;
                
                OnPropertyChanged();
            }
        }
        
        #endregion

        private string FormatUserInputPositiveDouble(string value)
        {
            value = value.Replace(".", ",");

            return value;
        }

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
            double.TryParse(AmtEuroCoinsTotalValue, out double euroCoinsTotalValue);

            AmtCollectionTotalValue = 
                AmtCollectionCoinsTotalValue + 
                AmtEuroBillsTotalValue +
                euroCoinsTotalValue
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

        private void UpdateDayOfCountDate()
        {
            string unformattedDayOfCountDate = DateTimeFormatInfo.CurrentInfo?.GetDayName(dtCountDate.DayOfWeek);

            string capitalizedFirstCharDayOfCountDate = unformattedDayOfCountDate?.Remove(0, 1).Insert(0, unformattedDayOfCountDate.Substring(0, 1).ToUpper());

            DayOfCountDate = capitalizedFirstCharDayOfCountDate;
        }

        public void SetDefaultDescription()
        {
            switch (CollectionRound)
            {
                case CollectionRound.First:
                    Description = CollectionRoundDescription.CollectionRoundOne.GetDescription();
                    break;
                case CollectionRound.Second:
                    Description = CollectionRoundDescription.CollectionRoundTwo.GetDescription();
                    break;
                case CollectionRound.Third:
                    Description = CollectionRoundDescription.CollectionRoundThree.GetDescription();
                    break;
                default:
                    Description = null;
                    break;
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCount { get; set; }

        public ICommand GetCounts { get; set; }

        public ICommand LoadSelectedCountForViewing { get; set; }

        public ICommand DeleteCount { get; set; }
        #endregion

        #region Flows
        private void ExecuteSaveCountFlow()
        {
            DatabaseQueries.InsertCountResult(GetCountResultAsDictionary());
        }

        private void ExecuteLoadCountsFlow()
        {
            FillCollectionCountDataGrid(RetrieveCollectionCounts());
        }

        private void ExecuteSetSelectedRowAsCurrentCount()
        {
            FillCurrentCountFields(CountSelectedInDataGrid);
        }

        private void ExecuteDeleteCountFlow()
        {
            DatabaseQueries.DeleteCount(GetPkSelectedCount());
        }
        #endregion

        #region DataBase related methods
        private int GetPkSelectedCount()
        {
            return CollectionCountId;
        }

        private List<CollectionCount> RetrieveCollectionCounts()
        {
            return DatabaseQueries.GetCollectionCounts();
        }

        private void FillCollectionCountDataGrid(List<CollectionCount> collectionCountResults)
        {
            CollectionCounts = collectionCountResults;
        }

        private void FillCurrentCountFields(CollectionCount collectionCount)
        {
            DtCountDate = collectionCount.DtCountDate;
            ChurchCommunity = collectionCount.ChurchCommunity; //(ChurchCommunity)Enum.Parse(typeof(ChurchCommunity), collectionCount.ChurchCommunity);
            CollectionRound = collectionCount.CollectionRound; //(CollectionRound)Enum.Parse(typeof(CollectionRound), collectionCount.CollectionRound);
            Description = collectionCount.Description;
            AmtYellowCollectionCoin = collectionCount.AmtYellowCollectionCoin;
            AmtGreenCollectionCoin = collectionCount.AmtGreenCollectionCoin;
            AmtRedCollectionCoin = collectionCount.AmtRedCollectionCoin;
            AmtBlueCollectionCoin = collectionCount.AmtBlueCollectionCoin;
            AmtFiveEuroBill = collectionCount.AmtFiveEuroBill;
            AmtTenEuroBill = collectionCount.AmtTenEuroBill;
            AmtTwentyEuroBill = collectionCount.AmtTwentyEuroBill;
            AmtFiftyEuroBill = collectionCount.AmtFiftyEuroBill;
            AmtHundredEuroBill = collectionCount.AmtHundredEuroBill;
            AmtTwoHundredEuroBill = collectionCount.AmtTwoHundredEuroBill;
            AmtEuroCoinsTotalValue = collectionCount.AmtEuroCoinsTotalValue;
        }

        private Dictionary<string, string> GetCountResultAsDictionary()
        {
            return new Dictionary<string, string>()
            {
                // Meta data
                { nameof(DtCountDate), $"\'{DtCountDate.Date.ToShortDateString()}\'"},
                { nameof(ChurchCommunity), $"\'{ChurchCommunity}\'"},
                { nameof(CollectionRound), $"\'{CollectionRound}\'"},
                { nameof(Description), $"\'{Description}\'"},
                // Colection coins
                { nameof(AmtYellowCollectionCoin), AmtYellowCollectionCoin.Replace(",", ".")},
                { nameof(AmtGreenCollectionCoin), AmtGreenCollectionCoin.Replace(",", ".")},
                { nameof(AmtRedCollectionCoin), AmtRedCollectionCoin.Replace(",", ".")},
                { nameof(AmtBlueCollectionCoin), AmtRedCollectionCoin.Replace(",", ".")},
                // Euro bills
                { nameof(AmtFiveEuroBill), AmtFiveEuroBill.Replace(",", ".")},
                { nameof(AmtTenEuroBill), AmtTenEuroBill.Replace(",", ".")},
                { nameof(AmtTwentyEuroBill), AmtTwentyEuroBill.Replace(",", ".")},
                { nameof(AmtFiftyEuroBill), AmtFiftyEuroBill.Replace(",", ".")},
                { nameof(AmtHundredEuroBill), AmtHundredEuroBill.Replace(",", ".")},
                { nameof(AmtTwoHundredEuroBill), AmtTwoHundredEuroBill.Replace(",", ".")},
                // Euro coins
                { nameof(AmtEuroCoinsTotalValue), AmtEuroCoinsTotalValue.Replace(",", ".")}
            };         
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
