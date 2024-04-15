using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.SceneCamera
{	
	[RequireComponent(typeof(CameraRaycaster))]
	public class SceneCamera : MonoBehaviour
	{
		void Awake()
		{
			Camera[] g = GameObject.FindObjectsOfType<Camera>();
			if (g.Length > 1) { Destroy(gameObject); return; }

			instance = this;
			mainCamera = GetComponent<Camera>();
			raycaster = GetComponent<CameraRaycaster>();
		}

		#region Singleton

		public static SceneCamera instance { get; private set; }
		public CameraRaycaster raycaster { get; private set; }
		public Camera mainCamera { get; private set; }

		#endregion
	}
}
