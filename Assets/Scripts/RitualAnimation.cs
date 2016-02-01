using UnityEngine;
using System.Collections;
using System;

public class RitualAnimation : MonoBehaviour
{

	public GameObject fireBallObj;
	[Space (5)]
	public GameObject lightShieldObj;
	public float shieldXDistance;
	[Space(5)]
	public GameObject paralyseObj;
	public float paralyseYPos;
	[Space(5)]
	public GameObject healingObj;
	public float healingYPos;
	[Space(5)]
	public GameObject disenchanteObj;
	public float disenchantYPos;
	[Space(5)]
	public GameObject confuseObj;
	public float confuseYPos;
	[Space(5)]
	public GameObject mirrorObj;
	[Space(5)]
	public GameObject magicBombObj;
	[Space(5)]
	public GameObject freezeObj;
	[Space(5)]
	public GameObject powerSurgeObj;
	[Space(5)]
	public GameObject companionObj;
	[Space(5)]
	public GameObject fireCannonObj;
	[Space(5)]
	public GameObject drainObj;


	int spellTime;


	public static RitualAnimation instance;

	void Start ()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

	public RitualAnimation ()
	{
	}

	public void FireballAnimation ()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (fireBallObj, new Vector3 (source.transform.position.x + 2.5f, source.transform.position.y, -5), Quaternion.identity);

		} else
		{
			Instantiate (fireBallObj, new Vector3 (source.transform.position.x - 2.5f, source.transform.position.y, -5), Quaternion.identity);

		}

	//	spellTime = 5;

//		StartCoroutine(Wait());

		//source.castingAnimation = false;
	}
		

	public void ShieldAnimation ()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (lightShieldObj, new Vector3 (source.transform.position.x + shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		} else
		{
			Instantiate (lightShieldObj, new Vector3 (source.transform.position.x - shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		}


		spellTime = 5;

		StartCoroutine(Wait());

		source.castingAnimation = false;
	}

	public void ParalyseAnimation ()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (paralyseObj, new Vector3 (source.transform.position.x, source.transform.position.y + paralyseYPos, -5), Quaternion.identity);

		} else
		{
			Instantiate (paralyseObj, new Vector3 (source.transform.position.x, source.transform.position.y + paralyseYPos, -5), Quaternion.identity);

		}


		source.castingAnimation = false;
	}

    

    public void HealingWaterAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (healingObj, new Vector3 (source.transform.position.x, source.transform.position.y + healingYPos, -5), Quaternion.identity);

		} else
		{
			Instantiate (healingObj, new Vector3 (source.transform.position.x, source.transform.position.y + healingYPos, -5), Quaternion.identity);

		}

		source.castingAnimation = false;
		
	}

	public void DisenchantAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (disenchanteObj, new Vector3 (source.transform.position.x, source.transform.position.y + disenchantYPos, -5), Quaternion.identity);

		} else
		{
			Instantiate (disenchanteObj, new Vector3 (source.transform.position.x, source.transform.position.y + disenchantYPos, -5), Quaternion.identity);

		}

		source.castingAnimation = false;

	}

	public void ConfuseAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (confuseObj, new Vector3 (source.transform.position.x, source.transform.position.y  + confuseYPos, -5), Quaternion.identity);

		} else
		{
			Instantiate (confuseObj, new Vector3 (source.transform.position.x, source.transform.position.y + confuseYPos, -5), Quaternion.identity);

		}

		source.castingAnimation = false;

	}

	public void MirrorAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (lightShieldObj, new Vector3 (source.transform.position.x + shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		} else
		{
			Instantiate (lightShieldObj, new Vector3 (source.transform.position.x - shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		}

		source.castingAnimation = false;

	}

	public void MagicBombAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void FreezeAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void PowerSurgeAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void CompanionAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void FireCanonAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void DrainAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}


	IEnumerator Wait()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		
		yield return new WaitForSeconds(spellTime);

		source.castingAnimation = false;

		//source.castingAnimation = false;
	}
}





