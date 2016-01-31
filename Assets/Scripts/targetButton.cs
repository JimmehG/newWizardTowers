using UnityEngine;
using System.Collections;

public class targetButton : MonoBehaviour
{
    public enum PlayerTarget { Player1, Player2 };
    public PlayerTarget target;
    private Player targetPlayer;

    void Start()
    {
        if (target == PlayerTarget.Player1) {
            targetPlayer = GameController.instance.player1;
        }
        else if (target == PlayerTarget.Player2)
        {
            targetPlayer = GameController.instance.player2;
        }
    }

    public void sendTarget()
    {
        GameController.instance.sendTarget(targetPlayer);
    }
}
