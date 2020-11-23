using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class SavedCountSelected : IAppStates
    {
        public bool IsSavingEnabled => true;

        public bool IsLoadingSavedCountEnabled => true;

        public bool IsExistingCountSelected => true;

        public IAppStates LoadSavedCounts(Action loadSavedCounts) => this;

        public IAppStates SaveCurrentCount(Action saveCurrentCount) => this;
        public IAppStates DeleteCount(Action deleteSelectedCount)
        {
            deleteSelectedCount();
            
            return new CurrentCountSelected();
        }

        public IAppStates ViewSelectedCount(Action viewSelectedCount)
        {
            viewSelectedCount();

            return this;
        }

        public IAppStates EditSelectedCount(Action editSelectedCount)
        {
            editSelectedCount();

            return this;
        }

        public IAppStates RemoveSelectedCount(Action removeSelectedCount)
        {
            removeSelectedCount();

            return this;
        }

        public IAppStates SelectSavedCount() => this;
    }
}