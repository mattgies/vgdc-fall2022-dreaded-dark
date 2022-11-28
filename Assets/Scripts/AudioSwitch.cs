using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    public AudioClip[] clipsToSwitchBetween;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void toggleAudioLightDark() {
        float curTime = audioSource.time;
        if (audioSource.clip == clipsToSwitchBetween[0]) {
            audioSource.clip = clipsToSwitchBetween[1];
        }
        else {
            audioSource.clip = clipsToSwitchBetween[0];
        }
        audioSource.time = curTime;
        audioSource.Play();
    }

    public void onResetAudioSwitch(){
        float curTime = audioSource.time;
        audioSource.clip = clipsToSwitchBetween[1];
        audioSource.time = curTime;
        audioSource.Play();
    }
}
