using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.FSM;

public class StartGameState : AbstractState
{
	public override IEnumerator OnEnterIntervaled()
	{
		machine.ChangeStateCoroutine<UpdateGameState>();
		yield return null;
	}
}
