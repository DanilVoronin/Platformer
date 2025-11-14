using Assets.Scripts.Character.Damages;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Character.Weapons
{
    public class WeaponsMelee : Weapon
    {
        [Tooltip("Зона атаки")]
        [SerializeField] private DamageZone damageZone;

        [Tooltip("Время до автивации в миилисекундах")]
        [SerializeField] private int delayBeforeActivation;

        [Tooltip("Время которое зона будет активна в миилисекундах")]
        [SerializeField] private int activationTime;

        [Tooltip("Время после автивации в миилисекундах")]
        [SerializeField] private int delayАfterАctivation;

        private bool attack = false;

        private void Awake()
        {
            damageZone.enabled = false;
        }

        protected async override void Attack()
        {
            if (attack) return;

            attack = true;

            await UniTask.Delay(delayBeforeActivation);
            damageZone.Active(true);
            await UniTask.Delay(activationTime);
            damageZone.Active(false);
            await UniTask.Delay(delayАfterАctivation);

            attack = false;

            base.Attack();
        }
    }
}
