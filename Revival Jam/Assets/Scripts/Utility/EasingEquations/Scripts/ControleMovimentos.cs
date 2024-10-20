using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMovimentos : MonoBehaviour
{
	public Vector2 velocity;
	public Vector2 move;
	public float acceleration;
	public float k;
	public float speed;

	public void Start()
	{
		k = 0.1f;
		speed = 0;
		acceleration = 0;
	}

	public void Update()
	{
		move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (move.magnitude > 0)
		{
			acceleration = 1.61f;
			velocity = new Vector2(move.x, move.y);
			velocity.Normalize();
		}
		else
		{
			if(speed > 0)
			{
				acceleration = -1.61f;
			}
			else
			{
				acceleration = 0;
			}
		}
		speed = speed + acceleration * Time.deltaTime;
		transform.position = (Vector2)transform.position + velocity * speed * Time.deltaTime;
	}
}
