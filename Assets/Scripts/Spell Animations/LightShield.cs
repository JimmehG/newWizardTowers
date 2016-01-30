using UnityEngine;
using System.Collections;

public class LightShield : MonoBehaviour
{

    public float destroyTime;
    float timer;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= destroyTime)
        {
            Destroy(gameObject);
            timer = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
