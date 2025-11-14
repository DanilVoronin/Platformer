using Assets.Scripts.Managers.Helpers;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Глобальная логика игры
    /// </summary>
    public class GameManager : MonoBehaviour , IGameManager
    {
        [SerializeField, Tooltip("Лист событий")]
        private List<GameManagerEvent> listEvents;

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public GameManagerState CurrentGameManagerState { get; private set; }

        public void SetGameManagerState(GameManagerState gameManagerState)
        {
            if(CurrentGameManagerState != gameManagerState)
            CurrentGameManagerState = gameManagerState;

            foreach (GameManagerEvent gameManagerEvent in listEvents)
            {
                if (gameManagerEvent.TargetGameManager == CurrentGameManagerState)
                {
                    gameManagerEvent.UnityEvent?.Invoke();
                }
            }
        }
    }
}
