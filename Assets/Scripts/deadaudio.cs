using UnityEngine;
using System.Collections;

public class deadaudio : MonoBehaviour {

    public AudioClip explosionSFX;
    AudioSource aSource;

    // Use this for initialization
    void Start()
    {

        aSource = GetComponent<AudioSource>();
        aSource.clip = explosionSFX;
        aSource.Play();
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}
}
