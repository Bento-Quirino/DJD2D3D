using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.FSM;
using Utility.EventCommunication;
using UnityEngine.UI;

public class UpdateGameState : AbstractState
{
	#region State

	public override IEnumerator OnEnterIntervaled()
	{
		yield return null;
		update = true;
		SetActiveButton(true);
		Time.timeScale = 1;
	}

	public override IEnumerator OnExitIntervaled()
	{
		SetActiveButton(false);
		update = false;
		yield return null;
	}

	#endregion State

	#region Updatable

	List<IUpdatable> updatables;

	private void Awake()
	{
		update = false;
		updatables = new List<IUpdatable>();
		EventHub.Subscribe(EventList.AddUpdate, AddUpdate);
	}

	void AddUpdate(EventData data)
	{
		if (data.eventInformation is IUpdatable updatable)
			if (!updatables.Contains(updatable))
				updatables.Add(updatable);
	}
	#endregion Updatable

	#region Update
	bool update;

	public void Pause()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{ machine.ChangeStateCoroutine<PauseGameState>(); }
	}

	private void Update()
	{
		if (!update) return;

		Pause();

		for (int i = 0; i < updatables.Count; i++)
		{
			if (updatables[i].active)
			{ updatables[i].FrameUpdate(); }
		}
	}

	private void FixedUpdate()
	{
		if (!update) return;

		for (int i = 0; i < updatables.Count; i++)
		{
			if (updatables[i].active)
			{ updatables[i].PhysicsUpdate(); }
		}
	}

	#endregion Update

	#region Buttons

	public Button[] buttons;

	void SetActiveButton(bool active)
	{
		for(int i =  0; i < buttons.Length; i++)
		{
			buttons[i].interactable = active;
		}
	}

	#endregion Buttons
}