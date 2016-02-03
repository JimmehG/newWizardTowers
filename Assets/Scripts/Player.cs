using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Animator))]
public class Player : MonoBehaviour {

	private Animator animator;

    public Sprite hit;
    public Sprite cast;

    private SpriteRenderer sprRend;

	[HideInInspector]
	public bool castingEffect = false;
	[HideInInspector]
	public bool castingAnimation = false;
    
    public enum StatusEffect {Shield, Paralyse,HealingWater,Confuse };
	[HideInInspector]
	public List<StatusEffect> currentEffects;
	public int health;
    private List<Rune> runeBucket;
    private Turn turn;

    void Reanimate() {
        GetComponent<Animator>().enabled = true;
    }

    void Start () {
        runeBucket = new List<Rune>();
		currentEffects = new List<StatusEffect>();
		turn = new Turn();
		animator = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
	}

    public void addRunes()
    {
        if (turn.GetRunes().Count > 0)
        {
            runeBucket.AddRange(turn.GetRunes());
        }
    }

    public List<Rune> getRunes()
    {
        return runeBucket;
    }

	public void useRunes(Rune[] used) {
		foreach (Rune r in used) {
			runeBucket.Remove(r);
		}
        sprRend.sprite = cast;
        GetComponent<Animator>().enabled = false;
        Invoke("Reanimate", 1.5f);
	}

	public void addHealth(int damage) {
		health += damage;
    }
    public void PlayHit()
    {
        sprRend.sprite = hit;
        GetComponent<Animator>().enabled = false;
        Invoke("Reanimate", 1.5f);
    }

	public bool isDead() {
		return health <= 0;
	}

	public void addStatus(StatusEffect status) {
		currentEffects.Add(status);
	}
    
    public Turn getTurn() {
		return turn;
	}

	public void TurnCleanup() {
		turn = new Turn();
		currentEffects.Remove(StatusEffect.Confuse);
        currentEffects.Remove(StatusEffect.Paralyse);
		currentEffects.Remove(StatusEffect.Shield);

	}
}
