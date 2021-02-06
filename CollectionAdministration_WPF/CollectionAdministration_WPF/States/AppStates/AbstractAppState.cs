using System;
using CollectionAdministration_WPF.DTO;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public abstract class AbstractAppState : IAppStates
    {
        protected CollectionCount CountSelectedInDataGrid;
        
        public abstract string SaveButtonText { get; }
    
        public virtual bool IsSavingEnabled => false;
        
        public virtual bool IsLoadingSavedCountEnabled => false;

        public virtual bool IsCancelEditingSavedCountEnabled => false;
        
        public virtual bool IsSavedCountSelected  => CountSelectedInDataGrid != null;

        public AbstractAppState(CollectionCount countSelectedInDataGrid)
        {
            this.CountSelectedInDataGrid = countSelectedInDataGrid;
        }
        
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

        public IAppStates DeSelectSavedCount(Action clearSelectedCount)
        {
            return OnDeSelectSavedCount(clearSelectedCount);
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

        protected virtual IAppStates OnDeSelectSavedCount(Action clearSelectedCount) => this;
        
        protected virtual IAppStates OnCancelEditingSavedCount(Action createNewCount) => this;
    }
}