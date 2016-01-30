using UnityEngine;
using System.Collections;

public class PhaseObject : MonoBehaviour {

    public Vector2 p1Location, p2Location;
    

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
