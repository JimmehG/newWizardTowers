using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () 
	{
		
	
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

    void OnCollisionEnter(Collision2D col)
    {
        Destroy(gameObject);
    } 
}
