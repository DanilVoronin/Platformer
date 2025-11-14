using Assets.Scripts.Character.Damages;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.Character
{
    /// <summary>
    /// Компонент здоровья
    /// </summary>
    public class Health : MonoBehaviour
    {
        [field: SerializeField]
        public float StartHealth { get; private set; }

        [field : SerializeField] 
        public float CurrentHealth { get; private set; }

        [field: SerializeField]
        public bool IsImmortal { get; private set; }

        public event Action OnDeath;
        public event Action OnReviv;
        public event Action OnDamage;

        public UnityEvent OnDeathUnityEvent;
        public UnityEvent OnRevivUnityEvent;
        public UnityEvent OnDamageUnityEvent;

        private void Awake()
        {
            CurrentHealth = StartHealth;
        }

        public void SetDamage(Damage damage)
        {
            if (IsImmortal)
            { 
                OnDamage?.Invoke();
                return;
            }

            if (CurrentHealth <= 0) return;

            CurrentHealth -= damage.DamageSize;
            OnDamageUnityEvent?.Invoke();
            OnDamage?.Invoke();

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath?.Invoke();
                OnDeathUnityEvent?.Invoke();
            }
        }

        /// <summary>
        /// Тестовое воскрешение
        /// </summary>
        [ContextMenu("SetReviv")]
        private void SetReviv()
        {
            if (CurrentHealth <= 0)
            {
                CurrentHealth = StartHealth;
                OnReviv?.Invoke();
                OnRevivUnityEvent?.Invoke();
            }
        }
    }
}
