using System;

namespace Interfaces.States
{
    public interface IAppStates
    {
        bool IsSavingEnabled { get; }
        
        bool IsLoadingSavedCountEnabled { get; }
        
        bool IsExistingCountSelected { get; }

        IAppStates LoadSavedCounts(Action loadSavedCounts);

        IAppStates SaveCurrentCount(Action saveCurrentCount);

        IAppStates DeleteCount(Action deleteSelectedCount);

        IAppStates ViewSelectedCount(Action viewSelectedCount);

        IAppStates EditSelectedCount(Action editSelectedCount);

        IAppStates RemoveSelectedCount(Action removeSelectedCount);

        IAppStates SelectSavedCount();
    }
}