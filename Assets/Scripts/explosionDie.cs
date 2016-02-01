using UnityEngine;
using System.Collections;

public class explosionDie : MonoBehaviour {

    public float death;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}

    void Update()
    {
        float nowTime = Time.time - startTime;
        //Debug.Log(nowTime);
        if (nowTime >= death)
        {
            Destroy(gameObject);
        }
    }
	
}
