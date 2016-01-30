using UnityEngine;
using System.Collections;

public class RuneButton : MonoBehaviour {

	public Rune rune;

	public void AddRune() {
		GameController.instance.addRune(rune);
	}

}
