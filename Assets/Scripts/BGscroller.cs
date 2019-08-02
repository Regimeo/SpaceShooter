using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private GameController gameController;
    private Vector3 startPosition;
    private int counter;
    void Start()
    {
        startPosition = transform.position;
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameController.score >= 100)
        {
            while (counter <= 5)
            {
            scrollSpeed = scrollSpeed - 0.5f;
            counter++;
            }
        }
    }
}
