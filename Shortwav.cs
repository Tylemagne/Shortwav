//https://github.com/Tylemagne/Shortwav

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//documentations
//https://answers.unity.com/questions/963843/audiosource-play-certain-time-range-1.html
//https://docs.unity3d.com/ScriptReference/AudioSource-time.html
//https://docs.unity3d.com/ScriptReference/AudioSource-timeSamples.html


public class Shortwav : MonoBehaviour
{
	public bool powerOn;
	public int currentStation;
	public AudioClip currentAudioClip;
	public float currentAudioTracking;

	[Header("Sound Emitter (Speaker)")]
	public AudioSource source;

	[Header("Commentary Emitter (ideally same location)")]
	public AudioSource csource;

	[Header("UIText Destination")]
	public Text radioText;

	[Header("Transition Sound(s)")]
	public AudioClip[] transitions;

	[Header("Dead Air Sound(s) for locked station")]
	public AudioClip[] deadAirSounds;

	[Header("Random Breaks/ads")]
	public AudioClip[] ads;

	[Header("This file will trigger a Random ad/break instead")]
	[Header("Use this SAME file on breaks you want randomized")]
	public AudioClip triggerAd;

	[Header("Stations & Chained Station Audio")]
	public Station[] stations;

	[Header("See Debug Text")]
	public bool debugMode;






	void Start ()
	{

		Initialize ();
	}
	

	void Update ()
	{
		
	}

	void Initialize()
	{
		source.loop = false;
		radioText.text = "Shortwav";
		SetStation (0);
	}


	public void SetStation(int stationID)
	{
		currentStation = stationID;
		currentAudioClip = stations[stationID].StationAudio[0]; //first station on the list, first audio in the station
		source.clip = currentAudioClip;
		source.Play();
		radioText.text = stations [currentStation].StationName;
	}


	public void ChangeStation(bool direction)
	{
		SetStation (1);
	}

	[System.Serializable]
	public class Station
	{
		public bool locked;
		public string StationName;
		public AudioClip[] StationAudio;
		public AudioClip[] StationCommentary;
	}
}
