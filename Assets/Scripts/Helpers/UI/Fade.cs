using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Assets.Scripts.Helpers.UI
{
    /// <summary>
    /// Затеменение экрана
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class Fade : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float time;

        private TweenerCore<float, float, FloatOptions> t;

        private void OnValidate()
        {
            TryGetComponent(out canvasGroup);
        }
        private void Awake()
        {
            if(!canvasGroup) TryGetComponent(out canvasGroup);
            canvasGroup.alpha = 0;
        }

        public void SetInFade()
        {
            t = canvasGroup.DOFade(1, time);
        }

        public void SetOutFade()
        {
            t = canvasGroup.DOFade(0, time);
        }

        public bool IsProgress() => t.active;
    }
}
