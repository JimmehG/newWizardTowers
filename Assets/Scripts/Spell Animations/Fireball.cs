using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;

	public AudioClip movementSoundFX;
	public AudioClip explosionSFX;

	AudioSource aSource;


	// Use this for initialization
	void Start () 
	{
		aSource = GetComponent<AudioSource>();

		aSource.clip = movementSoundFX;
		aSource.Play();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Player source = GameController.instance.currentCaster;

		if(source == GameController.instance.player1)
		{
			transform.Translate(speed * Time.deltaTime,0,0);
		

		}
		else
		{
			transform.Translate(-speed * Time.deltaTime,0,0);
		}

		//transform.Translate(speed * Time.deltaTime,0,0);
		
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		aSource.clip = explosionSFX;
		aSource.Play();
        Destroy(gameObject);
    } 
}
