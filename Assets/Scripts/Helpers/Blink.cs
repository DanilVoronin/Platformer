using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Мигание спрайта
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class Blink : MonoBehaviour
    {
        [SerializeField, Tooltip("Время мигания")]
        private float duration;
        [SerializeField, Tooltip("Интервал мигания")]
        private float interval;
        [SerializeField, Tooltip("Повторения")]
        private int loops;

        private SpriteRenderer spriteRenderer;
        private Sequence seq;

        private Color start = new Color(1, 1, 1, 0);
        private Color end = new Color(1, 1, 1, 0.5f);

        private void Awake()
        {
            TryGetComponent(out spriteRenderer);
        }

        [ContextMenu("SetBlink")]
        public void SetBlink()
        {
            if (seq != null) seq.Kill();

            seq = DOTween.Sequence();
            seq.Append(spriteRenderer.DOColor(end, duration));
            seq.Append(spriteRenderer.DOColor(start, duration));
            seq.AppendInterval(interval);
            seq.SetLoops(loops);
            seq.Play();
        }
    }
}
