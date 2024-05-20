using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioData[] data;
    private AudioSource BGSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BGSource = GetComponent<AudioSource>();
        PlayAudio(BGSource, "BG");
    }

    public void PlayAudio(AudioSource source, string audioname)
    {
        int index = Array.FindIndex(data, (x) => x.name == audioname);
        if (index != -1)
        {
            source.clip = data[index].audioClip;
            source.loop = data[index].isLoop;
            source.volume = data[index].vol;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}

[System.Serializable]
public class AudioData
{
    public string name;
    public AudioClip audioClip;
    public float vol;
    public bool isLoop;
}