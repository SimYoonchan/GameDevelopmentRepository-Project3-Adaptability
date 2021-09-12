using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound soundLoopVariable in sounds)
        {
            soundLoopVariable.source = gameObject.AddComponent<AudioSource>();
            soundLoopVariable.source.clip = soundLoopVariable.audioClip;
            soundLoopVariable.source.volume = soundLoopVariable.volume;
            soundLoopVariable.source.pitch = soundLoopVariable.pitch;
            soundLoopVariable.source.loop = soundLoopVariable.loop;
        }
    }

    public void Play(string name)
    {
        Sound soundLoopVariable = Array.Find(sounds, sound => sound.name == name);
        if (soundLoopVariable == null)
        {
            Debug.LogError("The Sound: " + name + " is not found.");
            return;
        }
        soundLoopVariable.source.Play();
    }
}