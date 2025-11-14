using Assets.Scripts.Brain;
using UnityEngine;

namespace Assets.Scripts.Character.Enemys
{
    /// <summary>
    /// Описывает базового врага
    /// </summary>
    [RequireComponent(typeof(AIBrain))]
    public class Enemy : Unit
    {
        private AIBrain AIBrain;

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out AIBrain);
            AIBrain.InitBrain(this);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            AIBrain.UpdateBrain();
        }
    }
}
