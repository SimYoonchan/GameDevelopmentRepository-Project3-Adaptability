using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; //Don't make this [SerializeField] but public for access.
    public AudioClip audioClip; //Don't make this [SerializeField] but public for access.

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source; //Don't make this [SerializeField] but public for access.
}
