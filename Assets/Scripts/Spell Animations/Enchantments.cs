using UnityEngine;
using System.Collections;

public class Enchantments : MonoBehaviour {

    public float lifeTime;
    float timer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            timer = 0;
            Destroy(this.gameObject);
        }
	
	}
}
