using UnityEngine;
using System.Collections;

public class RitualButton : MonoBehaviour {

	public Ritual ritual;

    public void sendRitual()
    {
        GameController.instance.sendRitual(ritual);
    }

	public void targetVisible(bool visible)
    {
        CanvasGroup cG = GameObject.FindGameObjectWithTag("targetUI").GetComponent<CanvasGroup>();
        if (visible)
            cG.alpha = 1;
        else
            cG.alpha = 0;

        cG.interactable = visible;
        cG.blocksRaycasts = visible;
    }
}
