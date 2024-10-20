using System.Collections;
using UnityEngine;

namespace Utility.FSM
{
	/// <summary>
	/// State of FSM class
	/// </summary>
	public abstract class AbstractState : MonoBehaviour
	{
		/// <summary>
		/// StateMachine owner.
		/// </summary>
		protected AbstractMachine stateMachine;

		/// <summary>
		/// Get FSM that own this state.
		/// Set FSM when there is no FSM owner.
		/// </summary>
		public AbstractMachine machine
		{
			get { return stateMachine; }
			set { if (stateMachine == null) stateMachine = value; }
		}

		/// <summary>
		/// Run when machine enter in this state
		/// </summary>
		public virtual void OnEnter() { }

		/// <summary>
		/// Run when machine enter in this state
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerator OnEnterIntervaled() { yield return null; }

		/// <summary>
		/// Run when machine enter in this state
		/// </summary>
		public virtual void OnExit() { }

		/// <summary>
		/// Run when machine enter in this state
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerator OnExitIntervaled() { yield return null; }

		/// <summary>
		/// Return if this state is of type T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public bool StateType<T>() where T : AbstractState
		{
			return this is T;
		}
	}
}