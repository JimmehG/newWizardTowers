using UnityEngine;
using System.Collections;

public class MagicBomb : MonoBehaviour {

	public int numberToFall;
	public int turnNumb;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(turnNumb >= numberToFall)
		{
			//Drop, deal damage
			Destroy(gameObject);
		}
	
	}
}
