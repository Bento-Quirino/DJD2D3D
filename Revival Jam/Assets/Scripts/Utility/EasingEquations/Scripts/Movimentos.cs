using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentos : MonoBehaviour
{
	public float speed;
	public Vector2 velocity;
	public float acceleration;
	public float k;

	public void Start()
	{
		velocity = new Vector2(1, 0);
		k = 0.1f;
		speed = velocity.magnitude;
		acceleration = 0;
	}

	public void Update()
	{
		acceleration = k * speed * speed;
		speed = speed + acceleration * Time.deltaTime;
		transform.position = (Vector2)transform.position + velocity * speed * Time.deltaTime;
	}
}
