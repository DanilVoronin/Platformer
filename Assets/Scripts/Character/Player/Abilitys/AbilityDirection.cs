using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Меняет визуальное направление движения
    /// </summary>
    public class AbilityDirection : Ability
    {
        //private SpriteRenderer spriteRenderer;
        private Vector3 localScale = Vector3.one;

        private void Awake()
        {
        }

        protected override void InitAbility()
        {
            base.InitAbility();
            //TryGetComponent(out spriteRenderer);

            player.PlayerInput.InputActionMove.performed += InputActionMove_performed;
        }

        private void InputActionMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (player.PlayerInput.IsBlock()) return;
            if (!IsPermission()) return;

            float x = obj.ReadValue<Vector2>().x;
            if (x == 0) return;
            //spriteRenderer.flipX = x > 0;

            localScale.x = x > 0 ? 1 : -1;
            transform.localScale = localScale;
        }
    }
}
