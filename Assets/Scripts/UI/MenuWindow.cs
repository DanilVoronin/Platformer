using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using Assets.Scripts.Managers;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Управляет панелью меню
    /// Лучше сделать контроллер и 
    /// </summary>
    public class MenuWindow : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private Button buttonOpenMenu;
        [SerializeField]
        private Button buttonPlay;
        [SerializeField]
        private Button buttonLoadMenu;

        [SerializeField]
        private float speed;

        private bool isOpen;
        private TimeManager timeManager;
        private ILevelManager levelManager;

        [Inject]
        private void Construct(TimeManager timeManager, ILevelManager levelManager)
        {
            this.timeManager = timeManager;
            this.levelManager = levelManager;

            this.levelManager.OnLoadLevel += LevelManager_OnLoadLevel;

            buttonOpenMenu.onClick.AddListener(SignalButtonOpenMenu);
            buttonPlay.onClick.AddListener(Close);
            buttonLoadMenu.onClick.AddListener(LoadMenu);
        }

        private void LoadMenu()
        {
            print("MenuWindow load menu");
            Close();
            levelManager.Menu();
        }

        private void LevelManager_OnLoadLevel(string nameLevel)
        {
            bool active = nameLevel == "Menu";
            buttonOpenMenu.gameObject.SetActive(!active);
            canvasGroup.gameObject.SetActive(!active);
        }

        private void SignalButtonOpenMenu()
        {
            isOpen = !isOpen;
            if (!isOpen) Close();
            else Open();
        }

        private void Open()
        {
            print("MenuWindow open");

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOKill();
            canvasGroup.DOFade(1, speed).SetUpdate(true);
            timeManager.Pause();
            isOpen = true;
        }

        private void Close()
        {
            print("MenuWindow close");

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOKill();
            canvasGroup.DOFade(0, speed).SetUpdate(true); ;
            timeManager.UnPause();
            isOpen = false;
        }
    }
}
