using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EventCommunication;
using Utility.Pooling;
using Utility.Random;

public class EnemySpawner : MonoBehaviour, IUpdatable
{
    #region Pooling

    public PoolableEnemy[] prefab;
    public List<ObjectPooler<PoolableEnemy>> pooler;

    private void Awake()
    {
        pooler = new();
        for (int i = 0; i < prefab.Length; i++)
        {
            GameObject g = new("Enemy Storage " + i);
            pooler.Add(new ObjectPooler<PoolableEnemy>(prefab[i], 20, Vector3.down * 5000, true, g.transform));
        }
    }

    private void Start()
    {
        EventHub.Publish(EventList.AddUpdate, new EventData(this));
    }
    #endregion Pooling

    #region Spawn

    public float intervalMax, time;
    public float intervalMin;
    public List<SpawnPoint> spawnPoints;

    public void Spawn()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = RandomStream.NextFloat(intervalMin, intervalMax);
            SpawnPoint point = spawnPoints[RandomStream.NextInt(0, spawnPoints.Count)];

            if (!point.IsOccupied)
            {
                PoolableEnemy enemy = pooler[RandomStream.NextInt(0, pooler.Count)].GetObject();
                enemy.SetSpawnPoint(point);
                enemy.transform.position = point.position;
                enemy.Activate(0);
             

            }

        }
    }






    #endregion Spawn

    #region Update

    public bool active => gameObject.activeInHierarchy;

    public void FrameUpdate()
    {
        Spawn();
    }

    public void PhysicsUpdate() { }

    #endregion Update
}
