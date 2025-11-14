using UnityEngine;
using Zenject;

namespace Assets.Scripts.Managers.Helpers
{
    public class SignalLoadLevel : MonoBehaviour
    {
        private ILevelManager levelManager;

        [Inject]
        public void Construct(ILevelManager levelManager)
        {
            this.levelManager = levelManager;
        }

        public void NextLevel()
        {
            levelManager.NextLevel();
        }

        public void RestartLevel()
        {
            levelManager.Restart();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
