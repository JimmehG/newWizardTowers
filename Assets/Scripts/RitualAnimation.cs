using UnityEngine;
using System.Collections;

public class RitualAnimation : MonoBehaviour {

	public GameObject fireBallObj;
	[Space(5)]
	public GameObject lightShieldObj;
	public float shieldXDistance;

	public static RitualAnimation instance;

	void Start()
	{
		if (instance == null) {
			instance = new RitualAnimation();
		} else {
			Destroy(this);
		}
	}

	public RitualAnimation() {
	}


	public void FireballAnimation() 
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn().target;
		Instantiate(fireBallObj,new Vector3(source.transform.position.x,source.transform.position.y,-5),Quaternion.identity);

		source.castingAnimation = false;
	}

	public void ShieldAnimation() 
	{
		Player source = GameController.instance.currentCaster;
		Player target = source.getTurn().target;
		Instantiate(lightShieldObj,new Vector3(source.transform.position.x + shieldXDistance,source.transform.position.y,-5),Quaternion.identity);

		source.castingAnimation = false;
	}


}
