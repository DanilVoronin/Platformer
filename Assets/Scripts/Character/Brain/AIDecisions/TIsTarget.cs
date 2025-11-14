using Assets.Scripts.Brain;

namespace Assets.Scripts.Character.Brain.AITransitions
{
    /// <summary>
    /// Переход по определению цели
    /// </summary>
    public class TIsTarget : AIDecision
    {
        public override bool Decide()
        {
            if (_brain.Target && _brain.Target.UnitState == UnitState.Death)
            {
                _brain.SetTarget(null);
            }
            return _brain.Target;
        }
    }
}
