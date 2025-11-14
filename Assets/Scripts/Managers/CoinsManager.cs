using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Модсчет монеток
    /// </summary>
    public class CoinsManager : MonoBehaviour
    {
        /// <summary>
        /// Текущее количество монет
        /// </summary>
        [field : SerializeField]
        public int Count { get; private set; }

        public event System.Action OnUpdateCoins;

        /// <summary>
        /// Увеличивает количество монет
        /// </summary>
        /// <param name="count"></param>
        public void AddCoin(int count)
        {
            Count += count;
            OnUpdateCoins?.Invoke();
        }    

        /// <summary>
        /// Сброс счетчика монет
        /// </summary>
        public void ResetCoin()
        {
            Count = 0;
            OnUpdateCoins?.Invoke();
        }
    }
}
