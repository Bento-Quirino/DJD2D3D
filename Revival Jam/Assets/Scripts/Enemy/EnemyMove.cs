using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EasingEquations;
using Utility.EventCommunication;

public class EnemyMove : MonoBehaviour, IUpdatable
{
	private void OnEnable()
	{
    interp = 0;
		EventHub.Publish(EventList.AddUpdate, new EventData(this));
	}

	#region Update
	public bool active { get => gameObject.activeInHierarchy; }

	public void FrameUpdate()
	{
		Move();
	}
	
  public void PhysicsUpdate() { }
  #endregion Update

  float interp;
  public float speed;
  public Vector3 inicialPosition;
  public Vector3 endPosition;

  public float distance => Vector3.Distance(endPosition, transform.localScale);

	void Move()
  {
    if(interp <= 1.01f)
    {
			transform.localScale = EasingVector3Equations.Linear(inicialPosition, endPosition, interp);
			interp += speed * Time.deltaTime;

      if (distance <= 0.1f)
      {
        EventHub.Publish(EventList.PlayerLose);
      }
    }
  }
}