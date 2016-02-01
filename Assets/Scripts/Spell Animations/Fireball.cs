using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{

    public float speed;
    public Player source;
    public AudioClip movementSoundFX;
    public GameObject explosion;
    public GameObject expSound;

    Rigidbody2D rig2D;

    AudioSource aSource;


    // Use this for initialization
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

        aSource = GetComponent<AudioSource>();

        aSource.clip = movementSoundFX;
        aSource.Play();

      

    }

    public void giveSource(Player source)
    {
        this.source = source;
    }

    // Update is called once per frame
    void Update()
    {

        rig2D.AddForce(new Vector2(10, 0));

        Player source = GameController.instance.currentCaster;

        if (source == GameController.instance.player1)
        {
            rig2D.AddForce(new Vector2(speed * Time.deltaTime, 0));

        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        //transform.Translate(speed * Time.deltaTime,0,0);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
       // print("Hit");
        col.gameObject.GetComponent<Player>().PlayHit();
        GameController.instance.currentCaster.castingAnimation = false;
        Instantiate(explosion);
        Instantiate(expSound);
        Destroy(this.gameObject);

    }
}
