using System;
using Enums;
using Extensions;
using Keys;
using UnityEngine.Events;


namespace Events
{
    public class CoreGameEvents : MonoSingleton<CoreGameEvents>
    {
        public UnityAction<GameStates> OnChangeGameStates = delegate { };
        public UnityAction<SaveDataParams> OnSaveGame = delegate { };
        public UnityAction OnLevelInitialize = delegate { };
        public UnityAction OnClearActiveLevel = delegate { };
        public UnityAction OnLevelFailed = delegate { };
        public UnityAction OnLevelSuccesful = delegate { };
        public UnityAction OnNextLevel = delegate { };
        public UnityAction OnRestartLevel = delegate { };
        public UnityAction OnPlay = delegate { };
        public UnityAction OnReset = delegate { };
    }
}