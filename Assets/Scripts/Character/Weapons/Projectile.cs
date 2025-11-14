using UnityEngine;
using Assets.Scripts.Character.Player;
using Assets.Scripts.Character.Damages;

namespace Assets.Scripts.Character.Weapons
{
    /// <summary>
    /// Снаряд дистанционного оружия
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        private Damage damage;

        /// <summary>
        /// Инициализация снаряда
        /// </summary>
        public void Init(Damage damage)
        {
            this.damage = damage;
            Destroy(gameObject, 5);
        }

        private void FixedUpdate()
        {
            RaycastHit2D raycastHit2D = Physics2D.CircleCast(transform.position, damage.Radius, damage.Direction, 0, damage.LayerMask);
            if (raycastHit2D.collider != null)
            {
                if (raycastHit2D.collider.TryGetComponent<Player.Player>(out var Players))
                {
                    Players.Health.SetDamage(damage);

                    ///Тут надо использовать пул объектов и вернуть в пул
                    ///Но :) ...
                    ///TMP
                    Destroy(gameObject);
                    return;
                }
            }
            transform.position += (damage.Direction * damage.Speed);
        }
    }
}
