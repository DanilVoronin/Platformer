using UnityEngine;
using Zenject;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Монетка :)
    /// </summary>
    [RequireComponent(typeof(Trigger))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int countAdd = 1;

        private CoinsManager coinsManager;
        private Trigger trigger;

        [Inject]
        public void Construct(CoinsManager coinsManager)
        {
            this.coinsManager = coinsManager;

            if (TryGetComponent(out trigger))
            {
                trigger.OnEnter += Trigger_OnEnter;
            }
        }

        private void Trigger_OnEnter()
        {
            coinsManager.AddCoin(countAdd);
        }
    }
}
