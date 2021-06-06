using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOpenClose : MonoBehaviour
{
    public AudioSource audioS;
    public GameObject muteImg, onImg;
    public void AudioEnable()
    {
        if (audioS.mute)
        {
            audioS.mute = false;
            muteImg.SetActive(false);
            onImg.SetActive(true);
        }else 
        {
            audioS.mute = true;
            muteImg.SetActive(true);
            onImg.SetActive(false);
        }
    }
   
}
