using Assets.Scripts.Managers;
using Zenject;
using UnityEngine;
using Assets.Scripts.Helpers.UI;

namespace Assets.Scripts.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelManager levelManager;

        [SerializeField]
        private Fade fade; 
        
        [SerializeField]
        private TimeManager timeManager;

        [SerializeField]
        private CoinsManager coinsManager;

        public override void InstallBindings()
        {
            Container.Bind<ILevelManager>()
                .FromInstance(levelManager)
                .AsSingle();

            Container.Bind<Fade>()
                .FromInstance(fade)
                .AsSingle();
            
            Container.Bind<TimeManager>()
                .FromInstance(timeManager)
                .AsSingle();

            Container.Bind<CoinsManager>()
                .FromInstance(coinsManager)
                .AsSingle();
        }
    }
}
