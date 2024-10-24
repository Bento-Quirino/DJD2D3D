using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.FSM;

public class PauseGameState : AbstractState
{
	bool pause;

	public override IEnumerator OnEnterIntervaled()
	{
		yield return null;
		pause = true;
		Time.timeScale = 0;
	}

	public override IEnumerator OnExitIntervaled()
	{
		pause = false;
		yield return null;
	}

	private void Update()
	{
		if (!pause)
			return;

		if (Input.GetKeyDown(KeyCode.Escape))
		{ machine.ChangeStateCoroutine<UpdateGameState>(); }
	}
}
