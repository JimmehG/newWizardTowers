using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Phase currentPhase;
    public enum Phase {Results, Player1, Player2};

	public Player player1, player2;
    [HideInInspector]
    public Player currentCaster;

	public static GameController instance;

	public Text winText;
    public Text runeText;

    private Phase currentView;

    public CameraBehaviour cam;
	public GameObject ritualButton;
	public GameObject ritualList;
    public GameObject exitButton;

	private List<GameObject> ritualButtons;


    void Start()
    {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}

		currentPhase = Phase.Player1;
        currentView = Phase.Player1;
        TriggerPhaseObjects();
		
        ChangeViewPhaseObjects();
		CreateRitualButtons();
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
        
        TriggerPhaseObjects();

        if (currentPhase == Phase.Results) {
            RunResults();
        } else {
			runeDisplay();
		}
    }

    

    void RunResults()
    {
        player1.addRunes();
		player2.addRunes();

		Ritual p1Ritual = player1.getTurn().ritualCast;
		Ritual p2Ritual = player2.getTurn().ritualCast;


        if (p1Ritual != null && p2Ritual != null) {
			//P1 goes first on same-spell. Shouldn't make a difference. Can case-by-case it later.
			if (p1Ritual.GetPriority() < p2Ritual.GetPriority()) {
                //p2effect
                CastEffect(player2);
                //P1effect
                CastEffect(player1);
                //Start animation coroutine
                StartCoroutine(CastAnimation(player2, player1));
			} else {
                //P1effect
                CastEffect(player1);
                //p2effect
                CastEffect(player2);
                //Start animation coroutine
                StartCoroutine(CastAnimation(player1, player2));
            }
		} else if (p1Ritual != null) {
            //P1effect
            CastEffect(player1);
            StartCoroutine(CastAnimation(player1));
        } else if (p2Ritual != null) {
            //p2effect
            CastEffect(player2);
            StartCoroutine(CastAnimation(player2));
        }

		TurnCleanup();
    }

    private void CastEffect(Player player)
    {
        currentCaster = player;
        currentCaster.castingEffect = true;
        currentCaster.useRunes(currentCaster.getTurn().ritualCast.GetRunes());
        currentCaster.getTurn().ritualCast.CastEffect();
    }

    IEnumerator CastAnimation(Player player)
    {
        currentCaster = player;
        currentCaster.castingAnimation = true;
        RitualAnimation.instance.Invoke(currentCaster.getTurn().ritualCast.GetAnimation(), 0.0f);
        yield return new WaitWhile(() => currentCaster.castingAnimation);
    }

    IEnumerator CastAnimation(Player firstPlayer, Player secondPlayer) {

        CastAnimation(firstPlayer);
        CastAnimation(secondPlayer);
        yield return null;
	}

	void TurnCleanup() {
		player1.TurnCleanup();
		player2.TurnCleanup();

		if (player1.isDead() || player2.isDead()) {
			GameOver();
		} else {
			EndTurn();
		}
	}

	void GameOver() {
		if (player1.isDead()) {
			if (player2.isDead()) {
				winText.text = "Draw";
			} else {
				winText.text = "Player 2 wins!";
			}
		} else {
			winText.text = "Player 1 wins!";
		}

		winText.enabled = true;
        exitButton.SetActive(true);
	}

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void addRune(Rune rune)
    {
		if (currentView == currentPhase) {
	        if (currentPhase == Phase.Player1)
	        {
	            player1.getTurn().AddRune(rune);
	        }
	        else
	        {
	            player2.getTurn().AddRune(rune);
	        }

	        runeDisplay();
		}
    }

	public void removeRune() {
		if (currentView == currentPhase) {
			if (currentPhase == Phase.Player1)
			{
				player1.getTurn().RemoveRune();
			}
			else
			{
				player2.getTurn().RemoveRune();
			}
			
			runeDisplay();
		}
	}

    public void runeDisplay()
    {
        string generatedText = "";
        List<Rune> runesToDisplay = new List<Rune>();
        Player viewPlayer;

        if (currentView == Phase.Player1)
        {
            viewPlayer = player1;
        } else
        {
            viewPlayer = player2;
        }
        
        runesToDisplay.AddRange(viewPlayer.getRunes());
		if (currentView == currentPhase) {
        	runesToDisplay.AddRange(viewPlayer.getTurn().GetRunes());
		}

        foreach (Rune r in runesToDisplay)
        {
            generatedText += Enum.GetName(typeof(Rune), r);
        }
        
        runeText.text = generatedText;
            
		InteractableRitualButtons(runesToDisplay);
    }

    void TriggerPhaseObjects()
    {
        CanvasGroup cG = GameObject.FindGameObjectWithTag("mainUI").GetComponent<CanvasGroup>();
        if (currentPhase == GameController.Phase.Results)
            cG.alpha = 0;
        else
            cG.alpha = 1;

        cG.interactable = (currentPhase != GameController.Phase.Results);

        TriggerCameraView();
        ChangeViewPhaseObjects();

    }

    void TriggerCameraView()
    {
        cam.OnViewChange(currentView);
    }

    public void ViewOtherPlayer()
    {
        if (currentView != Phase.Results)
        {
            if (currentView == Phase.Player1)
            {
                currentView = Phase.Player2;
            }
            else if (currentView == Phase.Player2)
            {
                currentView = Phase.Player1;
            }
            ChangeViewPhaseObjects();
            TriggerCameraView();
			runeDisplay();
        }
        
    }
    void ChangeViewPhaseObjects()
    {
        foreach (PhaseObject p in FindObjectsOfType(typeof(PhaseObject)) as PhaseObject[])
        {
            p.OnViewChange(currentView);
        }
    }

	void CreateRitualButtons() {
		ritualButtons = new List<GameObject>();

		int position = 0;
		foreach (Ritual ritual in Ritual.Values) {
			GameObject button = (GameObject)Instantiate(ritualButton, new Vector3(ritualList.transform.position.x, ritualList.transform.position.y + 150 - (position * 35), 0f), Quaternion.identity);
			button.transform.SetParent(ritualList.transform);

			button.GetComponent<Button>().interactable = false;

			button.GetComponent<RitualButton>().ritual = ritual;
			button.GetComponentInChildren<Text>().text = ritual.GetName();

			ritualButtons.Add(button);

			position++;
		}
	}

	void InteractableRitualButtons(List<Rune> runes) {
		foreach (GameObject button in ritualButtons) {
			if (currentPhase == currentView && button.GetComponent<RitualButton>().ritual.Castable(runes.ToArray)) {
				button.GetComponent<Button>().interactable = true;
			} else {
				button.GetComponent<Button>().interactable = false;
			}
		}
	}


    public void sendRitual(Ritual ritual)
    {
        if (currentPhase == Phase.Player1)
        {
            player1.getTurn().ritualCast = ritual;
        }
        else
        {
            player2.getTurn().ritualCast = ritual;
        }
    }

    public void sendTarget(Player targetPlayer)
    {
        if (currentPhase == Phase.Player1)
        {
            player1.getTurn().target = targetPlayer;
        }
        else if (currentPhase == Phase.Player2)
        {
            player2.getTurn().target = targetPlayer;
        }
    }



}
