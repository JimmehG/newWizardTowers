using UnityEngine;
using System.Collections;

public class DisenchantAnimate : MonoBehaviour {

	public float affectTime;
	float timer;
	[Space(5)]
	public Transform positionY;
	public ParticleSystem pS;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	

		pS.Play();

		timer += Time.deltaTime;

		if(timer >= affectTime)
		{
			Destroy(gameObject);
			timer = 0;
		}
		
	
	}
}
