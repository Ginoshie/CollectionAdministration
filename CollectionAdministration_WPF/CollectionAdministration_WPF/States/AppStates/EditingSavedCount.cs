﻿using System;
using CollectionAdministration_WPF.DTO;
using Interfaces.States;

namespace CollectionAdministration_WPF.States.AppStates
{
    public class EditingSavedCount : AbstractAppState
    {
        public EditingSavedCount(CollectionCount countSelectedInDataGrid) : base(countSelectedInDataGrid) { }

        public override string SaveButtonText => "Telling bijwerken";
        
        public override bool IsSavingEnabled => true;
        
        public override bool IsCancelEditingSavedCountEnabled => true;

        protected override IAppStates OnSaveCount(Action saveCount)
        {
            saveCount();
            
            return new CreatingNewCount(CountSelectedInDataGrid);
        }

        protected override IAppStates OnCancelEditingSavedCount(Action createNewCount)
        {
            createNewCount();
            
            return new CreatingNewCount(CountSelectedInDataGrid);   
        }
    }
}