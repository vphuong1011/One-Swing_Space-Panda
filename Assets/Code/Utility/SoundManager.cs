using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private AudioSource MusicAudioSource;

    public AudioClip[] clip;

    public MainMenuSet menu;

	public void PlaySFX()
    {
        SFXAudioSource.Play();
        //TODO: Play a sound effect
    }

    public void PlayMusic()
    {
        //TODO: Play the game music
        MusicAudioSource.Play();
    }

    void Start()
    {
        PlayMusic();
    }

    void Update()
    {

           // clip[0] = SFXAudioSource.GetComponent<AudioClip>();
            PlaySFX();
            //Debug.Log("AUDIO HAHA");

    }
}
