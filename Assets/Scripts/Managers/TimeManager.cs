using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Управляет временем в игре
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// Состояние
        /// </summary>
        public TimeManagerState CurrentTimeManagerState { get; private set; }

        /// <summary>
        /// Пауза в игре
        /// </summary>
        public void Pause()
        {
            if (CurrentTimeManagerState == TimeManagerState.pause) return;

            Time.timeScale = 0;
            CurrentTimeManagerState = TimeManagerState.pause;
        }

        /// <summary>
        /// Отключение паузы
        /// </summary>
        public void UnPause()
        {
            if (CurrentTimeManagerState != TimeManagerState.pause) return;

            Time.timeScale = 1;
            CurrentTimeManagerState = TimeManagerState.play;
        }
    }

    public enum TimeManagerState
    { 
        play,
        pause
    }
}
