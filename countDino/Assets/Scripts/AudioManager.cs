using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource musicPlayer, soundPlayer;
    public AudioClip[] avaibleSoundClips;
    private Dictionary<string, AudioClip> loadedAudioClips;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        loadedAudioClips = new Dictionary<string, AudioClip>();
        foreach (AudioClip audio in avaibleSoundClips)
        {
            loadedAudioClips.Add(audio.name, audio);
        }
        PlayMusic();
    }
    public void PlaySound(string name)
    {
        soundPlayer.clip = loadedAudioClips[name];
        soundPlayer.Play();
    }
    public void StopMusic()
    {
        musicPlayer.Stop();
    }
    public void PlayMusic()
    {
        musicPlayer.loop = true;
        musicPlayer.Play();
    }
}
