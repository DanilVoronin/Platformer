using Assets.Scripts.Character.Weapons;
using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Способность атакует оружием
    /// </summary>
    public class AbilityAttack : Ability
    {
        [SerializeField] private Weapon weapon;

        protected override void InitAbility()
        {
            base.InitAbility();
            player.PlayerInput.InputActionAttack.started += InputActionAttack_started;

            weapon.OnStopAttack += Weapon_OnStopAttack;
        }

        private void Weapon_OnStopAttack()
        {
            if (IsBlockTransmite()) return;
            if (player.UnitState == UnitState.Attack)
            {
                player.SetUnitState(UnitState.Idle);
            }
        }

        private void InputActionAttack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (player.PlayerInput.IsBlock()) return;
            if (!IsPermission()) return;

            if (weapon.SetAttack())
            {
                player.SetUnitState(UnitState.Attack);
            }
        }
    }
}
