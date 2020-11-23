using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class CurrentCountSelected : IAppStates
    {
        public bool IsSavingEnabled => true;
        
        public bool IsLoadingSavedCountEnabled => true;
        
        public bool IsExistingCountSelected => false;
        
        public IAppStates CreateNewCount(Action createNewCount)
        {
            createNewCount();
            
            return this;
        }

        public IAppStates SaveCurrentCount(Action saveCurrentCount)
        {
            saveCurrentCount();
            
            return this;
        }

        public IAppStates ViewSelectedCount(Action viewSelectedCount) => this;

        public IAppStates EditSelectedCount(Action editSelectedCount) => this;

        public IAppStates RemoveSelectedCount(Action removeSelectedCount) => this;
    }
}