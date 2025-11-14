using Assets.Scripts.Character.Weapons;
using UnityEngine;

namespace Assets.Scripts.Brain.AIActions
{
    /// <summary>
    /// Атакует оружием
    /// </summary>
    public class AAttackWeaponRemote : AIAction
    {
        [SerializeField] private WeaponsRemote weaponsRemote;

        public override void PerformAction()
        {
            if (_brain.Target && weaponsRemote.WeaponsState == WeaponsState.Idle)
            {
                weaponsRemote.SetTarget(_brain.Target.transform);
                weaponsRemote.SetAttack();
            }
        }
    }
}
