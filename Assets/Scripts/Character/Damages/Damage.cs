using System;
using UnityEngine;

namespace Assets.Scripts.Character.Damages
{
    /// <summary>
    /// Урон
    /// </summary>
    [Serializable]
    public struct Damage
    {
        public LayerMask LayerMask;
        public float DamageSize;

        public Vector3 Direction;
        public float Radius;
        public float Speed;
    }
}
