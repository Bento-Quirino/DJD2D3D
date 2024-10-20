using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EasingEquations;
using Utility.EventCommunication;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public Vector3 inicialPosition;
    public Vector3 endPosition;

    public float distance => Vector3.Distance(inicialPosition, transform.localScale);

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float t = 0;
        while(t <= 1.01f)
        {
            transform.localScale = EasingVector3Equations.Linear(inicialPosition, endPosition, t);
            t += speed * Time.deltaTime;

            if(distance <= 0.1f)
            {
                EventHub.Publish(EventList.PlayerLose);
            }

            yield return null;
        }
    }
}