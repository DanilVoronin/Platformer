using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Передвижение игрока
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class AbilityMove : Ability
    {
        [SerializeField, Tooltip("Максимальная скорость")] 
        private float maxSpeed;
        [SerializeField, Tooltip("Кривая набора скорости")] 
        private AnimationCurve animationCurveMove;

        private new Rigidbody2D rigidbody2D;
        private Ground ground;

        [SerializeField] private float x;
        private ContactPoint2D[] contacts = new ContactPoint2D[1];

        private Vector2 targetPosition;

        protected override void InitAbility()
        {
            base.InitAbility();

            player.TryGetComponent(out rigidbody2D);
            player.TryGetComponent(out ground);

            UpdateAnimationCurve();

            //player.PlayerInput.InputActionMove.performed += InputActionMove_performed;
            player.PlayerInput.InputActionMove.canceled += InputActionMove_canceled;
        }

        public override void UpdateAbility()
        {
            if (player.PlayerInput.IsBlock())
            {
                SetMove(0);
                return;
            }
            x = player.PlayerInput.InputActionMove.ReadValue<Vector2>().x;

            if (player.UnitState == UnitState.Run && x == 0)
            {
                player.SetUnitState(UnitState.Idle);
            }

            if (x == 0)
            {
                SetMove(x);
                return;
            }

            if (!IsPermission())
            {
                if(ground.IsGround) x = 0;
                SetMove(x);
                return;
            }

            if (!ground.IsGround &&
                rigidbody2D.GetContacts(contacts) > 0)
            {
                return;
            }

            if(player.UnitState != UnitState.Run && !IsBlockTransmite())
                player.SetUnitState(UnitState.Run);

            if (player.UnitState == UnitState.Jump &&
               rigidbody2D.linearVelocityY == 0)
            {
                return;
            }

            SetMove(x);
        }

        public void SetMaxSpeed(float speed)
        {
            maxSpeed = speed;
            UpdateAnimationCurve();
        }

        private void InputActionMove_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            x = 0;
            if (player.PlayerInput.IsBlock()) return;
            if (player.UnitState == UnitState.Run) 
            {
                SetMove(x);
                player.SetUnitState(UnitState.Idle);
            }
        }

        private void InputActionMove_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            x = obj.ReadValue<Vector2>().x;
            print(x);
        }

        private void SetMove(float direction)
        {
            rigidbody2D.linearVelocityX = animationCurveMove.Evaluate(direction);
        }

        private void UpdateAnimationCurve()
        {
            Keyframe start = animationCurveMove.keys[0];
            Keyframe end = animationCurveMove.keys[animationCurveMove.keys.Length - 1];

            animationCurveMove.MoveKey(0,
                new Keyframe()
                {
                    time = -1,
                    value = -maxSpeed,
                    inTangent = start.inTangent,
                    outTangent = start.outTangent,
                });
            animationCurveMove.MoveKey(animationCurveMove.keys.Length - 1,
                new Keyframe()
                {
                    time = 1,
                    value = maxSpeed,
                    inTangent = end.inTangent,
                    outTangent = end.outTangent,
                });
        }
    }
}
