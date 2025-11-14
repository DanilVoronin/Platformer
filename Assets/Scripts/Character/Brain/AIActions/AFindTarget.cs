using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.Brain.AIActions
{
    /// <summary>
    /// Ищет цель (например для атаки)
    /// </summary>
    public class AFindTarget : AIAction
    {
        [Tooltip("Дистанция поиска")]
        [SerializeField] private float distance;

        [Tooltip("Маска поиска")]
        [SerializeField] private LayerMask layerMask;

        public override void PerformAction()
        {
            if (!_brain.Target)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, distance, layerMask);
                foreach(Collider2D collider2D in collider2Ds)
                {
                    if (collider2D.TryGetComponent<Player>(out var player))
                    {
                        _brain.SetTarget(player);
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distance);
        }
    }
}
