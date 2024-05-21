using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioText : MonoBehaviour
{
    
    public static void PlayTextAudio_Static(AudioSource audioSource, AudioClip audioClip)
    {
        if(audioSource != null)
        {
            if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
