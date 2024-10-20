using System;
using UnityEngine;

namespace Utility.Audio
{
	/// <summary>
	/// Audio entry in Audio Hub. Defined in the Inspector
	/// </summary>
	[Serializable]
	public class CustomClip
	{
		[SerializeField] string name;
		public string audioName { get { return name; } }
		[SerializeField] AudioClip clip;
		public AudioClip audioClip { get { return clip; } }
		[SerializeField] ClipType type;
		public ClipType clipType { get { return type; } }

		public float volume;

		[HideInInspector] public AudioSource source;

		public static CustomClip Empty =
			new CustomClip(null, null, null, ClipType.Empty, 0);

		public CustomClip(string name, AudioClip clip, AudioSource source, ClipType type, float volume)
		{
			this.name = name;
			this.clip = clip;
			this.source = source;
			this.type = type;
			this.volume = volume;
		}

		public CustomClip(CustomClip clip)
		{
			this.name = clip.name;
			this.clip = clip.clip;
			this.source = clip.source;
			this.type = clip.type;
			this.volume = clip.volume;
		}
	}
}