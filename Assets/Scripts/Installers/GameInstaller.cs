using Assets.Scripts.Managers;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private GameManager gameManager;

        public override void InstallBindings()
        {
            Container.Bind<IGameManager>()
                .FromInstance(gameManager)
                .AsSingle();
        }
    }
}
