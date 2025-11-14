using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Helpers.UI;
using Zenject;
using System;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Управляет игровыми сценами
    /// </summary>
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField, Tooltip("Список игровых уровней")]
        List<string> levels;

        private Scene currentScene;
        private Fade fade;

        public event Action<string> OnLoadLevel;

        [Inject]
        private void Construct(Fade fade)
        {
            this.fade = fade;
        }

        private void Awake()
        {
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        private void Start()
        {
            fade.SetOutFade();
            OnLoadLevel?.Invoke(SceneManager.GetActiveScene().name);
        }

        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            currentScene = arg1;
            OnLoadLevel?.Invoke(currentScene.name);
        }

        public async UniTaskVoid Menu()
        {
            await LoadLevel("Menu");
        }
        public async UniTaskVoid NextLevel()
        {
            if (levels == null || levels.Count == 0) await LoadLevel("Menu");
            int numberCurrent = levels.IndexOf(currentScene.name);
            if (numberCurrent == -1) 
            {
                numberCurrent = 0;
            }
            else 
            {
                numberCurrent++;
                if (numberCurrent >= levels.Count)
                {
                    numberCurrent = 0;
                }
            }
            string nextLevel = levels[numberCurrent];

            await LoadLevel(nextLevel);
        }

        private async UniTask LoadLevel(string level)
        {
            fade.SetInFade();
            while (fade.IsProgress()) await UniTask.Yield();

            SceneManager.LoadScene(level, LoadSceneMode.Single);

            await UniTask.DelayFrame(10);

            fade.SetOutFade();
            while (fade.IsProgress()) await UniTask.Yield();
        }

        public async UniTaskVoid Restart()
        {
            await LoadLevel(currentScene.name);
        }
    }
}
