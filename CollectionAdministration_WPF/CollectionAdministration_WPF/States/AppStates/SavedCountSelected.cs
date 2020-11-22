using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class SavedCountSelected : IAppStates
    {
        public bool IsSavingEnabled => false;

        public bool IsLoadingSavedCountEnabled => true;

        public bool IsExistingCountSelected => true;

        public IAppStates CreateNewCount(Action createNewCount) => this;

        public IAppStates SaveCurrentCount(Action saveCurrentCount) => this;

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
    }
}