using UnityEngine;
using System.Collections;

public class RitualAnimation : MonoBehaviour
{

	public GameObject fireBallObj;
	[Space (5)]
	public GameObject lightShieldObj;
	public float shieldXDistance;
	[Space(5)]
	public GameObject paralyseObj;

	public static RitualAnimation instance;

	void Start ()
	{
		if (instance == null) {
			instance = new RitualAnimation ();
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
			Instantiate (fireBallObj, new Vector3 (source.transform.position.x + 2.5f, source.transform.position.y, -5), Quaternion.identity);

		}




		source.castingAnimation = false;
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


		source.castingAnimation = false;
	}

	public void ParalyseAnimation ()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		if (source == GameController.instance.player1) 
		{
			Instantiate (paralyseObj, new Vector3 (source.transform.position.x + shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		} else
		{
			Instantiate (paralyseObj, new Vector3 (source.transform.position.x - shieldXDistance, source.transform.position.y, -5), Quaternion.identity);

		}


		source.castingAnimation = false;
	}

	public void HealingWaterAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;
		
	}

	public void DisenchantAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void ConfuseAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

		source.castingAnimation = false;

	}

	public void MirrorAnimation()
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn ().target;

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






}
