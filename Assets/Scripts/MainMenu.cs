using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayButton()
	{
		Application.LoadLevel(1);
	}

	public void HowtoPlay() 
	{
		
	}

	public void CreditsButton()
	{
	}

	public void QuitButton()
	{
		Application.Quit();
	}
}
