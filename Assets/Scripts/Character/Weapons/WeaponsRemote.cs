using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Character.Weapons
{
    /// <summary>
    /// Дистанционное оружие
    /// </summary>
    public class WeaponsRemote : Weapon
    {
        [Tooltip("Время до автивации в миилисекундах")]
        [SerializeField] private int delay;

        [Tooltip("Префаб снаряда")]
        [SerializeField] private Projectile rojectile;

        [Tooltip("Информация об атаки снаряда")]
        [SerializeField] private Damages.Damage damage;


        private bool attack = false;
        private Transform target;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        protected async override void Attack()
        {
            if (attack) return;

            attack = true;

            Projectile projectile = Instantiate(rojectile, transform.position, Quaternion.identity);

            Damages.Damage d = new Damages.Damage();
            d.DamageSize = damage.DamageSize;
            d.LayerMask = damage.LayerMask;
            d.Radius = damage.Radius;
            d.Speed = damage.Speed;
            d.Direction = (target.position - transform.position).normalized;

            projectile.Init(d);

            await UniTask.Delay(delay);
            
            attack = false;

            base.Attack();
        }
    }
}
