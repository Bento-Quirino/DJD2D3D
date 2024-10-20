using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.FSM
{
	/// <summary>
	/// Machine of FSM class.
	/// Maintain states as componentes through a child object.
	/// </summary>
	public abstract class AbstractMachine : MonoBehaviour
	{
		/// <summary>
		/// List of current states available.
		/// </summary>
		[SerializeField] protected List<AbstractState> states;

		/// <summary>
		/// GameObject that hold states as components.
		/// </summary>
		protected GameObject stateStorage;

		/// <summary>
		/// Show current state in Inspector.
		/// </summary>
		[SerializeField] AbstractState viewCurrentState;

		/// <summary>
		/// Executing state.
		/// </summary>
		public AbstractState runningState
		{
			get { return viewCurrentState; }
			protected set { viewCurrentState = value; }
		}

		/// <summary>
		/// Indicates if machine is transitioning between states.
		/// </summary>
		public bool inTransition { get; private set; }

		protected virtual void Awake()
		{
			BuildStateList();
		}

		/// <summary>
		/// Create states' storage, if there is no child.
		/// Otherwise, get states' storage reference and build states' list.
		/// </summary>
		protected virtual void BuildStateList()
		{
			states = new List<AbstractState>();
			AbstractState ab = GetComponentInChildren<AbstractState>();
			if (ab != null)
			{
				stateStorage = ab.gameObject;
				AbstractState[] s = stateStorage.GetComponents<AbstractState>();
				for (int i = 0; i < s.Length; ++i)
				{
					s[i].machine = this;
					states.Add(s[i]);
				}
			}
			else
			{
				stateStorage = new GameObject("State Storage");
				stateStorage.transform.parent = gameObject.transform;
			}
		}

		/// <summary>
		/// Add the given state as a component. Inserts in the list and storage.
		/// </summary>
		/// <typeparam name="T">Type of given state to add.</typeparam>
		/// <returns>If successful, return the state just added.</returns>
		protected virtual T AddState<T>() where T : AbstractState
		{
			T s = stateStorage.GetComponent<T>();
			if (s == null)
			{
				s = stateStorage.AddComponent<T>();
				s.machine = this;
				states.Add(s);
			}
			return s;
		}

		/// <summary>
		/// Remove a state from machine by removing from list and destroing the component.
		/// Only destroy states that aren't the current one running, and outside transitions.
		/// </summary>
		/// <typeparam name="T">State to destroy.</typeparam>
		/// <returns>True if state was destroied.</returns>
		public virtual bool RemoveState<T>() where T : AbstractState
		{
			if (inTransition)
			{ PrintConsole.Warning("Can't remove in transition"); return false; }

			T s = stateStorage.GetComponent<T>();
			if (s == null)
			{ PrintConsole.Error("State not found"); return false; }
			if (s == runningState)
			{ PrintConsole.Error("Can't remove the current state running"); return false; }

			if (states.Contains(s))
			{ states.Remove(s); }
			Destroy(s);
			return true;
		}

		/// <summary>
		/// Check if the machine has a given state. 
		/// If it has, returns the state as component, if not, return null.
		/// </summary>
		/// <typeparam name="T">State to search for.</typeparam>
		/// <param name="includeDisabled">If false, return only enabled state.</param>
		/// <returns>Return state as component, if it exists, or null, if not.</returns>
		public virtual T HasState<T>(bool includeDisabled = true) where T : AbstractState
		{
			T s = stateStorage.GetComponent<T>();
			if (!includeDisabled)
			{
				if (!s.enabled)
				{ return null; }
			}
			return s;
		}

		/// <summary>
		/// Make transition between two states immediately.
		/// </summary>
		/// <typeparam name="T">\Next state to enter.</typeparam>
		/// <param name="addState">If true, when machine don't have the given state, add it as new. 
		/// If false, method understands the next state is already in list/holder.</param>
		/// <param name="setEnabled">If true, when "addState" is false, 
		/// machine changes to enabled and disabled states (activating it).
		///<br>If false, machine will change only to enabled states.</br></param>
		public virtual void ChangeState<T>(bool addState = true, bool setEnabled = false) where T : AbstractState
		{
			T s = (addState ? AddState<T>() : HasState<T>(setEnabled));
			if (s == null || s == runningState || inTransition)
			{ return; }

			if (setEnabled)
			{
				if (!states.Contains(s))
				{ states.Add(s); }
				s.enabled = true;
			}

			inTransition = true;
			if (runningState != null)
			{ runningState.OnExit(); }
			runningState = s;

			inTransition = false;
			if (runningState != null)
			{ runningState.OnEnter(); }
		}

		/// <summary>
		/// Make transition between two states with a interval time.
		/// </summary>
		/// <typeparam name="T">\Next state to enter.</typeparam>
		/// <param name="intervalTime">Interval seconds between previous state's OnExit() method and
		/// next state's OnEnter() method.</param>
		/// <param name="addState">If true, when machine don't have the given state, add it as new. 
		/// If false, method understands the next state is already in list/holder.</param>
		/// <param name="setEnabled">If true, when "addState" is false, 
		/// machine changes to enabled and disabled states (activating it).
		///<br>If false, machine will change only to enabled states.</br></param>
		public virtual void ChangeStateIntervaled<T>(float intervalTime = 0, bool addState = true, bool setEnabled = false) where T : AbstractState
		{
			T s = (addState ? AddState<T>() : HasState<T>(setEnabled));
			if (s == null || s == runningState || inTransition)
			{ return; }

			if (setEnabled)
			{
				if (!states.Contains(s))
				{ states.Add(s); }
				s.enabled = true;
			}

			StartCoroutine(ChangeInterval(s, intervalTime));
		}

		/// <summary>
		/// Make transition between two states, running Enter/Exit 
		/// coroutine versions with a interval time.
		/// </summary>
		/// <typeparam name="T">\Next state to enter.</typeparam>
		/// <param name="intervalTime">Interval seconds between previous state's OnExit() method and
		/// next state's OnEnter() method.</param>
		/// <param name="addState">If true, when machine don't have the given state, add it as new. 
		/// If false, method understands the next state is already in list/holder.</param>
		/// <param name="setEnabled">If true, when "addState" is false, 
		/// machine changes to enabled and disabled states (activating it).
		///<br>If false, machine will change only to enabled states.</br></param>
		public virtual void ChangeStateCoroutine<T>(float intervalTime = 0, bool addState = true, bool setEnabled = false) where T : AbstractState
		{
			T s = (addState ? AddState<T>() : HasState<T>(setEnabled));
			if (s == null || s == runningState || inTransition)
			{ return; }

			if (setEnabled)
			{
				if (!states.Contains(s))
				{ states.Add(s); }
				s.enabled = true;
			}

			StartCoroutine(ChangeIntervalCoroutine(s, intervalTime));
		}

		/// <summary>
		/// Coroutine that runs the OnEnter() method of next state.
		/// </summary>
		/// <param name="nextState">State to enter.</param>
		/// <param name="intervalTime">Interval seconds between previous state's OnExit() method and
		/// next state's OnEnter() method.</param>
		/// <returns></returns>
		protected virtual IEnumerator ChangeInterval(AbstractState nextState, float intervalTime)
		{
			inTransition = true;
			if (runningState != null)
			{ runningState.OnExit(); }
			runningState = nextState;

			if (intervalTime <= 0)
			{ yield return null; }
			else
			{ yield return new WaitForSeconds(intervalTime); }

			inTransition = false;
			if (runningState != null)
			{ runningState.OnEnter(); }
		}

		protected virtual IEnumerator ChangeIntervalCoroutine(AbstractState nextState, float intervalTime)
		{
			inTransition = true;
			if (runningState != null)
			{ yield return runningState.OnExitIntervaled(); }
			runningState = nextState;

			if (intervalTime <= 0)
			{ yield return null; }
			else
			{ yield return new WaitForSeconds(intervalTime); }

			inTransition = false;
			if (runningState != null)
			{ yield return runningState.OnEnterIntervaled(); }
		}

		/// <summary>
		/// Disable a given state by removing it from list and disabling it component.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Returns the given state as a component.</returns>
		public virtual T DisableState<T>() where T : AbstractState
		{
			T s = HasState<T>();
			if (s == null)
			{ PrintConsole.Warning("State not found"); return null; }
			states.Remove(s);
			s.enabled = false;
			return s;
		}

		/// <summary>
		/// Enable a given state by adding it into the list and enabling it component.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Returns the given state as a component.</returns>
		public virtual T EnableState<T>() where T : AbstractState
		{
			T s = HasState<T>();
			if (s == null)
			{ PrintConsole.Warning("State not found"); return null; }
			states.Add(s);
			s.enabled = true;
			return s;
		}
	}
}