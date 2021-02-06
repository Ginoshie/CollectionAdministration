using System;
using System.Collections.Generic;

namespace Interfaces.States
{
    public interface IAppStates
    {
        string SaveButtonText { get; }
        
        bool IsSavingEnabled { get; }
        
        bool IsLoadingSavedCountEnabled { get; }
        
        bool IsCancelEditingSavedCountEnabled { get; }
        
        bool IsSavedCountSelected { get; }

        IAppStates LoadSavedCounts(Action loadSavedCounts);

        IAppStates SaveCount(Action saveCount);
        
        IAppStates ViewSelectedCount(Action viewSelectedCount);

        IAppStates EditSelectedCount(Action editSelectedCount);

        IAppStates DeleteSelectedCount(Action deleteSelectedCount);

        IAppStates SelectSavedCount();
        
        IAppStates DeSelectSavedCount(Action clearSelectedCount);

        IAppStates CancelEditingSavedCount(Action createNewCount);
    }
}