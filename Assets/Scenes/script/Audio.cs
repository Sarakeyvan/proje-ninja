using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio 
{
    // Start is called before the first frame update
    public string name;
    public AudioClip clip;
    [Range(0f,5f)]
    public float volume;
    [Range(1f,3f)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource source;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
