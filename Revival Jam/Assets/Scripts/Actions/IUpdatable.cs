using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{

	public bool active { get; }
	public void FrameUpdate();

	public void PhysicsUpdate();
}
