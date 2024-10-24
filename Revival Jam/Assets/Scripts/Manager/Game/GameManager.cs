using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.FSM;

public class GameManager : AbstractMachine
{
	private void Start()
	{
		ChangeStateCoroutine<StartGameState>(0.1f);
	}
}
