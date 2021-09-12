using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    //Config Parameters:
    [Header("Time")]
    public float currentTime = 0f;
    public float musicFadeInDuration = 3f;

    [Header("Volume")]
    public float startVolume = 0f;
    public float targetVolume = 0.5f;

    AudioManager creditsMusic;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("End Credits"); //This plays "Main Theme".

        //To eliminate any potential pausing errors:
        Time.timeScale = 1f;

        //creditsMusic = FindObjectOfType<AudioManager>();
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (currentTime < musicFadeInDuration)
    //    {
    //        currentTime = currentTime + Time.smoothDeltaTime;

    //        creditsMusic. = Mathf.Lerp(startVolume, targetVolume, currentTime / musicFadeInDuration);

    //    }
    //}
}
