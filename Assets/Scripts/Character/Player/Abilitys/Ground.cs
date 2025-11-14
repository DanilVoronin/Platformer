using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Проверяет находится ли персонаж на земле
    /// </summary>

    public class Ground : Ability
    {
        public bool IsGround 
        {
            get => Physics2D.OverlapCircle(transform.position + distanceSphere, radiusSphere, groundMask);
        }

        [SerializeField, Tooltip("Маска земли")]
        private LayerMask groundMask;

        [SerializeField, Tooltip("Дистанция сферы от центра объекта")]
        private Vector3 distanceSphere;

        [SerializeField, Tooltip("Радиус сферы для определения контакта с землей")]
        private float radiusSphere;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position + distanceSphere, radiusSphere);
        }
    }
}
