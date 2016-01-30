using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehaviour : MonoBehaviour
{
    private Dictionary<GameController.Phase, Vector3> CameraPositions = new Dictionary<GameController.Phase, Vector3>
    {
        {GameController.Phase.Results, new Vector3(0, 0, 7.5f) },
        {GameController.Phase.Player1, new Vector3(-7.3f, 0f, 4.455f) },
        {GameController.Phase.Player2, new Vector3(7.3f, 0f, 4.455f) }
    };
    public float speed;
    private bool moving = false;
    private Vector3 startingPos;
    private Vector3 destination;
    private float startTime;
    private float journeyLength;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Vector3 currentPos = Vector3.Lerp(startingPos, destination, fracJourney);
            transform.position = new Vector3(currentPos.x, currentPos.y, -10);
            GetComponent<Camera>().orthographicSize = currentPos.z;

        }
    }

    public void OnViewChange(GameController.Phase View)
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, GetComponent<Camera>().orthographicSize);
        destination = CameraPositions[View];


        startTime = Time.time;
        journeyLength = Vector3.Distance(startingPos, destination);
        moving = true;
    }
}