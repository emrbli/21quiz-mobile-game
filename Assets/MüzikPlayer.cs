using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MüzikPlayer : MonoBehaviour {

    private AudioSource adoscr;

    private float musicVolume = 1f;

    private void Start()
    {
        adoscr = GetComponent<AudioSource>();

    }
    private void Update()
    {
        adoscr.volume = musicVolume;
    }
    
    public void SetVolume(float vol)
    {
        musicVolume = vol; 
    }
}
