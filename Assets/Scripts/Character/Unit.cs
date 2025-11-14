using UnityEngine;
using System;

namespace Assets.Scripts.Character
{
    /// <summary>
    /// Базовый класс персонажа
    /// </summary>
    [RequireComponent(typeof(Health))]
    public class Unit : MonoBehaviour
    {
        /// <summary>
        /// Тип юнита
        /// </summary>
        //[field : SerializeField] public UnitType UnitType { get; private set; }
        /// <summary>
        /// Состояние юнита
        /// </summary>
        [field: SerializeField] public UnitState UnitState { get; private set; }

        public event Action<UnitState> OnUpdateUnitState;

        /// <summary>
        /// Здоровье юнита
        /// </summary>
        public Health Health { get => health; }

        protected Health health;

        protected virtual void Awake()
        {
            TryGetComponent(out health);

            health.OnDeath += Health_OnDeath;
            health.OnReviv += Health_OnReviv;

            SetUnitState(UnitState.Idle);
        }

        protected virtual void Health_OnReviv()
        {
            SetUnitState(UnitState.Reviv);
        }

        protected virtual void Health_OnDeath()
        {
            SetUnitState(UnitState.Death);
        }

        protected virtual void FixedUpdate()
        {

        }

        protected virtual void Update()
        {

        }

        /// <summary>
        /// Устанавливает состояние юнита
        /// </summary>
        /// <param name="unitState"></param>
        public void SetUnitState(UnitState unitState)
        { 
            UnitState = unitState;
            OnUpdateUnitState?.Invoke(UnitState);
        }
    }
}
