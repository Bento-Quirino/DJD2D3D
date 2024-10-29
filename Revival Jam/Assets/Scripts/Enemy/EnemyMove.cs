using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EasingEquations;
using Utility.EventCommunication;
using UnityEngine.SceneManagement;

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
        if (interp <= 1.01f)
        {
          
            transform.localScale = RandomEasing(inicialPosition, endPosition, interp);
            interp += speed * Time.deltaTime;

            if (distance <= 0.1f)
            {
             
                if (Random.value < 0.5f)
                {
                    gameObject.SetActive(false); // Desativa o inimigo
                }
                else
                {
                    EventHub.Publish(EventList.PlayerLose);
                    SceneManager.LoadScene("Title Scene");
                }
            }
        }
    }
    public Vector3 RandomEasing(Vector3 start, Vector3 end, float t)
    {float randomX = Mathf.Lerp(start.x, end.x, t) + Random.Range(-0.1f, 0.1f);
        float randomY = Mathf.Lerp(start.y, end.y, t) + Random.Range(-0.1f, 0.1f);
        float randomZ = Mathf.Lerp(start.z, end.z, t) + Random.Range(-0.1f, 0.1f);

        return new Vector3(randomX, randomY, randomZ);
    }

}
