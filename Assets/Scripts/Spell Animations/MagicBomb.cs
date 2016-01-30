using UnityEngine;
using System.Collections;

public class MagicBomb : MonoBehaviour {

	public int numberToFall;
	public int turnNumb;

	public float moveSpeed;

	int spellTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		spellTime = 4;

		StartCoroutine(Wait());


//		if(turnNumb >= numberToFall)
//		{
//			//Drop, deal damage
//			Destroy(gameObject);
//		}
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(spellTime);
		print("Hi");
	}
}
