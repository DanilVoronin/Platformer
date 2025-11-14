using UnityEngine;
using Zenject;

namespace Assets.Scripts.Managers.Helpers
{
    /// <summary>
    /// Устанавливает состояние игры
    /// </summary>
    public class SeterGameManagerState : MonoBehaviour
    {
        [SerializeField, Tooltip("Целевое состояние")] 
        private GameManagerState targetGameManagerState;

        private IGameManager gameManager;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void SetState()
        {
            gameManager.SetGameManagerState(targetGameManagerState);
        }
    }
}
