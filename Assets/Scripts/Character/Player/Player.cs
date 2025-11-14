using UnityEngine;
using Assets.Scripts.Character.Player.Abilitys;

namespace Assets.Scripts.Character.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : Unit
    {
        /// <summary>
        /// Id игрока (на случай игры нескольких игроков)
        /// </summary>
        [field: SerializeField] public string PlayerId { get; private set; }

        public PlayerInput PlayerInput { get; private set; }
        private Ability[] abilitys;

        public void Death() => SetUnitState(UnitState.Death);

        protected override void Awake()
        {
            base.Awake();

            abilitys = GetComponentsInChildren<Ability>(true);

            if (TryGetComponent<PlayerInput>(out var playerInput))
            {
                PlayerInput = playerInput;
                PlayerInput.Init(this);
            }
            else
            {
                Debug.LogError("На игроке отсутствует система ввода PlayerInput!");
            }

            foreach (Ability ability in abilitys) ability.Init(this);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            foreach (Ability ability in abilitys) ability.UpdateAbility();
        }
    }
}