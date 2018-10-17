using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    AudioSource audioSource;  
    public List<AudioClip> audioClip = new List<AudioClip>();  

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sound(int value)
    {
        audioSource.PlayOneShot(audioClip[value]);
    }
}
