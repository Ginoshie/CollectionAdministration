using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class CreatingNewCount : AbstractAppState
    {
        public override string SaveButtonText => "Telling opslaan";

        public override bool IsSavingEnabled => true;

        public override bool IsLoadingSavedCountEnabled => true;

        protected override IAppStates OnSaveCount(Action saveCount)
        {
            saveCount();

            return this;
        }

        protected override IAppStates OnLoadSavedCounts(Action loadSavedCounts)
        {
            loadSavedCounts();

            return this;
        }
        
        protected override IAppStates OnSelectSavedCount() => new SavedCountSelected();
    }
}