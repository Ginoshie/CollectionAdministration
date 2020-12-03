using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public abstract class AbstractAppState : IAppStates
    {
        public abstract string SaveButtonText { get; }
    
        public virtual bool IsSavingEnabled => false;
        
        public virtual bool IsLoadingSavedCountEnabled => false;
        
        public virtual bool IsSavedCountSelected  => false;

        public IAppStates LoadSavedCounts(Action loadSavedCounts)      
        {
            return OnLoadSavedCounts(loadSavedCounts);
        }

        public IAppStates SaveCount(Action saveCount)      
        {
            return OnSaveCount(saveCount);
        }

        public IAppStates ViewSelectedCount(Action viewSelectedCount)      
        {
            return OnViewSelectedCount(viewSelectedCount);
        }
        
        public IAppStates EditSelectedCount(Action editSelectedCount)
        {
            return OnEditSelectedCount(editSelectedCount);
        }

        public IAppStates DeleteSelectedCount(Action deleteSelectedCount)
        {
            return OnDeleteSelectedCount(deleteSelectedCount);
        }

        public IAppStates SelectSavedCount()
        {
            return OnSelectSavedCount();
        }

        public IAppStates CancelEditingSavedCount(Action createNewCount)
        { 
            return OnCancelEditingSavedCount(createNewCount);
        }

        protected virtual IAppStates OnLoadSavedCounts(Action loadSavedCounts) => this;

        protected virtual IAppStates OnSaveCount(Action saveCount) => this;

        protected virtual IAppStates OnViewSelectedCount(Action viewSelectedCount) => this;

        protected virtual IAppStates OnEditSelectedCount(Action editSelectedCount) => this;

        protected virtual IAppStates OnDeleteSelectedCount(Action deleteSelectedCount) => this;
        
        protected virtual IAppStates OnSelectSavedCount() => this;

        protected virtual IAppStates OnCancelEditingSavedCount(Action createNewCount) => this;
    }
}