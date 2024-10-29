using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public PoolableEnemy occupant;
    public bool occupied => occupant != null && occupant.activeInScene;
    public Vector3 position { get; private set; }
    public bool IsOccupied => occupant != null;

    private void Awake()
    {
        position = transform.position;
    }

    public void SetOccupied(PoolableEnemy enemy)
    {
        occupant = enemy;
    }
    public void ReleaseSpawnPoint()
    {
       SetOccupied(null);
    }

}
