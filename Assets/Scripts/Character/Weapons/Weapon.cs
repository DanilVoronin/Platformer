using UnityEngine;
using System;

namespace Assets.Scripts.Character.Weapons
{
    /// <summary>
    /// Базовый класс оружия
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        /// <summary>
        /// Состояние оружия
        /// </summary>
        [field : SerializeField] public WeaponsState WeaponsState { get; private set; }

        public event Action OnStopAttack;

        public void FixedUpdate()
        {
            switch (WeaponsState)
            {
                case WeaponsState.Idle: Idle(); break;
                case WeaponsState.StartAttack: StartAttack(); break;
                case WeaponsState.Attack: Attack(); break;
                case WeaponsState.StopAttack: StopAttack(); break;
            }
        }

        protected virtual void Idle() { }
        protected virtual void StartAttack() 
        {
            WeaponsState = WeaponsState.Attack;
        }
        protected virtual void Attack() 
        {
            WeaponsState = WeaponsState.StopAttack;
        }
        protected virtual void StopAttack() 
        {
            WeaponsState = WeaponsState.Idle;
            OnStopAttack?.Invoke();
        }


        /// <summary>
        /// Пытается установить атакующее действие
        /// </summary>
        public bool SetAttack()
        {
            if (WeaponsState == WeaponsState.Idle) 
            {
                WeaponsState = WeaponsState.StartAttack;
                return true;
            };
            return false;
        }
    }
}
