using Assets.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI textCoinCount;
        private CoinsManager coinsManager;

        [Inject]
        public void Construct(CoinsManager coinsManager)
        {
            this.coinsManager = coinsManager;
            this.coinsManager.OnUpdateCoins += CoinsManager_OnUpdateCoins;

            textCoinCount.text = this.coinsManager.Count.ToString();
        }

        private void CoinsManager_OnUpdateCoins()
        {
             textCoinCount.text = coinsManager.Count.ToString();
        }
    }
}
