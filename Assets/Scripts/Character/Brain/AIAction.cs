using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Brain
{
	/// <summary>
	/// Actions are behaviours and describe what your character is doing. Examples include patrolling, shooting, jumping, etc. 
	/// </summary>
	public abstract class AIAction : MonoBehaviour
	{
        public enum UpDateModes { EveryTime, OnlyOnce, }
		public UpDateModes UpDateMode = UpDateModes.EveryTime;
		protected bool initialized { get; set; }

		public string Label;
		protected AIBrain _brain;

        /// <summary>
        /// Вызывается при входе в состояние
        /// </summary>
        [SerializeField] private UnityEvent OnEnter;
		/// <summary>
		/// Вызывается при выходе из состояния
		/// </summary>
		[SerializeField] private UnityEvent OnExit;

		/// <summary>
		/// Выполнение действия
		/// </summary>
		public abstract void PerformAction();
		/// <summary>
		/// Initializes the action. Meant to be overridden
		/// </summary>
		public virtual void Initialization(AIBrain aIBrain)
		{
			_brain = aIBrain;
            initialized = true;
		}
		/// <summary>
		/// Describes what happens when the brain enters the state this action is in. Meant to be overridden.
		/// </summary>
		public virtual void OnEnterState()
		{
			OnEnter?.Invoke();
		}
		/// <summary>
		/// Describes what happens when the brain exits the state this action is in. Meant to be overridden.
		/// </summary>
		public virtual void OnExitState()
		{
			OnExit?.Invoke();
		}
	}
}