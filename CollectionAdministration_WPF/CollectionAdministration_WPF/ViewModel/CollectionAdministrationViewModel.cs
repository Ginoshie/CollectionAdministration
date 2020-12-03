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

        private int _collectionCountId;
        
        private DateTime _dtCountDate;

        private string _dayOfCountDate;

        private ChurchCommunity _churchCommunity;

        private CollectionRound _collectionRound;

        private string _description;
        #endregion

        #region Collection Coin
        private string _amtYellowCollectionCoin;

        private double _amtYellowCollectionCoinTotalValue;

        private string _amtGreenCollectionCoin;

        private double _amtGreenCollectionCoinTotalValue;

        private string _amtRedCollectionCoin;

        private double _amtRedCollectionCoinTotalValue;

        private string _amtBlueCollectionCoin;

        private double _amtBlueCollectionCoinTotalValue;

        private double _amtCollectionCoinsTotalValue;
        #endregion

        #region Euro Bill
        private string _amtFiveEuroBill;

        private double _amtFiveEuroBillTotalValue;

        private string _amtTenEuroBill;

        private double _amtTenEuroBillTotalValue;

        private string _amtTwentyEuroBill;

        private double _amtTwentyEuroBillTotalValue;

        private string _amtFiftyEuroBill;

        private double _amtFiftyEuroBillTotalValue;

        private string _amtHundredEuroBill;

        private double _amtHundredEuroBillTotalValue;

        private string _amtTwoHundredEuroBill;

        private double _amtTwoHundredEuroBillTotalValue;

        private double _amtEuroBillsTotalValue;

        #endregion

        private string _amtEuroCoinsTotalValue;

        private double _amtCollectionTotalValue;

        private List<CollectionCount> _collectionCounts;

        private IAppStates _appState;
        
        private ICommand _saveCount;

        #endregion

        public CollectionAdministrationViewModel()
        {
            DtCountDate = DateTime.Today;

            SetDefaultDescription();
            
            AppState = new CreatingNewCount();

            GetSavedCounts = new CommandHandler(ExecuteLoadCountsFlow);

            EditSelectedCount = new CommandHandler(ExecuteEditCountFlow);
            
            ViewSelectedCount = new CommandHandler(ExecuteViewCountFlow);

            SaveCount = new CommandHandler(ExecuteSaveCountFlow);

            DeleteSelectedCount = new CommandHandler(ExecuteDeleteCountFlow);
            
            SelectSavedCount = new CommandHandler(ExecuteSelectSavedCountFlow);
        }

        #region Properties

        #region Metadata
        public int CollectionCountId { get; set; }
        
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
        #endregion

        #region Collection Coin
        public string AmtYellowCollectionCoin
        {
            get => _amtYellowCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value?.Trim();

                if (_amtYellowCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtYellowCollectionCoin = "0";
                }

                _amtYellowCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.YellowCollectionCoin);
            }
        }

        public double AmtYellowCollectionCoinTotalValue
        {
            get => _amtYellowCollectionCoinTotalValue;

            private set
            {
                if (_amtYellowCollectionCoinTotalValue == value)
                {
                    return;
                }

                _amtYellowCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtGreenCollectionCoin
        {
            get => _amtGreenCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtGreenCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtGreenCollectionCoin = "0";
                }

                _amtGreenCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.GreenCollectionCoin);
            }
        }

        public double AmtGreenCollectionCoinTotalValue
        {
            get => _amtGreenCollectionCoinTotalValue;

            private set
            {
                if (_amtGreenCollectionCoinTotalValue == value)
                {
                    return;
                }

                _amtGreenCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtRedCollectionCoin
        {
            get => _amtRedCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtRedCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtRedCollectionCoin = "0";
                }

                _amtRedCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.RedCollectionCoin);
            }
        }

        public double AmtRedCollectionCoinTotalValue
        {
            get => _amtRedCollectionCoinTotalValue;

            private set
            {
                if (_amtRedCollectionCoinTotalValue == value)
                {
                    return;
                }

                _amtRedCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtBlueCollectionCoin
        {
            get => _amtBlueCollectionCoin ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtBlueCollectionCoin == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtBlueCollectionCoin = "0";
                }

                _amtBlueCollectionCoin = trimmedValue;

                OnPropertyChanged();

                UpdateCollectionCoinTotalValue(CollectionCoin.BlueCollectionCoin);
            }
        }

        public double AmtBlueCollectionCoinTotalValue
        {
            get => _amtBlueCollectionCoinTotalValue;

            private set
            {
                if (_amtBlueCollectionCoinTotalValue == value)
                {
                    return;
                }

                _amtBlueCollectionCoinTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtCollectionCoinsTotalValue
        {
            get => _amtCollectionCoinsTotalValue;

            set
            {
                if (_amtCollectionCoinsTotalValue == value)
                {
                    return;
                }

                _amtCollectionCoinsTotalValue = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Euro Bill
        public string AmtFiveEuroBill
        {
            get => _amtFiveEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtFiveEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtFiveEuroBill = "0";
                }

                _amtFiveEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.FiveEuroBill);
            }
        }

        public double AmtFiveEuroBillTotalValue
        {
            get => _amtFiveEuroBillTotalValue;

            private set
            {
                if (_amtFiveEuroBillTotalValue == value)
                {
                    return;
                }

                _amtFiveEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTenEuroBill
        {
            get => _amtTenEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtTenEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtTenEuroBill = "0";
                }

                _amtTenEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TenEuroBill);
            }
        }

        public double AmtTenEuroBillTotalValue
        {
            get => _amtTenEuroBillTotalValue;

            private set
            {
                if (_amtTenEuroBillTotalValue == value)
                {
                    return;
                }

                _amtTenEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTwentyEuroBill
        {
            get => _amtTwentyEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtTwentyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtTwentyEuroBill = "0";
                }

                _amtTwentyEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TwentyEuroBill);
            }
        }

        public double AmtTwentyEuroBillTotalValue
        {
            get => _amtTwentyEuroBillTotalValue;

            private set
            {
                if (_amtTwentyEuroBillTotalValue == value)
                {
                    return;
                }

                _amtTwentyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtFiftyEuroBill
        {
            get => _amtFiftyEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtFiftyEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtFiftyEuroBill = "0";
                }

                _amtFiftyEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.FiftyEuroBill);
            }
        }

        public double AmtFiftyEuroBillTotalValue
        {
            get => _amtFiftyEuroBillTotalValue;

            private set
            {
                if (_amtFiftyEuroBillTotalValue == value)
                {
                    return;
                }

                _amtFiftyEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtHundredEuroBill
        {
            get => _amtHundredEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtHundredEuroBill = "0";
                }

                _amtHundredEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.HundredEuroBill);
            }
        }

        public double AmtHundredEuroBillTotalValue
        {
            get => _amtHundredEuroBillTotalValue;

            set
            {
                if (_amtHundredEuroBillTotalValue == value)
                {
                    return;
                }

                _amtHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public string AmtTwoHundredEuroBill
        {
            get => _amtTwoHundredEuroBill ?? "0";

            set
            {
                string trimmedValue = value.Trim();

                if (_amtTwoHundredEuroBill == trimmedValue)
                {
                    return;
                }

                if (string.IsNullOrEmpty(trimmedValue))
                {
                    _amtTwoHundredEuroBill = "0";
                }

                _amtTwoHundredEuroBill = trimmedValue;

                OnPropertyChanged();

                UpdateEuroBillTotalValue(EuroBill.TwoHundredEuroBill);
            }
        }

        public double AmtTwoHundredEuroBillTotalValue
        {
            get => _amtTwoHundredEuroBillTotalValue;

            private set
            {
                if (_amtTwoHundredEuroBillTotalValue == value)
                {
                    return;
                }

                _amtTwoHundredEuroBillTotalValue = value;

                OnPropertyChanged();
            }
        }

        public double AmtEuroBillsTotalValue
        {
            get => _amtEuroBillsTotalValue;
            set
            {
                if (_amtEuroBillsTotalValue == value)
                {
                    return;
                }

                _amtEuroBillsTotalValue = value;

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

                _amtEuroCoinsTotalValue = string.IsNullOrEmpty(trimmedValue) ? "0" : FormatUserInputPositiveDouble(value);

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

        public CollectionCount CountSelectedInDataGrid { get; set; }

        public List<CollectionCount> CollectionCounts
        {
            get => _collectionCounts;

            set
            {
                if(_collectionCounts == value)
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
            string unformattedDayOfCountDate = DateTimeFormatInfo.CurrentInfo?.GetDayName(_dtCountDate.DayOfWeek);

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
        
        public ICommand ViewSelectedCount { get; set; }

        public ICommand DeleteSelectedCount { get; set; }
        
        public ICommand SelectSavedCount { get; set; }
        #endregion

        #region Flows
        private void ExecuteSaveCountFlow()
        {
            AppState = AppState.SaveCount(() => DatabaseQueries.InsertCountResult(GetCountResultAsDictionary()));
            
            ExecuteLoadCountsFlow();
        }

        private void ExecuteUpdateCountFlow()
        {
            AppState = AppState.SaveCount(() => DatabaseQueries.UpdateCount(CountSelectedInDataGrid.CollectionCountId, GetCountResultAsDictionary()));
            
            ExecuteLoadCountsFlow();
        }

        private void ExecuteLoadCountsFlow()
        {
            AppState = AppState.LoadSavedCounts(() => FillCollectionCountDataGrid(RetrieveCollectionCounts()));
        }

        private void ExecuteEditCountFlow()
        {
            AppState = AppState.EditSelectedCount(() => FillCurrentCountFields(CountSelectedInDataGrid));
            
            SaveCount = new CommandHandler(ExecuteUpdateCountFlow);
        }
        
        private void ExecuteViewCountFlow()
        {
            AppState = AppState.ViewSelectedCount(() => FillCurrentCountFields(CountSelectedInDataGrid));
        }

        private void ExecuteDeleteCountFlow()
        {
            AppState = AppState.DeleteSelectedCount(() =>
            {
                DatabaseQueries.DeleteCount(CountSelectedInDataGrid.CollectionCountId);

                ExecuteLoadCountsFlow();
            });
        }

        private void ExecuteSelectSavedCountFlow()
        {
            AppState = AppState.SelectSavedCount();
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

        private void FillCurrentCountFields(CollectionCount collectionCount)
        {
            DtCountDate = collectionCount.DtCountDate;
            ChurchCommunity = collectionCount.ChurchCommunity;
            CollectionRound = collectionCount.CollectionRound;
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
