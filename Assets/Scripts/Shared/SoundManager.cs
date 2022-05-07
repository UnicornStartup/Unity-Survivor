using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioClip shootFire, music, btnClick;
	
	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;			
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}
	public void Start()
	{
		music = Resources.Load<AudioClip>("Sounds/BSO");
		shootFire = Resources.Load<AudioClip>("Sounds/ShootFire");
		btnClick = Resources.Load<AudioClip>("Sounds/ButtonClick");
		MusicSource = gameObject.AddComponent<AudioSource>();
		EffectsSource = gameObject.AddComponent<AudioSource>();
		PlayMusic();
	}
	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}
	// Play a single clip through the music source.
	public void PlayMusic()
	{
		MusicSource.clip = music;
		MusicSource.volume = DataClass.SETTINGS_VOLUME_MUSIC ? 0.8f : 0;
		MusicSource.loop = true;
		MusicSource.Play(0);
	}

	public void changeBSOVolumen()
    {
		MusicSource.volume = DataClass.SETTINGS_VOLUME_MUSIC ? 0.8f : 0;
	}

	public void PlayShoot()
	{
		if(DataClass.SETTINGS_VOLUME_EFFECTS)
			EffectsSource.PlayOneShot(shootFire, 0.8f);
	}
	public void PlayButtonClick()
	{
		if (DataClass.SETTINGS_VOLUME_EFFECTS)
			EffectsSource.PlayOneShot(btnClick, 1);
	}
}