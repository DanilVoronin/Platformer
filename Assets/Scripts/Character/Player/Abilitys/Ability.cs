using UnityEngine;

namespace Assets.Scripts.Character.Player.Abilitys
{
    /// <summary>
    /// Абстрактный класс способности
    /// </summary>
    [RequireComponent(typeof(Player))]
    public abstract class Ability : MonoBehaviour
    {
        [field : SerializeField] protected Permission permission { get; set; }
        [field : SerializeField] protected Permission blockTransmite { get; set; }
        protected Player player;

        /// <summary>
        /// Обновление способности
        /// </summary>
        public virtual void UpdateAbility() { }
        /// <summary>
        /// Инициализация способности
        /// </summary>
        protected virtual void InitAbility() { }

        /// <summary>
        /// Основная инициализация способности
        /// </summary>
        /// <param name="player"></param>
        public void Init(Player player)
        {
            this.player = player;
            InitAbility();
        }

        protected bool IsPermission()
        {
            return permission.IsAllowed(player.UnitState);
        }

        protected bool IsBlockTransmite()
        {
            return blockTransmite.IsAllowed(player.UnitState);
        }
    }
}
