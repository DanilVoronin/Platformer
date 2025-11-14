using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Scripts.Character.Player
{
    /// <summary>
    /// Определяет значение ввода для конкретного игрока
    /// </summary>
    [RequireComponent(typeof(Player))]
    public class PlayerInput : MonoBehaviour
    {
        /// <summary>
        /// Ассет ввода
        /// </summary>
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] public InputAction InputActionMove { get; private set; }
        [SerializeField] public InputAction InputActionAttack { get; private set; }
        [SerializeField] public InputAction InputActionJump { get; private set; }
        
        private Player player;
        private bool block;

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="player"></param>
        public void Init(Player player)
        {
            if (this.player) return;
            this.player = player;

            InputActionMap inputActionMap = null;
            foreach (InputActionMap inputActions in inputActionAsset.actionMaps)
            {
                if (inputActions.name == player.PlayerId)
                {
                    inputActionMap = inputActions;
                }
            }
            if (inputActionMap == null) Debug.LogError($"Не найдена карта ввода игрока {player.PlayerId}");

            InputActionMove = inputActionMap.actions.FirstOrDefault(x => x.name == "Move");
            InputActionAttack = inputActionMap.actions.FirstOrDefault(x => x.name == "Attack");
            InputActionJump = inputActionMap.actions.FirstOrDefault(x => x.name == "Jump");
        }

        /// <summary>
        /// Статус блокировки
        /// </summary>
        /// <returns></returns>
        public bool IsBlock() => block;

        /// <summary>
        /// Блокировка управления
        /// </summary>
        public void Block(bool block)
        {
            this.block = block;
        }
    }
}
