using System.Collections.Generic;
using UnityEngine;
using Utility.EventCommunication;

namespace Utility.Audio
{
	public class AudioHub : MonoBehaviour
	{
		private void Awake()
		{
			if (SetInstance()) { return; }

			LoadMap();
			Subscribing();
		}

		private void OnDisable()
		{
			UnSubscribing();
		}

		#region Singleton

		public static AudioHub instance { get; private set; }
		bool SetInstance()
		{
			AudioHub[] g = GameObject.FindObjectsOfType<AudioHub>();
			if (g.Length > 1) { Destroy(gameObject); return false; }
			instance = this; DontDestroyOnLoad(gameObject); return true;
		}

		#endregion

		#region Events

		void Subscribing()
		{
			EventHub.Subscribe(EventList.AudioPlayOneTime, PlayOneTime);
			EventHub.Subscribe(EventList.AudioPlayLoop, PlayLoop);
			EventHub.Subscribe(EventList.AudioPlayIntroLoop, PlayIntroLoop);
			EventHub.Subscribe(EventList.DestroyAudioHub, AutoDestroy);
			EventHub.Subscribe(EventList.AudioStop, Stop);
			EventHub.Subscribe(EventList.AudioMute, Mute);
		}

		void UnSubscribing()
		{
			EventHub.UnSubscribe(EventList.AudioPlayOneTime, PlayOneTime);
			EventHub.UnSubscribe(EventList.AudioPlayLoop, PlayLoop);
			EventHub.UnSubscribe(EventList.AudioPlayIntroLoop, PlayIntroLoop);
			EventHub.UnSubscribe(EventList.DestroyAudioHub, AutoDestroy);
			EventHub.UnSubscribe(EventList.AudioStop, Stop);
			EventHub.UnSubscribe(EventList.AudioMute, Mute);
		}

		#endregion

		#region Load

		[SerializeField] AudioDataBase dataBase;
		Dictionary<string, CustomClip> clipMap;

		List<AudioSource> sfxSource;
		List<AudioSource> bgmSource;
		GameObject sourceContainer;

		const int audioPerSource = 32;

		void LoadMap()
		{
			sourceContainer = new GameObject("Audio Source");
			sourceContainer.transform.parent = transform;

			sfxSource = new List<AudioSource>();
			bgmSource = new List<AudioSource>();
			clipMap = dataBase.LoadTable();

			int sfxIndex = 0, sfxCount = 0;
			CustomClip[] sfx = dataBase.LoadArray(ClipType.SFX);
			for (int i = 0; i < sfx.Length; ++i)
			{
				if (sfxCount >= audioPerSource || sfxSource.Count == 0)
				{
					sfxSource.Add(sourceContainer.AddComponent<AudioSource>());
					sfxIndex++;
					sfxCount = 0;
				}
				clipMap[sfx[i].audioName].source = sfxSource[sfxIndex - 1];
				sfxCount++;
			}

			int bgmIndex = 0, bgmCount = 0;
			CustomClip[] bgm = dataBase.LoadArray(ClipType.BGM);
			for (int i = 0; i < bgm.Length; ++i)
			{
				if (bgmCount >= audioPerSource || bgmSource.Count == 0)
				{
					bgmSource.Add(sourceContainer.AddComponent<AudioSource>());
					bgmIndex++;
					bgmCount = 0;
				}
				clipMap[bgm[i].audioName].source = bgmSource[bgmIndex - 1];
				bgmCount++;
			}
		}

		#endregion

		#region Play Methods

		public void PlayOneTime(string audioName)
		{
			if (!clipMap.ContainsKey(audioName))
			{ PrintConsole.Error("No '" + audioName + "' audio found"); return; }

			clipMap[audioName].source.PlayOneShot(clipMap[audioName].audioClip,
				clipMap[audioName].volume);
		}

		void PlayOneTime(EventData data)
		{
			string audioName = (string)data.eventInformation;
			PlayOneTime(audioName);
		}

		public void PlayLoop(string audioName, bool forceSet = true)
		{
			if (!clipMap.ContainsKey(audioName))
			{ PrintConsole.Error("No '" + audioName + "' audio found"); return; }

			AudioSource source = clipMap[audioName].source;

			if (source.clip != null)
			{
				PrintConsole.Warning("Already playing '" + audioName + "' loop");
				if (!forceSet)
				{ return; }
			}

			source.volume = clipMap[audioName].volume;
			source.loop = true;
			source.clip = clipMap[audioName].audioClip;
			source.Play();
		}

		void PlayLoop(EventData data)
		{
			string audioName = (string)data.eventInformation;
			PlayLoop(audioName);
		}

		public void PlayLoop(string audioName, string introName, bool forceSet = true)
		{
			if (!clipMap.ContainsKey(audioName))
			{ PrintConsole.Error("No '" + audioName + "' audio found"); return; }

			AudioSource source = clipMap[audioName].source;

			if (source.clip != null)
			{
				PrintConsole.Warning("Already playing '" + audioName + "' loop");
				if (!forceSet)
				{ return; }
			}

			source.volume = clipMap[audioName].volume;
			source.loop = true;
			source.clip = clipMap[audioName].audioClip;
			source.PlayDelayed(clipMap[introName].audioClip.length);
			PlayOneTime(introName);
		}

		void PlayIntroLoop(EventData data)
		{
			string[] audioName = (string[])data.eventInformation;
			PlayLoop(audioName[1], audioName[0]);
		}

		#endregion

		#region End/Destroy Audio

		[SerializeField] bool isMute = false;
		public bool mute
		{
			get { return isMute; }
			set
			{
				isMute = value;
				for (int i = 0; i < sfxSource.Count; ++i)
				{ sfxSource[i].enabled = !value; }
				for (int i = 0; i < bgmSource.Count; ++i)
				{ bgmSource[i].enabled = !value; }
			}
		}

		void Mute(EventData data)
		{
			Mute();
		}

		public void Mute()
		{
			if (mute)
			{ mute = false; }
			else
			{ mute = true; }
		}

		public void Stop(string audioName)
		{
			clipMap[audioName].source.Stop();
		}

		void Stop(EventData data)
		{
			string audioName = (string)data.eventInformation;
			Stop(audioName);
		}

		void AutoDestroy(EventData data)
		{
			AutoDestroy();
		}

		public void AutoDestroy()
		{
			Destroy(this.gameObject);
		}

		#endregion
	}
}