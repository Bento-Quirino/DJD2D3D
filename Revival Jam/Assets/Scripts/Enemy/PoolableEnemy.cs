using System.Collections;
using UnityEngine;
using Utility.Pooling;

public class PoolableEnemy : MonoBehaviour, IPoolableObject
{
  
    int index;
    public int poolIndex { get => index; set { if (index <= 0) index = value; } }
    SpawnPoint Spawnpoint;
    public bool activeInScene => gameObject.activeInHierarchy;

    public void Activate(float duration)
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Spawnpoint.ReleaseSpawnPoint();
        gameObject.SetActive(false);
    }
    public void SetSpawnPoint(SpawnPoint point)
    {
        Spawnpoint = point;
        Spawnpoint.SetOccupied(this);
    }
}
