using System.Collections.Generic;
using UnityEngine;

namespace Utility.Audio
{
	[CreateAssetMenu(fileName = "Audio DataBase",
		menuName = "Scriptable Objects/Audio DataBase")]
	public class AudioDataBase : ScriptableObject
	{
		[SerializeField] CustomClip[] clips;

		public Dictionary<string, CustomClip> LoadTable()
		{
			Dictionary<string, CustomClip> clipTable = new Dictionary<string, CustomClip>();

			for (int i = 0; i < clips.Length; ++i)
			{
				CustomClip c = new CustomClip(clips[i]);
				clipTable.Add(c.audioName, c);
			}

			return clipTable;
		}

		public Dictionary<string, CustomClip> LoadTable(ClipType type)
		{
			Dictionary<string, CustomClip> clipTable = new Dictionary<string, CustomClip>();

			for (int i = 0; i < clips.Length; ++i)
			{
				if (clips[i].clipType == type)
				{
					CustomClip c = new CustomClip(clips[i]);
					clipTable.Add(c.audioName, c);
				}
			}

			return clipTable;
		}

		public CustomClip[] LoadArray()
		{
			CustomClip[] arr = new CustomClip[clips.Length];
			for (int i = 0; i < clips.Length; ++i)
			{
				CustomClip c = new CustomClip(clips[i]);
				arr[i] = c;
			}

			return arr;
		}

		public CustomClip[] LoadArray(ClipType type)
		{
			List<CustomClip> l = new List<CustomClip>();
			for (int i = 0; i < clips.Length; ++i)
			{
				if (clips[i].clipType == type)
				{
					CustomClip c = new CustomClip(clips[i]);
					l.Add(c);
				}
			}
			return l.ToArray();
		}
	}
}