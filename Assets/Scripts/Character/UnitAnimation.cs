using UnityEngine;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Unit))]
    public class UnitAnimation : MonoBehaviour
    {
        private Unit unit;
        private Animator animator;

        private void Start()
        {
            TryGetComponent(out unit);
            TryGetComponent(out animator);

            unit.OnUpdateUnitState += Unit_OnUpdateUnitState;
            unit.Health.OnDamage += Unit_Damage;
        }

        private void Unit_Damage()
        {
            if (unit.UnitState != UnitState.Death &&
                unit.UnitState != UnitState.Reviv)
            {
                animator.SetTrigger("Damage");
            }
        }

        private void Unit_OnUpdateUnitState(UnitState obj)
        {
            switch (obj)
            {
                case UnitState.Attack: animator.SetTrigger("Attack"); break;
                case UnitState.Death: animator.SetTrigger("Death"); break;
                default: break;
            }

            animator.SetBool("Run", unit.UnitState == UnitState.Run);
            animator.SetBool("Jump", unit.UnitState == UnitState.Jump);
        }
    }
}
