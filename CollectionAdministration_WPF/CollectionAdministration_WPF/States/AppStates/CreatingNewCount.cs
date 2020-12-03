using System;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class CreatingNewCount : AbstractAppState
    {
        public override string SaveButtonText => "Telling opslaan";

        public override bool IsSavingEnabled => true;

        public override bool IsLoadingSavedCountEnabled => true;

        protected override IAppStates OnLoadSavedCounts(Action saveCount)
        {
            saveCount();

            return this;
        }
        
        protected override IAppStates OnSelectSavedCount() => new SelectingSavedCount();
    }
}