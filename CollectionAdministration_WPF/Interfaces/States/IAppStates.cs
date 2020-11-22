using System;

namespace Interfaces.States
{
    public interface IAppStates
    {
        bool IsSavingEnabled { get; }
        
        bool IsLoadingSavedCountEnabled { get; }
        
        bool IsExistingCountSelected { get; }

        IAppStates CreateNewCount(Action createNewCount);

        IAppStates SaveCurrentCount(Action saveCurrentCount);

        IAppStates ViewSelectedCount(Action viewSelectedCount);

        IAppStates EditSelectedCount(Action editSelectedCount);

        IAppStates RemoveSelectedCount(Action removeSelectedCount);
    }
}