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
	List<ObjectPooler<PoolableEnemy>> pooler;

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
	
	public float interval, time;
	public List<SpawnPoint> spawnPoints;

	public void Spawn()
	{
		time -= Time.deltaTime;
		if (time <= 0)
		{
			time = interval;
			PoolableEnemy enemy = pooler[RandomStream.NextInt(0, pooler.Count)].GetObject();

			SpawnPoint point = spawnPoints[RandomStream.NextInt(0, spawnPoints.Count)];
			if(point.occupied) { return; }

			point.occupant = enemy;
			enemy.transform.position = point.position;
			enemy.Activate(0);
		}
	}

	#endregion Spawn

	#region Update

	public bool active => gameObject.activeInHierarchy;

	public void FrameUpdate()
	{
		Spawn();
	}

	public void PhysicsUpdate() {}

	#endregion Update
}