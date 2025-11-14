using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Прыжок игрока
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Ground))]
    public class AbilityJump : Ability
    {
        [SerializeField, Tooltip("Сила прыжка")]
        private float forceJump;

        private new Rigidbody2D rigidbody2D;
        private Ground ground;

        protected override void InitAbility()
        {
            base.InitAbility();
            player.TryGetComponent(out rigidbody2D);
            player.TryGetComponent(out ground);

            player.PlayerInput.InputActionJump.started += InputActionJump_started;
        }

        public override void UpdateAbility()
        {
            if (player.UnitState == UnitState.Jump &&
                rigidbody2D.linearVelocityY <= 0 &&
                ground.IsGround)
            {
                if (IsBlockTransmite()) return;

                if(rigidbody2D.linearVelocityX == 0) player.SetUnitState(UnitState.Idle);
                else player.SetUnitState(UnitState.Run);
            }
        }

        private void InputActionJump_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (player.PlayerInput.IsBlock()) return;
            if (!IsPermission() || !ground.IsGround) return;

            SetJump();
            if (IsBlockTransmite()) return;
            player.SetUnitState(UnitState.Jump);
        }

        private void SetJump()
        {
            rigidbody2D.linearVelocityY = forceJump;
        }
    }
}
