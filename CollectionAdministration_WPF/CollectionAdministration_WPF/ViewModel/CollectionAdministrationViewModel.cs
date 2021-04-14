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
        private DateTime _dtCountDate;

        private string _dayOfCountDate;

        private ChurchCommunity _churchCommunity;

        private CollectionRound _collectionRound;

        private string _description;

        private readonly CollectionCoins _collectionCoins = new CollectionCoins();

        private readonly EuroBills _euroBills = new EuroBills();

        private string _amtEuroCoinsTotalValue;

        private double _amtCollectionTotalValue;

        private List<CollectionCount> _collectionCounts;

        private IAppStates _appState;

        private ICommand _saveCount;

        public CollectionAdministrationViewModel()
        {
            DtCountDate = DateTime.Today;

            SetDefaultDescription();

            AppState = new CreatingNewCount(SavedCountSelectedInDataGrid);
            GetSavedCounts = new CommandHandler(ExecuteLoadCountsFlow);
            EditSelectedCount = new CommandHandler(ExecuteEditCountFlow);
            CancelEditingSavedCount = new CommandHandler(ExecuteCancelEditingSavedCount);
            ViewSelectedCount = new CommandHandler(ExecuteViewCountFlow);
            SaveCount = new CommandHandler(ExecuteSaveCountFlow);
            DeleteSelectedCount = new CommandHandler(ExecuteDeleteCountFlow);
            SelectSavedCount = new CommandHandler(ExecuteSelectSavedCountFlow);
            LostFocusSavedCount = new CommandHandler(LoseFocusSavedCount);
        }

        public DateTime DtCountDate
        {
            get => _dtCountDate;
            set
            {
                if (_dtCountDate == value)
                {
                    return;
                }

                _dtCountDate = value;

                UpdateDayOfCountDate();

                OnPropertyChanged();
            }
        }

        public string DayOfCountDate
        {
            get => _dayOfCountDate;

            private set
            {
                if (_dayOfCountDate == value)
                {
                    return;
                }

                _dayOfCountDate = value;

                OnPropertyChanged();
            }
        }

        public ChurchCommunity ChurchCommunity
        {
            get => _churchCommunity;
            set
            {
                _churchCommunity = value;

                OnPropertyChanged();
            }
        }

        public CollectionRound CollectionRound
        {
            get => _collectionRound;

            set
            {
                if (_collectionRound == value)
                {
                    return;
                }

                _collectionRound = value;

                SetDefaultDescription();

                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;

            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;

                OnPropertyChanged();
            }
        }

        #region Collection Coin

        public string AmtYellowCollectionCoin
        {
            get => _collectionCoins.AmtYellowCollectionCoin ?? "0";

            set
            {
                var trimmedValue = value?.Trim();

                if (_collectionCoins.AmtYellowCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _collectionCoins.AmtYellowCollectionCoin = "0";
                }

                _collectionCoins.AmtYellowCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.YellowCollectionCoin);
            }
        }

        public double AmtYellowCollectionCoinTotalValue
        {
            get => _collectionCoins.AmtYellowCollectionCoinTotalValue;

            private set
            {
                if (_collectionCoins.AmtYellowCollectionCoinTotalValue == value)
                {
                    return;
                }

                _collectionCoins.AmtYellowCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtGreenCollectionCoin
        {
            get => _collectionCoins.AmtGreenCollectionCoin ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_collectionCoins.AmtGreenCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _collectionCoins.AmtGreenCollectionCoin = "0";
                }

                _collectionCoins.AmtGreenCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.GreenCollectionCoin);
            }
        }

        public double AmtGreenCollectionCoinTotalValue
        {
            get => _collectionCoins.AmtGreenCollectionCoinTotalValue;

            private set
            {
                if (_collectionCoins.AmtGreenCollectionCoinTotalValue == value)
                {
                    return;
                }

                _collectionCoins.AmtGreenCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtRedCollectionCoin
        {
            get => _collectionCoins.AmtRedCollectionCoin ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_collectionCoins.AmtRedCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _collectionCoins.AmtRedCollectionCoin = "0";
                }

                _collectionCoins.AmtRedCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.RedCollectionCoin);
            }
        }

        public double AmtRedCollectionCoinTotalValue
        {
            get => _collectionCoins.AmtRedCollectionCoinTotalValue;

            private set
            {
                if (_collectionCoins.AmtRedCollectionCoinTotalValue == value)
                {
                    return;
                }

                _collectionCoins.AmtRedCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtBlueCollectionCoin
        {
            get => _collectionCoins.AmtBlueCollectionCoin ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_collectionCoins.AmtBlueCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _collectionCoins.AmtBlueCollectionCoin = "0";
                }

                _collectionCoins.AmtBlueCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.BlueCollectionCoin);
            }
        }

        public double AmtBlueCollectionCoinTotalValue
        {
            get => _collectionCoins.AmtBlueCollectionCoinTotalValue;

            private set
            {
                if (_collectionCoins.AmtBlueCollectionCoinTotalValue == value)
                {
                    return;
                }

                _collectionCoins.AmtBlueCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtCollectionCoinsTotalValue
        {
            get => _collectionCoins.AmtCollectionCoinsTotalValue;

            set
            {
                if (_collectionCoins.AmtCollectionCoinsTotalValue == value)
                {
                    return;
                }

                _collectionCoins.AmtCollectionCoinsTotalValue = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Euro Bill

        public string AmtFiveEuroBill
        {
            get => _euroBills.AmtFiveEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtFiveEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtFiveEuroBill = "0";
                }

                _euroBills.AmtFiveEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.FiveEuroBill);
            }
        }

        public double AmtFiveEuroBillTotalValue
        {
            get => _euroBills.AmtFiveEuroBillTotalValue;

            private set
            {
                if (_euroBills.AmtFiveEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtFiveEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTenEuroBill
        {
            get => _euroBills.AmtTenEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtTenEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtTenEuroBill = "0";
                }

                _euroBills.AmtTenEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TenEuroBill);
            }
        }

        public double AmtTenEuroBillTotalValue
        {
            get => _euroBills.AmtTenEuroBillTotalValue;

            private set
            {
                if (_euroBills.AmtTenEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtTenEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTwentyEuroBill
        {
            get => _euroBills.AmtTwentyEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtTwentyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtTwentyEuroBill = "0";
                }

                _euroBills.AmtTwentyEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TwentyEuroBill);
            }
        }

        public double AmtTwentyEuroBillTotalValue
        {
            get => _euroBills.AmtTwentyEuroBillTotalValue;

            private set
            {
                if (_euroBills.AmtTwentyEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtTwentyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtFiftyEuroBill
        {
            get => _euroBills.AmtFiftyEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtFiftyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtFiftyEuroBill = "0";
                }

                _euroBills.AmtFiftyEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.FiftyEuroBill);
            }
        }

        public double AmtFiftyEuroBillTotalValue
        {
            get => _euroBills.AmtFiftyEuroBillTotalValue;

            private set
            {
                if (_euroBills.AmtFiftyEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtFiftyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtHundredEuroBill
        {
            get => _euroBills.AmtHundredEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtHundredEuroBill = "0";
                }

                _euroBills.AmtHundredEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.HundredEuroBill);
            }
        }

        public double AmtHundredEuroBillTotalValue
        {
            get => _euroBills.AmtHundredEuroBillTotalValue;

            set
            {
                if (_euroBills.AmtHundredEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTwoHundredEuroBill
        {
            get => _euroBills.AmtTwoHundredEuroBill ?? "0";

            set
            {
                var trimmedValue = value.Trim();

                if (_euroBills.AmtTwoHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _euroBills.AmtTwoHundredEuroBill = "0";
                }

                _euroBills.AmtTwoHundredEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TwoHundredEuroBill);
            }
        }

        public double AmtTwoHundredEuroBillTotalValue
        {
            get => _euroBills.AmtTwoHundredEuroBillTotalValue;

            private set
            {
                if (_euroBills.AmtTwoHundredEuroBillTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtTwoHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtEuroBillsTotalValue
        {
            get => _euroBills.AmtEuroBillsTotalValue;
            set
            {
                if (_euroBills.AmtEuroBillsTotalValue == value)
                {
                    return;
                }

                _euroBills.AmtEuroBillsTotalValue = value;

                OnPropertyChanged();
            }
        }

        #endregion

        public string AmtEuroCoinsTotalValue
        {
            get => _amtEuroCoinsTotalValue ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtEuroCoinsTotalValue == trimmedValue)
                {
                    return;
                }

                _amtEuroCoinsTotalValue =
                    string.IsNullOrEmpty(trimmedValue) ? "0" : FormatUserInputPositiveDouble(value);

                OnPropertyChanged();

                UpdateCollectionTotalValue();
            }
        }

        public double AmtCollectionTotalValue
        {
            get => _amtCollectionTotalValue;

            set
            {
                if (_amtCollectionTotalValue == value)
                {
                    return;
                }

                _amtCollectionTotalValue = value;

                OnPropertyChanged();
            }
        }

        public CollectionCount SavedCountSelectedInDataGrid { get; set; }

        public List<CollectionCount> CollectionCounts
        {
            get => _collectionCounts;

            set
            {
                if (_collectionCounts == value)
                {
                    return;
                }

                _collectionCounts = value;

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
            get => _appState;

            private set
            {
                _appState = value;

                OnPropertyChanged();
            }
        }
        
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
            var unformattedDayOfCountDate = DateTimeFormatInfo.CurrentInfo?.GetDayName(_dtCountDate.DayOfWeek);

            var capitalizedFirstCharDayOfCountDate = unformattedDayOfCountDate?.Remove(0, 1)
                .Insert(0, unformattedDayOfCountDate.Substring(0, 1).ToUpper());

            DayOfCountDate = capitalizedFirstCharDayOfCountDate;
        }

        private void SetDefaultDescription()
        {
            Description = CollectionRound switch
            {
                CollectionRound.First => CollectionRoundDescription.CollectionRoundOne.GetDescription(),
                CollectionRound.Second => CollectionRoundDescription.CollectionRoundTwo.GetDescription(),
                CollectionRound.Third => CollectionRoundDescription.CollectionRoundThree.GetDescription(),
                _ => null
            };
        }

        #endregion

        #region Commands

        public ICommand SaveCount
        {
            get => _saveCount;
            set
            {
                if (_saveCount != null && value == _saveCount)
                    return;

                _saveCount = value;

                OnPropertyChanged();
            }
        }

        public ICommand GetSavedCounts { get; set; }

        public ICommand EditSelectedCount { get; set; }

        public ICommand CancelEditingSavedCount { get; set; }

        public ICommand ViewSelectedCount { get; set; }

        public ICommand DeleteSelectedCount { get; set; }

        public ICommand SelectSavedCount { get; set; }

        public ICommand LostFocusSavedCount { get; set; }

        #endregion

        #region Flows

        private void ExecuteSaveCountFlow()
        {
            AppState = AppState.SaveCount(() => DatabaseQueries.InsertCountResult(GetCountResultAsDictionary()));

            ExecuteLoadCountsFlow();
        }

        private void ExecuteUpdateCountFlow()
        {
            AppState = AppState.SaveCount(() =>
                DatabaseQueries.UpdateCount(SavedCountSelectedInDataGrid.CollectionCountId,
                    GetCountResultAsDictionary()));

            ExecuteLoadCountsFlow();
        }

        private void ExecuteLoadCountsFlow()
        {
            AppState = AppState.LoadSavedCounts(() => FillCollectionCountDataGrid(RetrieveCollectionCounts()));
        }

        private void ExecuteEditCountFlow()
        {
            AppState = AppState.EditSelectedCount(() => FillCurrentCountFields(SavedCountSelectedInDataGrid));

            SaveCount = new CommandHandler(ExecuteUpdateCountFlow);
        }

        private void ExecuteCancelEditingSavedCount()
        {
            AppState = AppState.CancelEditingSavedCount(ResetToNewCount);

            SaveCount = new CommandHandler(ExecuteSaveCountFlow);
        }

        private void ExecuteViewCountFlow()
        {
            AppState = AppState.ViewSelectedCount(() => FillCurrentCountFields(SavedCountSelectedInDataGrid));
        }

        private void ExecuteDeleteCountFlow()
        {
            AppState = AppState.DeleteSelectedCount(() =>
            {
                DatabaseQueries.DeleteCount(SavedCountSelectedInDataGrid.CollectionCountId);

                ExecuteLoadCountsFlow();
            });
        }

        private void ExecuteSelectSavedCountFlow()
        {
            AppState = AppState.SelectSavedCount();
        }

        private void LoseFocusSavedCount()
        {
            AppState = AppState.LoseFocusOnSavedCount();
        }

        #endregion

        #region DataBase related methods

        private List<CollectionCount> RetrieveCollectionCounts()
        {
            return DatabaseQueries.GetCollectionCounts();
        }

        private void FillCollectionCountDataGrid(List<CollectionCount> collectionCountResults)
        {
            CollectionCounts = collectionCountResults;
        }

        private void ResetToNewCount()
        {
            DtCountDate = DateTime.Today;
            ChurchCommunity = ChurchCommunity.Wijk1;
            CollectionRound = CollectionRound.First;
            Description = "0";
            AmtYellowCollectionCoin = "0";
            AmtGreenCollectionCoin = "0";
            AmtRedCollectionCoin = "0";
            AmtBlueCollectionCoin = "0";
            AmtFiveEuroBill = "0";
            AmtTenEuroBill = "0";
            AmtTwentyEuroBill = "0";
            AmtFiftyEuroBill = "0";
            AmtHundredEuroBill = "0";
            AmtTwoHundredEuroBill = "0";
            AmtEuroCoinsTotalValue = "0";
        }

        private void FillCurrentCountFields(CollectionCount collectionCount)
        {
            DtCountDate = collectionCount.DtCountDate;
            ChurchCommunity = collectionCount.ChurchCommunity;
            CollectionRound = collectionCount.CollectionRound;
            Description = collectionCount.Description;
            AmtYellowCollectionCoin = collectionCount.CollectionCoins.AmtYellowCollectionCoin;
            AmtGreenCollectionCoin = collectionCount.CollectionCoins.AmtGreenCollectionCoin;
            AmtRedCollectionCoin = collectionCount.CollectionCoins.AmtRedCollectionCoin;
            AmtBlueCollectionCoin = collectionCount.CollectionCoins.AmtBlueCollectionCoin;
            AmtFiveEuroBill = collectionCount.EuroBills.AmtFiveEuroBill;
            AmtTenEuroBill = collectionCount.EuroBills.AmtTenEuroBill;
            AmtTwentyEuroBill = collectionCount.EuroBills.AmtTwentyEuroBill;
            AmtFiftyEuroBill = collectionCount.EuroBills.AmtFiftyEuroBill;
            AmtHundredEuroBill = collectionCount.EuroBills.AmtHundredEuroBill;
            AmtTwoHundredEuroBill = collectionCount.EuroBills.AmtTwoHundredEuroBill;
            AmtEuroCoinsTotalValue = collectionCount.AmtEuroCoinsTotalValue;
        }

        private Dictionary<string, string> GetCountResultAsDictionary()
        {
            return new Dictionary<string, string>()
            {
                // Meta data
                {nameof(DtCountDate), $"\'{DtCountDate.Date.ToShortDateString()}\'"},
                {nameof(ChurchCommunity), $"\'{ChurchCommunity}\'"},
                {nameof(CollectionRound), $"\'{CollectionRound}\'"},
                {nameof(Description), $"\'{Description}\'"},
                // Collection coins
                {nameof(AmtYellowCollectionCoin), AmtYellowCollectionCoin.Replace(",", ".")},
                {nameof(AmtGreenCollectionCoin), AmtGreenCollectionCoin.Replace(",", ".")},
                {nameof(AmtRedCollectionCoin), AmtRedCollectionCoin.Replace(",", ".")},
                {nameof(AmtBlueCollectionCoin), AmtRedCollectionCoin.Replace(",", ".")},
                // Euro bills
                {nameof(AmtFiveEuroBill), AmtFiveEuroBill.Replace(",", ".")},
                {nameof(AmtTenEuroBill), AmtTenEuroBill.Replace(",", ".")},
                {nameof(AmtTwentyEuroBill), AmtTwentyEuroBill.Replace(",", ".")},
                {nameof(AmtFiftyEuroBill), AmtFiftyEuroBill.Replace(",", ".")},
                {nameof(AmtHundredEuroBill), AmtHundredEuroBill.Replace(",", ".")},
                {nameof(AmtTwoHundredEuroBill), AmtTwoHundredEuroBill.Replace(",", ".")},
                // Euro coins
                {nameof(AmtEuroCoinsTotalValue), AmtEuroCoinsTotalValue.Replace(",", ".")}
            };
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}