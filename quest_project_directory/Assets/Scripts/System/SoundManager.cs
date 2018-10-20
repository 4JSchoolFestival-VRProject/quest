using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    // Use this for initialization
    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sound(int value)
    {
        this.audioSource.PlayOneShot(audioClip[value]);
    }
}