using UnityEngine;
using UnityEngine.Events;
using Assets.Extensions;

namespace Assets.Scripts.Character.Damages
{
    /// <summary>
    /// Атакующую зона
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class DamageZone : MonoBehaviour
    {
        [field : SerializeField]
        public Damage damageSize { get; private set; }

        [field: SerializeField]
        public new Collider2D collider2D { get; private set; }

        [field: SerializeField]
        public UnityEvent OnDamage { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!damageSize.LayerMask.IsLayerInMask(collision.gameObject.layer)) return;
            if (collision.TryGetComponent<Health>(out var health))
            {
                health.SetDamage(damageSize);
                OnDamage?.Invoke();
            }
        }

        public void Active(bool active)
        {
            collider2D.enabled = active;
        }
    }
}
