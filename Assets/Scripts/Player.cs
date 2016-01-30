using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Animator))]
public class Player : MonoBehaviour {

	private Animator animator;

	[HideInInspector]
	public bool castingEffect = false;
	[HideInInspector]
	public bool castingAnimation = false;
    
    public enum StatusEffect {Shield, Confuse };
	[HideInInspector]
	public List<StatusEffect> currentEffects;
    private int health;
    private List<Rune> runeBucket;
    private Turn turn;

	void Start () {
        health = 100;
        runeBucket = new List<Rune>();
		currentEffects = new List<StatusEffect>();
		turn = new Turn();
		animator = GetComponent<Animator>();
	}

    public void addRunes()
    {
        runeBucket.AddRange(turn.runesAdded);
        turn.runesAdded.Clear();
    }

    public List<Rune> getRunes()
    {
        return runeBucket;
    }

	public void useRunes(Rune[] used) {
		foreach (Rune r in used) {
			runeBucket.Remove(r);
		}
	}

	public void addHealth(int damage) {
		health += damage;
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
		currentEffects.Remove(StatusEffect.Shield);
	}
}
