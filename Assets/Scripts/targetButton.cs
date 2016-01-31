using UnityEngine;
using System.Collections;

public class targetButton : MonoBehaviour
{
    public Player targetPlayer;

    public void sendTarget()
    {
        GameController.instance.sendTarget(targetPlayer);
    }
}
