using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public PoolableEnemy occupant;
	public bool occupied => occupant != null && occupant.activeInScene;
	public Vector3 position {  get; private set; }

	private void Awake()
	{
		position = transform.position;
	}
}