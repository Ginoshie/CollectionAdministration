using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class SelectingSavedCount : AbstractAppState
    {
        public override string SaveButtonText => "Telling opslaan";
        
        public override bool IsSavingEnabled => true;

        public override bool IsLoadingSavedCountEnabled => true;

        public override bool IsSavedCountSelected => true;

        protected override IAppStates OnLoadSavedCounts(Action loadSavedCounts)
        {
            loadSavedCounts();
            
            return this;
        }

        protected override IAppStates OnDeleteSelectedCount(Action deleteSelectedCount)
        {
            deleteSelectedCount();
            
            return new CreatingNewCount();
        }
        
        protected override IAppStates OnViewSelectedCount(Action viewSelectedCount)
        {
            viewSelectedCount();

            return this;
        }

        protected override IAppStates OnEditSelectedCount(Action editSelectedCount)
        {
            editSelectedCount();

            return new EditingSavedCount();
        }
    }
}