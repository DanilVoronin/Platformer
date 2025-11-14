using System;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts.Managers.Helpers
{
    /// <summary>
    /// Игровое событие в зависимости от состояние
    /// </summary>
    [Serializable]
    public class GameManagerEvent
    {
        public GameManagerState TargetGameManager;
        public UnityEvent UnityEvent;
    }
}
