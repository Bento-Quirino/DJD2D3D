using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.SceneCamera
{
	public class CameraRaycaster : MonoBehaviour
	{
		public RaycastHit Raycast(float distance, LayerMask mask)
		{
			Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
			RaycastHit hit;
			Physics.Raycast(transform.position, transform.forward, out hit, distance, mask);
			return hit;
		}

		public RaycastHit[] RaycastAll(float distance, LayerMask mask)
		{
			Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
			return Physics.RaycastAll(transform.position, transform.forward, distance, mask);
		}
	}
}
