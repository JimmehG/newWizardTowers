using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhaseButton : MonoBehaviour
{

    public Vector2 p1Location, p2Location;

	public void OnPhase(GameController.Phase phase)
    {
        Button button = GetComponent<Button>();
        button.interactable = (phase != GameController.Phase.Results);
    }

    public void OnViewChange(GameController.Phase view)
    {
        if (view == GameController.Phase.Player1)
        {
            transform.localPosition = new Vector3(p1Location.x, p1Location.y);
        }
        else if (view == GameController.Phase.Player2)
        {
            transform.localPosition = new Vector3(p2Location.x, p2Location.y);
        }
            
    }
}
