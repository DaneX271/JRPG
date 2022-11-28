using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        GameObject go = new GameObject();
        go.name = clip.name;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 100;
        source.loop = false;
        source.Play();
    }
    
    public void PlayMusic(AudioClip clip)
    {
        GameObject go = new GameObject();
        go.name = clip.name;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 100;
        source.loop = true;
        source.Play();
    }
}
