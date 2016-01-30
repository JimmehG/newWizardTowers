using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};

	public Player player1, player2;
	[HideInInspector]
	public Player currentCaster;

	public static GameController instance;


    private Phase currentView;

    public CameraBehaviour cam;


    void Start()
    {
		if (instance == null) {
			instance = new GameController();
		} else {
			Destroy(this);
		}

		currentPhase = Phase.Player1;
		TriggerPhaseObjects();
		
		currentView = Phase.Player1;
		TriggerCameraView();
    }

	public GameController() {

    }

    public void EndTurn()
    {
        
        if (currentPhase == Phase.Player2)
        {
            currentPhase = Phase.Results;
        }
        else
        {
            currentPhase++;
        }

        currentView = currentPhase;

        Debug.Log(currentPhase.ToString());
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a}));
		Debug.Log(Ritual.FIREBALL.Castable(new Rune[] {Rune.a, Rune.f}));
        
        TriggerPhaseObjects();
        TriggerCameraView();

        if (currentPhase == Phase.Results) {
            RunResults();
        }
    }

    void TriggerPhaseObjects()
    {
		foreach (PhaseButton p in FindObjectsOfType(typeof(PhaseButton)) as PhaseButton[])
        {
            p.OnPhase(currentPhase);
        }
    }

    void TriggerCameraView()
    {
        cam.OnViewChange(currentView);
    }

    void RunResults()
    {
        Player[] players = FindObjectsOfType(typeof(Player)) as Player[];
        foreach (Player p in players)
        {
            p.addRunes();
        }

		Ritual p1Ritual = player1.getTurn().ritualCast;
		Ritual p2Ritual = player2.getTurn().ritualCast;
		if (p1Ritual != null && p2Ritual != null) {
			//P1 goes first on same-spell. Shouldn't make a difference. Can case-by-case it later.
			if (p1Ritual.GetPriority() < p2Ritual.GetPriority()) {
				currentCaster = player2;
				Cast();
				currentCaster = player1;
				Cast();
			} else {
				currentCaster = player1;
				Cast();
				currentCaster = player2;
				Cast();
			}
		} else if (p1Ritual != null) {
			currentCaster = player1;
			Cast();
		} else if (p2Ritual != null) {
			currentCaster = player2;
			Cast();
		}

		TurnCleanup();
    }

	IEnumerator Cast() {
		currentCaster.castingEffect = true;
		currentCaster.castingAnimation = true;
		RitualEffect.instance.Invoke(currentCaster.getTurn().ritualCast.GetEffect(), 0.0f);
		RitualAnimation.instance.Invoke(currentCaster.getTurn().ritualCast.GetAnimation(), 0.0f);
		while (currentCaster.castingEffect == true || currentCaster.castingAnimation == true) {
			yield return null;
		}
	}

	void TurnCleanup() {
		player1.TurnCleanup();
		player2.TurnCleanup();
	}

}
